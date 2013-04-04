using ServiceStack.Service;
using ServiceStack.ServiceClient.Web;

namespace Northwind.Data.Services.Tests.ServicesTests
{
    public abstract class ServiceTestBase
    {
        public string BaseUri { get { return Config.ServiceStackBaseUri.TrimEnd('/'); } }

        public virtual void OnBeforeEachTest()
        {
        }

        public virtual void OnAfterEachTest()
        {
        }

        internal IRestClient NewJsonServiceClient(bool authenticate = false)
        {
            var client = new JsonServiceClient(Config.ServiceStackBaseUri);
            if (authenticate)
            {
                // do basic auth
                client.UserName = "admin";
                client.Password = "admin";
            }
            return client;
        }
    }
}
