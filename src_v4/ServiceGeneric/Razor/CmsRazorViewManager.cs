using System;
using System.IO;
using System.Linq;
using ServiceStack.Common;
using ServiceStack.Common.Utils;
using ServiceStack.IO;
using ServiceStack.Logging;
using ServiceStack.Razor;
using ServiceStack.Razor.Managers;
using ServiceStack.ServiceHost;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints.Extensions;

namespace Northwind.Data.Razor
{
    public class CmsRazorViewManager: RazorViewManager
    {
        public static ILog Logger = LogManager.GetLogger(typeof(CmsRazorViewManager));

        public const string ThemedViewPageNameFormat = "__{0}__{1}";

        private readonly string _themeName;

        public CmsRazorViewManager(IRazorConfig viewConfig, IVirtualPathProvider virtualPathProvider)
            : base(viewConfig, virtualPathProvider)
        {
            var razorConfig = viewConfig as CmsRazorFormat;
            _themeName = razorConfig != null && !string.IsNullOrEmpty(razorConfig.DefaultTheme) ? razorConfig.DefaultTheme : "Default";
        }

        // Every page that is added to the dictionary lookup is added via this method
        // You can control how pages are stored in the dictionary by overriding this method
        protected override RazorPage AddPage(RazorPage page)
        {
            var pagePath = GetDictionaryPagePath(page.PageHost.File);

            this.Pages[pagePath] = page;

            //Views should be uniquely named and stored in any deep folder structure
            if (pagePath.StartsWithIgnoreCase("/views/"))
            {
                var viewName = pagePath.SplitOnLast('.').First().SplitOnLast('/').Last();
                ViewNamesMap[viewName] = pagePath;
            }

            return page;
        }

        // This page determines the lookup key for the page in the Pages dictionary
        // This is used not only to add pages to the dictionary, but also the file system
        // watcher class to modify the dictionary at runtime
        public override string GetDictionaryPagePath(string relativePath)
        {
            var relativePathLowerCase = relativePath.ToLowerInvariant();

            //view pages
            /*
             * Formats:
             *      - /views/def.cshtml --> corresponds either to: /views/def.cshtml, OR /views/themes/default/def.cshtml
             *      - /views/__ENTERPRISE__def.cshtml --> corresponds to: /views/themes/enterprise/def.cshtml
             */
            if (relativePathLowerCase.StartsWith("/views/"))
            {
                // Add theming capabilities
                var paths = relativePathLowerCase.Split('/');
                if (relativePathLowerCase.StartsWith("/views/themes/") &&
                    !paths[3].EqualsIgnoreCase("default"))
                    return string.Concat("/views/",
                                         string.Format(ThemedViewPageNameFormat, paths[3],
                                                       Path.GetFileName(relativePathLowerCase)));
                return string.Concat("/views/", Path.GetFileName(relativePathLowerCase)).ToLowerInvariant();
            }

            // themed content pages
            /*
             * Formats:
             *      - /def.cshtml --> corresponds either to: /def.cshtml, OR /themes/default/def.cshtml
             *      - /folder1/def.cshtml --> corresponds either to: /folder1/def.cshtml, OR /themes/default/folder1/def.cshtml
             *      - /__ENTERPRISE__def.cshtml --> corresponds to: /themes/enterprise/def.cshtml
             *      - /folder1/__ENTERPRISE__def.cshtml --> corresponds either to: /themes/enterprise/folder1/def.cshtml
             */
            if (relativePathLowerCase.StartsWith("/themes/"))
            {
                // Add theming capabilities
                var paths = relativePathLowerCase.Split('/');
                if (paths[2].EqualsIgnoreCase("default"))
                    return string.Join("/", paths.Skip(3).ToArray());
                return string.Concat(string.Join("/", paths.Skip(3).Take(paths.Length - 4).ToArray()), "/",
                                     string.Format(ThemedViewPageNameFormat, paths[2], Path.GetFileName(relativePathLowerCase))).ToLowerInvariant();
            }

            return relativePathLowerCase;
        }

