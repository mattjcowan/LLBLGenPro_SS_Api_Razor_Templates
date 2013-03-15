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
    public class SortQueryTests: RestServiceTestBase
    {
        [SetUp]
        public override void OnBeforeEachTest()
        {
            base.OnBeforeEachTest();

            // initialize some data here
        }

        [Test]
        public void Can_GET_customers_sorted()
        {
            var response = ExecutePath<CustomerCollectionResponse>(HttpMethods.Get, "/customers?sort=companyname:asc", new CustomerQueryCollectionRequest());
            var response2 = ExecutePath<CustomerCollectionResponse>(HttpMethods.Get, "/customers?sort=companyname:desc", new CustomerQueryCollectionRequest());

            Assert.That(response, Is.Not.Null);
            Assert.That(response2, Is.Not.Null);
            Assert.That(response.Result, Is.Not.Null);
            Assert.That(response2.Result, Is.Not.Null);
            Assert.That(response.Result.Count, Is.EqualTo(response2.Result.Count));

            Assert.That(response.Result.First().CustomerId, Is.Not.EqualTo(response2.Result.First().CustomerId));
        }
    }
}
