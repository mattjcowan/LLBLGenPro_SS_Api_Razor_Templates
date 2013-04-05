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
    public class SelectQueryTests : ServiceTestBase
    {
        [SetUp]
        public override void OnBeforeEachTest()
        {
            base.OnBeforeEachTest();

            // initialize some data here
        }

        [Test]
        public void Can_GET_select_fields_for_categories()
        {
            var client = base.NewJsonServiceClient(false);
            var response = client.Get(new CategoryQueryCollectionRequest { Select = "categoryid,description" });

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Result, Is.Not.Null);
            Assert.That(response.Result.All(c => string.IsNullOrEmpty(c.CategoryName)), Is.EqualTo(true));
            Assert.That(response.Result.Any(c => !string.IsNullOrEmpty(c.Description)), Is.EqualTo(true));
        }
    }
}
