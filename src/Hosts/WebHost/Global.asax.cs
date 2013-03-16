using System;
using System.Configuration;
using System.Net;
using System.Web;
using SD.LLBLGen.Pro.ORMSupportClasses;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Common;
using ServiceStack.Html;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.Razor;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;
using Northwind.Data;
using Northwind.Data.DatabaseSpecific;
using Northwind.Data.Dtos;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.ServiceRepositories;

namespace WebHost
{
    public class Global : System.Web.HttpApplication
    {
        private WebAppHost _appHost;
        protected void Application_Start(object sender, EventArgs e)
        {
            _appHost = new WebAppHost();
            _appHost.Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            _appHost.Dispose();
        }
    }

    // A sample implementation of a self-hosted application to quickly get up and running with hosting the 
    // code-generated API ... See the ServiceStack documentation at https://github.com/ServiceStack/ServiceStack/wiki
    // for more detailed information on the various options you can set for hosting the API.
    public class WebAppHost : AppHostBase
    {
        public WebAppHost()
            : base("Northwind.Data API (updated on 3/8/2013 12:39:32 PM)",
                typeof(CommonDtoBase).Assembly) { }

        // THIS IS TO SIMULATE AUTHENTICATION
        private static readonly string UserName = System.Configuration.ConfigurationManager.AppSettings["BasicAuthUsername"];
        private static readonly string Password = System.Configuration.ConfigurationManager.AppSettings["BasicAuthPassword"];

        private static InMemoryAuthRepository userRepository;

        public override void Configure(Funq.Container container)
        {
            JsConfig.EmitCamelCaseNames = true;
            JsConfig.IncludeNullValues = true;
            JsConfig.DateHandler = JsonDateHandler.ISO8601;

            //            LogManager.LogFactory = new ServiceStack.Logging.Support.Logging.ConsoleLogFactory();
            //            LogManager.LogFactory = new ServiceStack.Logging.Log4Net.Log4NetFactory("log4net.config");
            var log4NetFactory = new ServiceStack.Logging.Log4Net.Log4NetFactory("log4net.config");
            LogManager.LogFactory = new ServiceStack.Logging.Elmah.ElmahLogFactory(log4NetFactory);
            //            LogManager.LogFactory = new ServiceStack.Logging.NLogger.NLogFactory();

            SetConfig(new EndpointHostConfig
            {
                AllowJsonpRequests = false,
                DebugMode = false,
                EnableFeatures = Feature.All.Remove(GetDisabledFeatures()),
                CustomHttpHandlers = {
                        { HttpStatusCode.NotFound, new RazorHandler("/notfound") }
                    }
            });

            //Authentication (see: https://github.com/ServiceStack/ServiceStack/blob/master/tests/ServiceStack.WebHost.Endpoints.Tests/AuthTests.cs)
            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                new IAuthProvider[] {
                    new BasicAuthProvider(), //Sign-in with Basic Auth
                }) { HtmlRedirect = null });
            userRepository = new InMemoryAuthRepository();
            container.Register<IUserAuthRepository>(userRepository);
            CreateUser(userRepository, 1, UserName, "DisplayName", null, Password);

            //Logging
            container.Register<ILog>(LogManager.GetLogger(typeof(WebAppHost)));

            //Razor
            Plugins.Add(new RazorFormat());

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
            container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(connectionString, true, new SqlServerOrmLiteDialectProvider()));
        }

        private static void CreateUser(IUserAuthRepository repository, int id, string username, string displayName, string email, string password)
        {
            string hash;
            string salt;
            new SaltedHash().GetHashAndSaltString(password, out hash, out salt);

            repository.CreateUserAuth(new UserAuth
            {
                Id = id,
                DisplayName = displayName,
                Email = email ?? "as@if{0}.com".Fmt(id),
                UserName = username,
                FirstName = "FirstName",
                LastName = "LastName",
                PasswordHash = hash,
                Salt = salt,
            }, password);
        }

        private static Feature GetDisabledFeatures()
        {
            var disabled = ConfigurationManager.AppSettings.Get("DisabledFeatures");

            Feature d;
            if (!string.IsNullOrWhiteSpace(disabled)
            && Enum.TryParse(disabled, true, out d))
            {
                return d;
            }
            return Feature.None;
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

    public static class MvcExtensions
    {
        public static MvcHtmlString TitleCase(this ServiceStack.Html.HtmlHelper helper, string text)
        {
            return
                MvcHtmlString.Create(
                    System.Text.RegularExpressions.Regex.Replace(text, "([A-Z]{1,2}|[0-9]+)", " $1").TrimStart());
        }
        public static MvcHtmlString DataTableAjaxUrl(this ServiceStack.Html.HtmlHelper helper, string ajaxBaseUri)
        {
            var url = string.Format("{0}{1}", ajaxBaseUri, HttpUtility.UrlDecode(new Uri(helper.HttpRequest.AbsoluteUri).Query));
            return MvcHtmlString.Create(url);
        }
    }
}