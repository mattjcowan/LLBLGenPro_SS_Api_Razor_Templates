using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.Html;
using ServiceStack.Razor;
using ServiceStack.Razor.Managers;
using ServiceStack.ServiceHost;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints.Extensions;
using ServiceStack.WebHost.Endpoints.Support;

// TODO: SUGGEST CHANGES IN SERVICESTACK RAZOR CORE TO AVOID HAVING TO CREATE THIS ADDITIONAL CLASS
//       VARIANCE IN THIS FILE IS IN THE FindRazorPage METHOD
namespace Northwind.Data.Razor
{
    public class CmsRazorPageResolver : RazorPageResolver
    {
        private readonly IRazorConfig _config;
        private readonly RazorViewManager _viewManager;

        public CmsRazorPageResolver(IRazorConfig config, RazorViewManager viewManager) : base(config, viewManager)
        {
            this._config = config;
            this._viewManager = viewManager;
        }

        private RazorPage FindRazorPage(IHttpRequest httpReq, object model)
        {
            var viewName = httpReq.GetItem(ViewKey) as string;
            if (viewName != null)
            {
                return this._viewManager.GetPageByName(viewName, httpReq, model);
            }
            //PREVIOUS
            //var razorPage = this.viewManager.GetPageByName(httpReq.OperationName) //Request DTO
            //             ?? this.viewManager.GetPage(httpReq, model); // Response DTO
            //NEW
            //Added httpReq and model to the following method
            var razorPage = this._viewManager.GetPageByName(httpReq.OperationName, httpReq, model)
                         ?? this._viewManager.GetPage(httpReq, model); // Response DTO
            return razorPage;
        }
        
        // MUST OVERRIDE IN ORDER TO GET ACCESS TO FindRazorPage METHOD
        // Change FindRazorPage in Core and this region can all go away
        #region Temporary Overrides
        public override bool ProcessRequest(IHttpRequest httpReq, IHttpResponse httpRes, object dto)
        {
            //for compatibility
            var httpResult = dto as IHttpResult;
            if (httpResult != null)
                dto = httpResult.Response;

            var existingRazorPage = FindRazorPage(httpReq, dto);
            if (existingRazorPage == null)
            {
                return false;
            }

            ResolveAndExecuteRazorPage(httpReq, httpRes, dto, existingRazorPage);

            httpRes.EndServiceStackRequest();
            return true;
        }

        // MUST OVERRIDE IN ORDER TO GET ACCESS TO FindRazorPage METHOD
        public new IRazorView ResolveAndExecuteRazorPage(IHttpRequest httpReq, IHttpResponse httpRes, object model, RazorPage razorPage = null)
        {
            razorPage = razorPage ?? FindRazorPage(httpReq, model);

            if (razorPage == null)
            {
                httpRes.StatusCode = (int)HttpStatusCode.NotFound;
                return null;
            }

            using (var writer = new StreamWriter(httpRes.OutputStream, UTF8EncodingWithoutBom))
            {
                var page = CreateRazorPageInstance(httpReq, httpRes, model, razorPage);

                var includeLayout = !(httpReq.GetParam(QueryStringFormatKey) ?? "").Contains(NoTemplateFormatValue);
                if (includeLayout)
                {
                    var result = ExecuteRazorPageWithLayout(httpReq, httpRes, model, page, () =>
                    {
                        return httpReq.GetItem(LayoutKey) as string
                                       ?? page.Layout
                                       ?? DefaultLayoutName;
                    });

                    writer.Write(result.Item2);
                    return result.Item1;
                }

                page.WriteTo(writer);
                return page;
            }
        }

        private Tuple<IRazorView, string> ExecuteRazorPageWithLayout(IHttpRequest httpReq, IHttpResponse httpRes, object model, IRazorView page, Func<string> layout)
        {
            using (var ms = new MemoryStream())
            {
                using (var childWriter = new StreamWriter(ms, UTF8EncodingWithoutBom))
                {
                    //child page needs to execute before master template to populate ViewBags, sections, etc
                    page.WriteTo(childWriter);
                    var childBody = ms.ToArray().FromUtf8Bytes();

                    var layoutName = layout();
                    if (!String.IsNullOrEmpty(layoutName))
                    {
                        var layoutPage = this._viewManager.GetPageByName(layoutName, httpReq, model);
                        if (layoutPage != null)
                        {
                            var layoutView = CreateRazorPageInstance(httpReq, httpRes, model, layoutPage);
                            layoutView.SetChildPage(page, childBody);
                            return ExecuteRazorPageWithLayout(httpReq, httpRes, model, layoutView, () => layoutView.Layout);
                        }
                    }

                    return Tuple.Create(page, childBody);
                }
            }
        }

        public new void EnsureCompiled(RazorPage page, IHttpResponse response)
        {
            if (page == null) return;
            if (page.IsValid) return;

            var type = page.PageHost.Compile();

            page.PageType = type;

            page.IsValid = true;
        }

        private IRazorView CreateRazorPageInstance(IHttpRequest httpReq, IHttpResponse httpRes, object dto, RazorPage razorPage)
        {
            EnsureCompiled(razorPage, httpRes);

            //don't proceed any further, the background compiler found there was a problem compiling the page, so throw instead
            if (razorPage.CompileException != null)
            {
                throw razorPage.CompileException;
            }

            //else, EnsureCompiled() ensures we have a page type to work with so, create an instance of the page
            var page = (IRazorView)razorPage.ActivateInstance();

            page.Init(viewEngine: this, httpReq: httpReq, httpRes: httpRes);

            //deserialize the model.
            PrepareAndSetModel(page, httpReq, dto);

            return page;
        }

        private void PrepareAndSetModel(IRazorView page, IHttpRequest httpReq, object dto)
        {
            var hasModel = page as IHasModel;
            if (hasModel == null) return;

            if (hasModel.ModelType == typeof(DynamicRequestObject))
                dto = new DynamicRequestObject(httpReq, dto);

            var model = dto ?? DeserializeHttpRequest(hasModel.ModelType, httpReq, httpReq.ContentType);

            if (model.GetType().IsAnonymousType())
            {
                model = new DynamicRequestObject(httpReq, model);
            }

            hasModel.SetModel(model);
        }

        private static readonly UTF8Encoding UTF8EncodingWithoutBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
        #endregion
    }
}
 