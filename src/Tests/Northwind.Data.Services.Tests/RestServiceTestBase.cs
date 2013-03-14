using System;
using System.Configuration;
using System.IO;
using System.Net;
using NUnit.Framework;
using Northwind.Data.DatabaseSpecific;
using Northwind.Data.Dtos;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.ServiceRepositories;
using SD.LLBLGen.Pro.ORMSupportClasses;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Common.Web;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.ServiceInterface.Testing;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace Northwind.Data.Services.Tests
{
    public class RestServiceTestBase: TestBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (RestServiceTestBase));

        readonly EndpointHostConfig defaultConfig = new EndpointHostConfig();

        public RestServiceTestBase()
            : base(Config.ServiceStackBaseUri, typeof(CommonDtoBase).Assembly)
        {
        }

        protected override void Configure(Funq.Container container)
        {

            //Caching
            container.Register<ICacheClient>(new MemoryCacheClient());

            //Repositories
            container.RegisterAs<CategoryServiceRepository, ICategoryServiceRepository>();
            container.RegisterAs<CustomerServiceRepository, ICustomerServiceRepository>();
            container.RegisterAs<CustomerCustomerDemoServiceRepository, ICustomerCustomerDemoServiceRepository>();
            container.RegisterAs<CustomerDemographicServiceRepository, ICustomerDemographicServiceRepository>();
            container.RegisterAs<EmployeeServiceRepository, IEmployeeServiceRepository>();
            container.RegisterAs<EmployeeTerritoryServiceRepository, IEmployeeTerritoryServiceRepository>();
            container.RegisterAs<OrderServiceRepository, IOrderServiceRepository>();
            container.RegisterAs<OrderDetailServiceRepository, IOrderDetailServiceRepository>();
            container.RegisterAs<ProductServiceRepository, IProductServiceRepository>();
            container.RegisterAs<RegionServiceRepository, IRegionServiceRepository>();
            container.RegisterAs<ShipperServiceRepository, IShipperServiceRepository>();
            container.RegisterAs<SupplierServiceRepository, ISupplierServiceRepository>();
            container.RegisterAs<TerritoryServiceRepository, ITerritoryServiceRepository>();

            //DataAccess / OrmLite
            var connectionString = ConfigurationManager.ConnectionStrings["ApiDbConnectionString"].ConnectionString;
            container.Register<IDataAccessAdapterFactory>(c => new DataAccessAdapterFactory(connectionString));
            container.Register<IDbConnectionFactory>(
                c => new OrmLiteConnectionFactory(connectionString, true, new SqlServerOrmLiteDialectProvider()));
        }

        public HttpWebResponse GetWebResponse(string uri, string acceptContentTypes)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.Accept = acceptContentTypes;
            return (HttpWebResponse)webRequest.GetResponse();
        }

        public static HttpWebResponse GetWebResponse(string httpMethod, string uri, string contentType, int contentLength)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.Accept = contentType;
            webRequest.ContentType = contentType;
            webRequest.Method = HttpMethods.Post;
            webRequest.ContentLength = contentLength;
            return (HttpWebResponse)webRequest.GetResponse();
        }

        public static string GetContents(WebResponse webResponse)
        {
            using (var stream = webResponse.GetResponseStream())
            {
                var contents = new StreamReader(stream).ReadToEnd();
                return contents;
            }
        }

        public T DeserializeContents<T>(WebResponse webResponse)
        {
            var contentType = webResponse.ContentType ?? defaultConfig.DefaultContentType;
            return DeserializeContents<T>(webResponse, contentType);
        }

        private static T DeserializeContents<T>(WebResponse webResponse, string contentType)
        {
            try
            {
                var contents = GetContents(webResponse);
                var result = DeserializeResult<T>(webResponse, contents, contentType);
                return result;
            }
            catch (WebException webEx)
            {
                if (webEx.Status == WebExceptionStatus.ProtocolError)
                {
                    var errorResponse = ((HttpWebResponse)webEx.Response);
                    Log.Error(webEx);
                    Log.DebugFormat("Status Code : {0}", errorResponse.StatusCode);
                    Log.DebugFormat("Status Description : {0}", errorResponse.StatusDescription);

                    try
                    {
                        using (var stream = errorResponse.GetResponseStream())
                        {
                            var response = HttpResponseFilter.Instance.DeserializeFromStream(contentType, typeof(T), stream);
                            return (T)response;
                        }
                    }
                    catch (WebException)
                    {
                        // Oh, well, we tried
                        throw;
                    }
                }

                throw;
            }
        }

        public void AssertResponse(HttpWebResponse response, string contentType)
        {
            var statusCode = (int)response.StatusCode;
            Assert.That(statusCode, Is.LessThan(400));
            Assert.That(response.ContentType.StartsWith(contentType));
        }

        public void AssertErrorResponse<T>(HttpWebResponse webResponse, HttpStatusCode statusCode, Func<T, ResponseStatus> responseStatusFn)
        {
            Assert.That(webResponse.StatusCode, Is.EqualTo(statusCode));
            var response = DeserializeContents<T>(webResponse);
            Assert.That(responseStatusFn(response).ErrorCode, Is.Not.Null);
        }

        public void AssertErrorResponse<T>(HttpWebResponse webResponse, HttpStatusCode statusCode, Func<T, ResponseStatus> responseStatusFn, string errorCode)
        {
            Assert.That(webResponse.StatusCode, Is.EqualTo(statusCode));
            var response = DeserializeContents<T>(webResponse);
            Assert.That(responseStatusFn(response).ErrorCode, Is.EqualTo(errorCode));
        }

        public void AssertErrorResponse<T>(HttpWebResponse webResponse, HttpStatusCode statusCode)
            where T : IHasResponseStatus
        {
            Assert.That(webResponse.StatusCode, Is.EqualTo(statusCode));
            var response = DeserializeContents<T>(webResponse);
            Assert.That(response.ResponseStatus.ErrorCode, Is.Not.Null);
        }

        public void AssertErrorResponse<T>(HttpWebResponse webResponse, HttpStatusCode statusCode, string errorCode)
            where T : IHasResponseStatus
        {
            Assert.That(webResponse.StatusCode, Is.EqualTo(statusCode));
            var response = DeserializeContents<T>(webResponse);
            Assert.That(response.ResponseStatus.ErrorCode, Is.EqualTo(errorCode));
        }

        public void AssertResponse<T>(HttpWebResponse response, Action<T> customAssert)
        {
            var contentType = response.ContentType ?? defaultConfig.DefaultContentType;

            AssertResponse(response, contentType);

            var result = DeserializeContents<T>(response, contentType);

            customAssert(result);
        }

        public void AssertResponse<T>(HttpWebResponse response, string contentType, Action<T> customAssert)
        {
            contentType = contentType ?? defaultConfig.DefaultContentType;

            AssertResponse(response, contentType);

            var result = DeserializeContents<T>(response, contentType);

            customAssert(result);
        }

        private static T DeserializeResult<T>(WebResponse response, string contents, string contentType)
        {
            T result;
            switch (contentType)
            {
                case ContentType.Xml:
                    result = XmlSerializer.DeserializeFromString<T>(contents);
                    break;

                case ContentType.Json:
                case ContentType.Json + ContentType.Utf8Suffix:
                    result = JsonSerializer.DeserializeFromString<T>(contents);
                    break;

                case ContentType.Jsv:
                    result = TypeSerializer.DeserializeFromString<T>(contents);
                    break;

                default:
                    throw new NotSupportedException(response.ContentType);
            }
            return result;
        }

    }

    public class DataAccessAdapterFactory : IDataAccessAdapterFactory
    {
        private readonly string _connectionString;
        public DataAccessAdapterFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDataAccessAdapter NewDataAccessAdapter()
        {
            // Make any change you want here to configure and return an appropriate 
            // DataAccessAdapter object
            var adapter = string.IsNullOrEmpty(_connectionString) ?
                new DataAccessAdapter(null, false, SchemaNameUsage.Clear, null) :
                new DataAccessAdapter(_connectionString, false, SchemaNameUsage.Clear, null);
            adapter.CatalogNameUsageSetting = CatalogNameUsage.Clear;
            return adapter;
        }
    }
}
