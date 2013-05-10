using System;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
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
using ServiceStack.ServiceInterface.Validation;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Northwind.Data;
using Northwind.Data.DatabaseSpecific;
using Northwind.Data.Dtos;
using Northwind.Data.ServiceInterfaces;
using TLSI = Northwind.Data.ServiceInterfaces.TypedListServiceInterfaces;
using TVSI = Northwind.Data.ServiceInterfaces.TypedViewServiceInterfaces;
using Northwind.Data.ServiceRepositories;
using TLSR = Northwind.Data.ServiceRepositories.TypedListServiceRepositories;
using TVSR = Northwind.Data.ServiceRepositories.TypedViewServiceRepositories;

namespace Northwind.Data.ConsoleHost
{
    class Program
    {
          static void Main(string[] args)
          {
              var listeningOn = args.Length == 0 ? "http://*:1337/" : args[0];
              var appHost = new ConsoleAppHost();
              appHost.Init();
              appHost.Start(listeningOn);

              Console.WriteLine("----------------------------------------------------------------------------");
              Console.WriteLine("Northwind.Data API");
              Console.WriteLine("  - Host started at {0}", DateTime.Now);
              Console.WriteLine("  - Host listening on {0}", listeningOn);
              Console.WriteLine("----------------------------------------------------------------------------");
              Console.WriteLine("");

              "Type Ctrl+C to quit..".Print();
              Thread.Sleep(Timeout.Infinite);

              appHost.Stop();
              appHost.Dispose();

              Console.WriteLine("Host has stopped");
              Console.WriteLine("");
          }
    }

    // A sample implementation of a self-hosted application to quickly get up and running with hosting the 
    // code-generated API ... See the ServiceStack documentation at https://github.com/ServiceStack/ServiceStack/wiki
    // for more detailed information on the various options you can set for hosting the API.
    class ConsoleAppHost : AppHostHttpListenerBase
    {
        public ConsoleAppHost() : base("Northwind.Data API (updated on 5/10/2013 1:09:34 AM)", typeof(CommonDtoBase).Assembly) { }

        // THIS IS TO SIMULATE AUTHENTICATION
        private const string UserName = "admin";
        private const string Password = "admin";

        private static InMemoryAuthRepository userRepository;

