using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class FilterQueryTests: RestServiceTestBase
    {
        [SetUp]
        public override void OnBeforeEachTest()
        {
            base.OnBeforeEachTest();

            // initialize some data here
        }

        [Test]
        public void Can_GET_categories_with_compound_filter()
        {
            var filter1 = "description:lk:*and*";
            var response1 = ExecutePath<CategoryCollectionResponse>(HttpMethods.Get, "/categories?select=categoryid&filter=" + filter1, new CategoryQueryCollectionRequest());
            var categoryIds1 = response1.Result.Select(c => c.CategoryId).ToArray();
            //Trace.WriteLine("categoryIds1: " + JsonSerializer.SerializeToString(categoryIds1));

            var filter2 = "categoryname:eq:condiments";
            var response2 = ExecutePath<CategoryCollectionResponse>(HttpMethods.Get, "/categories?select=categoryid&filter=" + filter2, new CategoryQueryCollectionRequest());
            var categoryIds2 = response2.Result.Select(c => c.CategoryId).ToArray();
            //Trace.WriteLine("categoryIds2: " + JsonSerializer.SerializeToString(categoryIds2));

            var filter3 = "categoryname:neq:beverages";
            var response3 = ExecutePath<CategoryCollectionResponse>(HttpMethods.Get, "/categories?select=categoryid&filter=" + filter3, new CategoryQueryCollectionRequest());
            var categoryIds3 = response3.Result.Select(c => c.CategoryId).ToArray();
            //Trace.WriteLine("categoryIds3: " + JsonSerializer.SerializeToString(categoryIds3));

            var filter4 = "(|(" + filter1 + ")(^(" + filter2 + ")(" + filter3 + ")))";
            var response4 = ExecutePath<CategoryCollectionResponse>(HttpMethods.Get, "/categories?select=categoryid&filter=" + filter4, new CategoryQueryCollectionRequest());
            var categoryIds4 = response4.Result.Select(c => c.CategoryId).ToArray();
            //Trace.WriteLine("categoryIds4: " + JsonSerializer.SerializeToString(categoryIds4));

            Assert.That(categoryIds1.Length, Is.Positive);
            Assert.That(categoryIds2.Length, Is.Positive);
            Assert.That(categoryIds3.Length, Is.Positive);
            Assert.That(categoryIds4.Length, Is.Positive);

            var commonCats23 = categoryIds2.Where(categoryIds3.Contains).ToArray();
            //Trace.WriteLine("commonCats23: " + JsonSerializer.SerializeToString(commonCats23));

            //Only meaningful IF 2 clauses in OR have items NOT in common
            Assert.That(categoryIds1.All(categoryIds4.Contains), Is.True);

            // categoryIds4 should have all items in categoryIds1 
            // categoryIds4 should have all items that are in both categoryIds2 and categoryIds3
            Assert.That(categoryIds1.All(categoryIds4.Contains), Is.True);
            Assert.That(commonCats23.All(categoryIds4.Contains), Is.True);
        }
    }
}
