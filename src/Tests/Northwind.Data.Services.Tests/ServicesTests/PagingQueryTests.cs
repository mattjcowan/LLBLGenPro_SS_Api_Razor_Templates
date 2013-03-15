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
    public class PagingQueryTests: RestServiceTestBase
    {
        [SetUp]
        public override void OnBeforeEachTest()
        {
            base.OnBeforeEachTest();

            // initialize some data here
        }

        // assume the default northwind dataset
        [Test]
        public void Can_GET_customers_paged()
        {
            var response1 = ExecutePath<CustomerCollectionResponse>(HttpMethods.Get, "/customers?sort=customerid&pageNumber=1&pageSize=5", new CustomerQueryCollectionRequest());
            var response2 = ExecutePath<CustomerCollectionResponse>(HttpMethods.Get, "/customers?sort=customerid&pageNumber=2&pageSize=5", new CustomerQueryCollectionRequest());

            var f1 = response1.Result.First();
            var f2 = response2.Result.First();

            // check paging info
            Assert.That(response1.Result.Count, Is.EqualTo(5));
            Assert.That(response2.Result.Count, Is.EqualTo(5));
            Assert.That(f1.CustomerId, Is.Not.EqualTo(f2.CustomerId));
            Assert.That(f1.CustomerId, Is.LessThan(f2.CustomerId));

            // check returned paging info
            var p1 = response1.Paging;
            var p2 = response2.Paging;
            Assert.That(p1.TotalCount, Is.LessThanOrEqualTo(p1.PageCount * p1.PageSize));
            Assert.That(p1.TotalCount, Is.GreaterThanOrEqualTo((p1.PageCount - 1) * p1.PageSize));
            Assert.That(p1.FirstItemOnPage, Is.EqualTo(1));
            Assert.That(p2.FirstItemOnPage, Is.EqualTo(6));
            Assert.That(p1.LastItemOnPage, Is.EqualTo(5));
            Assert.That(p2.LastItemOnPage, Is.EqualTo(10));
            Assert.That(p1.PageNumber, Is.EqualTo(1));
            Assert.That(p2.PageNumber, Is.EqualTo(2));
            Assert.That(p1.PageSize, Is.EqualTo(5));
            Assert.That(p2.PageSize, Is.EqualTo(5));
            Assert.That(p1.HasNextPage, Is.EqualTo(true));
            Assert.That(p1.IsFirstPage, Is.EqualTo(true));
            Assert.That(p2.HasPreviousPage, Is.EqualTo(true));
            Assert.That(p2.IsFirstPage, Is.EqualTo(false));
            Assert.That(p2.IsLastPage, Is.EqualTo(false));
        }
    }
}