        public override void Configure(Funq.Container container)
        {
            JsConfig.EmitCamelCaseNames = true;
            JsConfig.IncludeNullValues = true;
            JsConfig.DateHandler = JsonDateHandler.ISO8601;

            LogManager.LogFactory = new ConsoleLogFactory();

            SetConfig(new EndpointHostConfig
                {
                    WsdlServiceNamespace = "",
                    AllowJsonpRequests = true,
                    DebugMode = true,
                    EnableFeatures = Feature.All.Remove(GetDisabledFeatures()),
                    CustomHttpHandlers = {
                        { HttpStatusCode.NotFound, new RazorHandler("/notfound") }
                    }
                });

            //Authentication (see: https://github.com/ServiceStack/ServiceStack/blob/master/tests/ServiceStack.WebHost.Endpoints.Tests/AuthTests.cs)
            Plugins.Add(new AuthFeature(() => new AuthUserSession(), 
                new IAuthProvider[] {
                  new BasicAuthProvider(), //Sign-in with Basic Auth
                }){ HtmlRedirect = null /* prevent redirect to login page, make the user login using basic auth prompt */ });
            userRepository = new InMemoryAuthRepository();
            container.Register<IUserAuthRepository>(userRepository);
            CreateUser(userRepository, 1, UserName, "DisplayName", null, Password);

            //Enable the validation feature and scan the service assembly for validators
            Plugins.Add(new ValidationFeature());
            container.RegisterValidators(typeof(Northwind.Data.Services.CategoryService).Assembly);

            //Razor
            Plugins.Add(new RazorFormat());

            //Caching
            container.Register<ICacheClient>(new MemoryCacheClient());
      
            //Entity Repositories
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
      
            //TypedList Repositories
            container.RegisterAs<TLSR.EmployeesByRegionAndTerritoryTypedListServiceRepository, TLSI.IEmployeesByRegionAndTerritoryTypedListServiceRepository>();
      
            //TypedView Repositories
            container.RegisterAs<TVSR.AlphabeticalListOfProductsTypedViewServiceRepository, TVSI.IAlphabeticalListOfProductsTypedViewServiceRepository>();
            container.RegisterAs<TVSR.CategorySalesFor1997TypedViewServiceRepository, TVSI.ICategorySalesFor1997TypedViewServiceRepository>();
            container.RegisterAs<TVSR.CurrentProductListTypedViewServiceRepository, TVSI.ICurrentProductListTypedViewServiceRepository>();
            container.RegisterAs<TVSR.CustomerAndSuppliersByCityTypedViewServiceRepository, TVSI.ICustomerAndSuppliersByCityTypedViewServiceRepository>();
            container.RegisterAs<TVSR.InvoicesTypedViewServiceRepository, TVSI.IInvoicesTypedViewServiceRepository>();
            container.RegisterAs<TVSR.OrderDetailsExtendedTypedViewServiceRepository, TVSI.IOrderDetailsExtendedTypedViewServiceRepository>();
            container.RegisterAs<TVSR.OrdersQryTypedViewServiceRepository, TVSI.IOrdersQryTypedViewServiceRepository>();
            container.RegisterAs<TVSR.OrderSubtotalTypedViewServiceRepository, TVSI.IOrderSubtotalTypedViewServiceRepository>();
            container.RegisterAs<TVSR.ProductsAboveAveragePriceTypedViewServiceRepository, TVSI.IProductsAboveAveragePriceTypedViewServiceRepository>();
            container.RegisterAs<TVSR.ProductSalesFor1997TypedViewServiceRepository, TVSI.IProductSalesFor1997TypedViewServiceRepository>();
            container.RegisterAs<TVSR.ProductsByCategoryTypedViewServiceRepository, TVSI.IProductsByCategoryTypedViewServiceRepository>();
            container.RegisterAs<TVSR.QuarterlyOrderTypedViewServiceRepository, TVSI.IQuarterlyOrderTypedViewServiceRepository>();
            container.RegisterAs<TVSR.SalesByCategoryTypedViewServiceRepository, TVSI.ISalesByCategoryTypedViewServiceRepository>();
            container.RegisterAs<TVSR.SalesTotalsByAmountTypedViewServiceRepository, TVSI.ISalesTotalsByAmountTypedViewServiceRepository>();
            container.RegisterAs<TVSR.SummaryOfSalesByQuarterTypedViewServiceRepository, TVSI.ISummaryOfSalesByQuarterTypedViewServiceRepository>();
            container.RegisterAs<TVSR.SummaryOfSalesByYearTypedViewServiceRepository, TVSI.ISummaryOfSalesByYearTypedViewServiceRepository>();

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
  
    public class DataAccessAdapterFactory: IDataAccessAdapterFactory 
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
                new DataAccessAdapter(null, false, SchemaNameUsage.Clear, null):
                new DataAccessAdapter(_connectionString, false, SchemaNameUsage.Clear, null);
            adapter.CatalogNameUsageSetting = CatalogNameUsage.Clear;
            return adapter;
        }
    }

    public static class MvcExtensions
    {
        public static MvcHtmlString TitleCase(this ServiceStack.Html.HtmlHelper helper, string text)
        {
            return MvcHtmlString.Create(Regex.Replace(text, "([A-Z]{1,2}|[0-9]+)", " $1").TrimStart());
        }
        public static MvcHtmlString DataTableAjaxUrl(this ServiceStack.Html.HtmlHelper helper, string ajaxBaseUri)
        {
            var url = string.Format("{0}{1}", ajaxBaseUri, HttpUtility.UrlDecode(new Uri(helper.HttpRequest.AbsoluteUri).Query));
            return MvcHtmlString.Create(url);
        }
    }
}
