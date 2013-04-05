using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    public class BasicQueryTests: ServiceTestBase
    {
        [SetUp]
        public override void OnBeforeEachTest()
        {
            base.OnBeforeEachTest();

            // initialize some data here
        }

        [Test]
        public void Can_GET_all_categories_using_url()
        {
            //See ConnectivityTests for the DTO way to do it
            //Shorthand version of the below
            var client = base.NewJsonServiceClient(); 
            var responseStr = (base.BaseUri + "/categories").GetJsonFromUrl();

            // to parse, you can either use JsonObject (when you have no access to a typed api), or deserialize to a compatible class
            var response = JsonSerializer.DeserializeFromString<CategoryCollectionResponse>(responseStr);
  
            Assert.That(response, Is.Not.Null);
            Assert.That(response.ResponseStatus, Is.Null);

            var categories = response.Result;
            Assert.That(categories, Is.Not.Null);
            Assert.That(categories.Count, Is.Positive);
        }

        [Test]
        public void Can_GET_all_categories_using_web_response()
        {
            //See ConnectivityTests for the DTO way to do it
            //Shorthand version of the below
            var client = base.NewJsonServiceClient();
            var webResponse = client.Get<HttpWebResponse>("/categories");

            var dtoStr = string.Empty;
            using (var stream = webResponse.GetResponseStream())
            using (var sr = new StreamReader(stream))
            {
                dtoStr = sr.ReadToEnd();
            }

            // to parse, you can either use JsonObject (when you have no access to a typed api), or deserialize to a compatible class
            var response = JsonSerializer.DeserializeFromString<CategoryCollectionResponse>(dtoStr);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.ResponseStatus, Is.Null);

            var categories = response.Result;
            Assert.That(categories, Is.Not.Null);
            Assert.That(categories.Count, Is.Positive);
        }


        [Test]
        public void Can_GET_all_categories()
        {
            //See ConnectivityTests for the DTO way to do it
            //Shorthand version of the below
            var client = base.NewJsonServiceClient();
            var response = client.Get(new CategoryQueryCollectionRequest());

            Assert.That(response, Is.Not.Null);
            Assert.That(response.ResponseStatus, Is.Null);

            var categories = response.Result;
            Assert.That(categories, Is.Not.Null);
            Assert.That(categories.Count, Is.Positive);
        }

        [Test]
        public void Can_GET_category_using_pk()
        {
            var client = base.NewJsonServiceClient();
            var response = client.Get(new CategoryQueryCollectionRequest());
            var category1 = response.Result.First();

            var response2 = client.Get(new CategoryPkRequest { CategoryId = category1.CategoryId });
            var category2 = response2.Result;

            Assert.That(category2.CategoryId, Is.EqualTo(category1.CategoryId));
            Assert.That(category2.CategoryName, Is.EqualTo(category1.CategoryName));
        }

        [Test]
        public void Can_GET_category_using_uniqueconstraint()
        {

            var client = base.NewJsonServiceClient();
            var response = client.Get(new CategoryQueryCollectionRequest());
            var category1 = response.Result.First();

            var response2 = client.Get(new CategoryUcCategoryNameRequest { CategoryName = category1.CategoryName });
            var category2 = response2.Result;

            Assert.That(category2.CategoryId, Is.EqualTo(category1.CategoryId));
            Assert.That(category2.CategoryName, Is.EqualTo(category1.CategoryName));
        }
    }
}
