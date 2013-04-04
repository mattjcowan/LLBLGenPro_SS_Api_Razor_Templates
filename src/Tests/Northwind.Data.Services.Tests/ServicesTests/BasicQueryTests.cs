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
    public class BasicQueryTests: RestServiceTestBase
    {
        [SetUp]
        public override void OnBeforeEachTest()
        {
            base.OnBeforeEachTest();

            // initialize some data here
        }

        [Test]
        public void Can_GET_all_categories()
        {
            //See ConnectivityTests for the DTO way to do it
            //Shorthand version of the below
            //var client = new JsonServiceClient(LIVE_URL);
            //var response = client.Get(new CategoryQueryCollectionRequest());

            var response = ExecutePath<CategoryCollectionResponse>(HttpMethods.Get, "/categories", new CategoryQueryCollectionRequest());
            Assert.That(response, Is.Not.Null);
            Assert.That(response.ResponseStatus, Is.Not.Null);
            Assert.That(response.ResponseStatus.Message, Is.EqualTo("Success"));

            var categories = response.Result;
            Assert.That(categories, Is.Not.Null);
            Assert.That(categories.Count, Is.Positive);
        }

        [Test]
        public void Can_GET_category_using_pk()
        {
            var response = ExecutePath<CategoryCollectionResponse>(HttpMethods.Get, "/categories", new CategoryQueryCollectionRequest());
            var category1 = response.Result.First();

            // Shorthand with live site: var response2 = client.Get(new CategoryPkRequest { CategoryId = category1.CategoryId });
            var response2 = ExecutePath<CategoryResponse>(HttpMethods.Get, "/categories/{0}".FormatWith(category1.CategoryId), null);
            var category2 = response2.Result;

            Assert.That(category2.CategoryId, Is.EqualTo(category1.CategoryId));
            Assert.That(category2.CategoryName, Is.EqualTo(category1.CategoryName));
        }

        [Test]
        public void Can_GET_category_using_uniqueconstraint()
        {
            var response = ExecutePath<CategoryCollectionResponse>(HttpMethods.Get, "/categories", new CategoryQueryCollectionRequest());
            var category1 = response.Result.First();

            // Shorthand with live site: var response2 = client.Get(new DTOs.CategoryUcCategoryNameRequest { CategoryName = category1.CategoryName });
            var response2 = ExecutePath<CategoryResponse>(HttpMethods.Get, "/categories/uc/categoryname/{0}".FormatWith(category1.CategoryName), null);
            var category2 = response2.Result;

            Assert.That(category2.CategoryId, Is.EqualTo(category1.CategoryId));
            Assert.That(category2.CategoryName, Is.EqualTo(category1.CategoryName));
        }
    }
}
