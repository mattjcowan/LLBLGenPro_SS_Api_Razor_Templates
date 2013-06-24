using System;
using System.Linq;
using System.Net;
using ServiceStack.Common.Web;
using ServiceStack.Razor.Managers;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints.Extensions;
using ServiceStack.WebHost.Endpoints.Support;
using ServiceStack.Razor;

namespace Northwind.Data.Razor
{
    public class CmsRazorHandler : EndpointHandlerBase
    {
        public RazorFormat RazorFormat { get; set; }
        public RazorPage RazorPage { get; set; }
        public object Model { get; set; }

        public string PathInfo { get; set; }

        public CmsRazorHandler(string pathInfo)
        {
            PathInfo = pathInfo;
        }

        public override void ProcessRequest(IHttpRequest httpReq, IHttpResponse httpRes, string operationName)
        {
            httpRes.ContentType = ContentType.Html;
            if (RazorFormat == null)
                RazorFormat = RazorFormat.Instance;

            RazorPage contentPage;
            if (RazorFormat is CmsRazorFormat)
            {
                var cmsRazorFormat = (RazorFormat as CmsRazorFormat);
                contentPage = RazorPage ?? cmsRazorFormat.GetPageByPathInfo(PathInfo, httpReq);
                if (contentPage == null) // also search the views directories
                {
                    // Search for the item in the views before you give up!!!
                    var pageName = PathInfo.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries).Last();
                    contentPage = cmsRazorFormat.GetPageByName(pageName, httpReq, null);
                }
            }
            else
            {
                contentPage = RazorPage ?? RazorFormat.FindByPathInfo(PathInfo);
            }

            if (contentPage == null)
            {
                httpRes.StatusCode = (int) HttpStatusCode.NotFound;
                httpRes.EndHttpRequest();
                return;
            }

            var model = Model;
            if (model == null)
                httpReq.Items.TryGetValue("Model", out model);
            if (model == null)
            {
                var modelType = RazorPage != null ? RazorPage.ModelType : null;
                model = modelType == null || modelType == typeof(DynamicRequestObject)
                    ? null
                    : DeserializeHttpRequest(modelType, httpReq, httpReq.ContentType);
            }

            RazorFormat.ProcessRazorPage(httpReq, contentPage, model, httpRes);
        }

        public override object CreateRequest(IHttpRequest request, string operationName)
        {
            return null;
        }

        public override object GetResponse(IHttpRequest httpReq, IHttpResponse httpRes, object request)
        {
            return null;
        }
    }
} 
