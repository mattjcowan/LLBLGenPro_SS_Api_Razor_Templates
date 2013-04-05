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
    public class FilterQueryTests: ServiceTestBase
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
            var client = base.NewJsonServiceClient(false);

            var filter1 = "description:lk:*and*";
            var response1 = client.Get(new CategoryQueryCollectionRequest { Select = "categoryid", Filter = filter1});
            var categoryIds1 = response1.Result.Select(c => c.CategoryId).ToArray();

            var filter2 = "categoryname:eq:condiments";
            var response2 = client.Get(new CategoryQueryCollectionRequest { Select = "categoryid", Filter = filter2 });
            var categoryIds2 = response2.Result.Select(c => c.CategoryId).ToArray();

            var filter3 = "categoryname:neq:beverages";
            var response3 = client.Get(new CategoryQueryCollectionRequest { Select = "categoryid", Filter = filter3 });
            var categoryIds3 = response3.Result.Select(c => c.CategoryId).ToArray();

            var filter4 = "(|(" + filter1 + ")(^(" + filter2 + ")(" + filter3 + ")))";
            var response4 = client.Get(new CategoryQueryCollectionRequest { Select = "categoryid", Filter = filter4 });
            var categoryIds4 = response4.Result.Select(c => c.CategoryId).ToArray();

            Assert.That(categoryIds1.Length, Is.Positive);
            Assert.That(categoryIds2.Length, Is.Positive);
            Assert.That(categoryIds3.Length, Is.Positive);
            Assert.That(categoryIds4.Length, Is.Positive);

            var commonCats23 = categoryIds2.Where(categoryIds3.Contains).ToArray();

            //Only meaningful IF 2 clauses in OR have items NOT in common
            Assert.That(categoryIds1.All(categoryIds4.Contains), Is.True);

            // categoryIds4 should have all items in categoryIds1 
            // categoryIds4 should have all items that are in both categoryIds2 and categoryIds3
            Assert.That(categoryIds1.All(categoryIds4.Contains), Is.True);
            Assert.That(commonCats23.All(categoryIds4.Contains), Is.True);
        }
    }
}
