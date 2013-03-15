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
    public class IncludeQueryTests: RestServiceTestBase
    {
        [SetUp]
        public override void OnBeforeEachTest()
        {
            base.OnBeforeEachTest();

            // initialize some data here
        }

        [Test]
        public void Can_GET_customers_with_orders()
        {
            var response = ExecutePath<CustomerCollectionResponse>(HttpMethods.Get, "/customers?include=orders", new CustomerQueryCollectionRequest());
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Status, Is.Not.Null);
            Assert.That(response.Status.Message, Is.EqualTo("Success"));

            var entities = response.Result;
            Assert.That(entities, Is.Not.Null);
            Assert.That(entities.Count, Is.Positive);

            var hasEntitiesWithOrders = entities.Any(c => c.Orders != null && c.Orders.Count > 0);
            Assert.That(hasEntitiesWithOrders, Is.True);
        }

        [Test]
        public void Can_GET_product_using_pk_with_related_all()
        {
            var response = ExecutePath<ProductCollectionResponse>(HttpMethods.Get, "/products?include=category,supplier,orderdetails", new ProductQueryCollectionRequest());
            var product = response.Result.First(p => p.Category != null && p.Supplier != null && p.OrderDetails.Count > 0);

            var response2 = ExecutePath<ProductResponse>(HttpMethods.Get, "/products/{0}?include=category,supplier,orderdetails".FormatWith(product.ProductId), null);
            var product2 = response2.Result;

            Assert.That(product.ProductId, Is.EqualTo(product2.ProductId));
            Assert.That(product2.Category, Is.Not.Null);
            Assert.That(product2.Supplier, Is.Not.Null);
            Assert.That(product2.OrderDetails.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Can_GET_product_using_uniqueconstraint_with_related_all()
        {
            var response = ExecutePath<ProductCollectionResponse>(HttpMethods.Get, "/products?include=category,supplier,orderdetails", new ProductQueryCollectionRequest());
            var product = response.Result.First(p => p.Category != null && p.Supplier != null && p.OrderDetails.Count > 0);

            var response2 = ExecutePath<ProductResponse>(HttpMethods.Get, "/products/uc/productname/{0}?include=category,supplier,orderdetails".FormatWith(product.ProductName), null);
            var product2 = response2.Result;

            Assert.That(product.ProductId, Is.EqualTo(product2.ProductId));
            Assert.That(product2.Category, Is.Not.Null);
            Assert.That(product2.Supplier, Is.Not.Null);
            Assert.That(product2.OrderDetails.Count, Is.GreaterThan(0));
        }
    }
}
