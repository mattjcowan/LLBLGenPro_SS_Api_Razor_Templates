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
    public class IncludeQueryTests: ServiceTestBase
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
            var client = base.NewJsonServiceClient(false);
            var response = client.Get(new CustomerQueryCollectionRequest { Include = "orders" });

            Assert.That(response, Is.Not.Null);
            Assert.That(response.ResponseStatus, Is.Null);

            var entities = response.Result;
            Assert.That(entities, Is.Not.Null);
            Assert.That(entities.Count, Is.Positive);

            var hasEntitiesWithOrders = entities.Any(c => c.Orders != null && c.Orders.Count > 0);
            Assert.That(hasEntitiesWithOrders, Is.True);
        }

        [Test]
        public void Can_GET_product_using_pk_with_related_all()
        {
            var client = base.NewJsonServiceClient(false);
            var response = client.Get(new ProductQueryCollectionRequest { Include = "category,supplier,orderdetails" });
            var product = response.Result.First(p => p.Category != null && p.Supplier != null && p.OrderDetails.Count > 0);

            var response2 = client.Get(new ProductPkRequest { ProductId = product.ProductId, Include = "category,supplier,orderdetails" });
            var product2 = response2.Result;

            Assert.That(product.ProductId, Is.EqualTo(product2.ProductId));
            Assert.That(product2.Category, Is.Not.Null);
            Assert.That(product2.Supplier, Is.Not.Null);
            Assert.That(product2.OrderDetails.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Can_GET_product_using_uniqueconstraint_with_related_all()
        {
            var client = base.NewJsonServiceClient(false);
            var response = client.Get(new ProductQueryCollectionRequest { Include = "category,supplier,orderdetails" });
            var product = response.Result.First(p => p.Category != null && p.Supplier != null && p.OrderDetails.Count > 0);

            var response2 = client.Get(new ProductUcProductNameRequest { ProductName = product.ProductName, Include = "category,supplier,orderdetails" });
            var product2 = response2.Result;

            Assert.That(product.ProductId, Is.EqualTo(product2.ProductId));
            Assert.That(product2.Category, Is.Not.Null);
            Assert.That(product2.Supplier, Is.Not.Null);
            Assert.That(product2.OrderDetails.Count, Is.GreaterThan(0));
        }
    }
}