        // Get themed view page first, then default back to a non-themed view page search
        public override RazorPage GetPageByName(string pageName, IHttpRequest request, object dto)
        {
            RazorPage page = null;

            var theme = GetThemeName(request);

            if (!string.IsNullOrEmpty(theme) && !theme.EqualsIgnoreCase("default"))
                page = base.GetPageByName(string.Format(ThemedViewPageNameFormat, theme.ToLowerInvariant(), pageName.ToLowerInvariant()), request, dto);

            return page ?? base.GetPageByName(pageName, request, dto);
        }

        // Get themed content page first, then default back to a non-themed content page search
        internal RazorPage GetPageByPathInfo(string pathInfo, IHttpRequest request)
        {
            RazorPage page = null;
            var theme = GetThemeName(request);

            if (!string.IsNullOrEmpty(theme) && !theme.EqualsIgnoreCase("default"))
            {
                // rebuild path info with theme info
                var pageName = Path.GetFileName(pathInfo);
                var pathInfoWithoutPage = pathInfo.Substring(0, pathInfo.LastIndexOf('/')).TrimEnd('/');
                var themedPathInfo = string.Concat(pathInfoWithoutPage, "/",
                                                   string.Format(ThemedViewPageNameFormat, theme.ToLowerInvariant(), pageName.ToLowerInvariant()));

                page = GetPageByPathInfo(themedPathInfo);
            }
            return page ?? GetPageByPathInfo(pathInfo);
        }

        public override RazorPage GetPage(IHttpRequest request, object dto)
        {
            var normalizePath = NormalizePath(request, dto);
            return GetPage(normalizePath, request); // modified from base class to include request in arguments
        }

        public RazorPage GetPage(string absolutePath, IHttpRequest request) // new method not in base class that looks for themed content page
        {
            RazorPage page = null;
            var theme = GetThemeName(request);

            if (!string.IsNullOrEmpty(theme) && !theme.EqualsIgnoreCase("default"))
            {
                var pageName = Path.GetFileName(absolutePath);
                if (pageName != null)
                {
                    var pathInfoWithoutPage = absolutePath.Substring(0, absolutePath.LastIndexOf('/')).TrimEnd('/');
                    var themedPathInfo = string.Concat(pathInfoWithoutPage, "/",
                                                       string.Format(ThemedViewPageNameFormat, theme.ToLowerInvariant(), pageName.ToLowerInvariant()));
                    page = base.GetPage(themedPathInfo);
                }
            }

            // revert to non-themed fetcher if no themed page exists
            page = page ?? base.GetPage(absolutePath);
            return page;
        }

        #region Helper Functions

        private string GetThemeName(IHttpRequest request)
        {
            var theme = (request == null ? null : request.GetParam("Theme"));
            if(theme.IsNullOrEmpty())
                return _themeName.IsNullOrEmpty() ? null: _themeName.ToLowerInvariant();
            return theme.ToLowerInvariant();
        }

        #region Helper function copies from base class (UNFORTUNATE)

        static char[] InvalidFileChars = new[] { '<', '>', '`' }; //Anonymous or Generic type names
        private string NormalizePath(IHttpRequest request, object dto)
        {
            if (dto != null && !(dto is DynamicRequestObject)) // this is for a view inside /views
            {
                //if we have a view name, use it.
                var viewName = request.GetView();

                if (string.IsNullOrWhiteSpace(viewName))
                {
                    //use the response DTO name
                    viewName = dto.GetType().Name;
                }
                if (string.IsNullOrWhiteSpace(viewName))
                {
                    //the request use the request DTO name.
                    viewName = request.OperationName;
                }

                var isInvalidName = viewName.IndexOfAny(InvalidFileChars) >= 0;
                if (!isInvalidName)
                {
                    return CombinePaths("views", Path.ChangeExtension(viewName, Config.RazorFileExtension));
                }
            }

            // path/to/dir/default.cshtml
            var path = request.PathInfo;
            var defaultIndex = CombinePaths(path, Config.DefaultPageName);
            if (Pages.ContainsKey(defaultIndex))
                return defaultIndex;

            return Path.ChangeExtension(path, Config.RazorFileExtension);
        }
        private static string CombinePaths(params string[] paths)
        {
            var combinedPath = PathUtils.CombinePaths(paths);
            if (!combinedPath.StartsWith("/"))
                combinedPath = "/" + combinedPath;
            return combinedPath;
        }

        #endregion

        #endregion
    }
}
 