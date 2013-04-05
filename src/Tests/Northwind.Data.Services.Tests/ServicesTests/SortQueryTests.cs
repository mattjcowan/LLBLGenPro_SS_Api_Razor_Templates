using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ServiceStack.Common.Web;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using DTOs = Northwind.Data.Services;

namespace Northwind.Data.Services.Tests.ServicesTests
{
    [TestFixture]
    public class SortQueryTests : ServiceTestBase
    {
        [SetUp]
        public override void OnBeforeEachTest()
        {
            base.OnBeforeEachTest();

            // initialize some data here
        }

        [Test]
        public void Can_GET_customers_sorted_with_typed_api()
        {
            var client = base.NewJsonServiceClient(false);
            var response = client.Get(new CustomerQueryCollectionRequest { Sort = "companyname:asc" });
            var response2 = client.Get(new CustomerQueryCollectionRequest { Sort = "companyname:desc" });

            Assert.That(response, Is.Not.Null);
            Assert.That(response2, Is.Not.Null);
            Assert.That(response.Result, Is.Not.Null);
            Assert.That(response2.Result, Is.Not.Null);
            Assert.That(response.Result.Count, Is.EqualTo(response2.Result.Count));

            Assert.That(response.Result.First().CustomerId, Is.Not.EqualTo(response2.Result.First().CustomerId));
        }

        [Test]
        public void Can_GET_customers_sorted_with_untyped_api()
        {
            var responseStr1 = (base.BaseUri + "/customers?sort=companyname").GetJsonFromUrl();
            var responseStr2 = (base.BaseUri + "/customers?sort=companyname:desc").GetJsonFromUrl();

            // to parse, you can either use JsonObject (when you have no access to a typed api), or deserialize to a compatible class
            var response = JsonSerializer.DeserializeFromString<CustomerCollectionResponse>(responseStr1);
            var response2 = JsonSerializer.DeserializeFromString<CustomerCollectionResponse>(responseStr2);

            Assert.That(response, Is.Not.Null);
            Assert.That(response2, Is.Not.Null);
            Assert.That(response.Result, Is.Not.Null);
            Assert.That(response2.Result, Is.Not.Null);
            Assert.That(response.Result.Count, Is.EqualTo(response2.Result.Count));

            Assert.That(response.Result.First().CustomerId, Is.Not.EqualTo(response2.Result.First().CustomerId));
        }
    }
}
