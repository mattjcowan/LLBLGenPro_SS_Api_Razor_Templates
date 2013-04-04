using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Northwind.Data.DatabaseSpecific;
using Northwind.Data.Dtos;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.ServiceRepositories;
using SD.LLBLGen.Pro.ORMSupportClasses;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Common;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.Validation;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace Northwind.Data.Services.Tests
{
    public class TestAppHost : AppHostHttpListenerBase
    {
        public TestAppHost() : base("Northwind.Data API (updated on 3/16/2013 2:58:24 PM)", typeof(CommonDtoBase).Assembly) { }

        // THIS IS TO SIMULATE AUTHENTICATION
        private const string UserName = "admin";
        private const string Password = "admin";

        private static InMemoryAuthRepository userRepository;

        public override void Configure(Funq.Container container)
        {
            JsConfig.EmitCamelCaseNames = true;
            JsConfig.IncludeNullValues = true;
            JsConfig.DateHandler = JsonDateHandler.ISO8601;

            LogManager.LogFactory = new DebugLogFactory();

            SetConfig(new EndpointHostConfig
            {
                WsdlServiceNamespace = "",
                AllowJsonpRequests = true,
                DebugMode = true,
                EnableFeatures = Feature.All.Remove(GetDisabledFeatures())
            });

            //Authentication (see: https://github.com/ServiceStack/ServiceStack/blob/master/tests/ServiceStack.WebHost.Endpoints.Tests/AuthTests.cs)
            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                new IAuthProvider[] {
                  new BasicAuthProvider(), //Sign-in with Basic Auth
                }) { HtmlRedirect = null /* prevent redirect to login page, make the user login using basic auth prompt */ });
            userRepository = new InMemoryAuthRepository();
            container.Register<IUserAuthRepository>(userRepository);
            CreateUser(userRepository, 1, UserName, "DisplayName", null, Password);

            //NEW: Enable the validation feature and scans the service assembly for validators
            Plugins.Add(new ValidationFeature());
            container.RegisterValidators(typeof(Northwind.Data.Services.CategoryService).Assembly);

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
}
