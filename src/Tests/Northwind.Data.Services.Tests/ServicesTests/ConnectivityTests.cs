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
using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;
using DTOs = Northwind.Data.Services;

namespace Northwind.Data.Services.Tests.ServicesTests
{
    [TestFixture]
    public class ConnectivityTests : ServiceTestBase
    {
        [SetUp]
        public override void OnBeforeEachTest()
        {
            base.OnBeforeEachTest();

            // initialize some data here
        }

        // The ServiceStack client is already documented here: https://github.com/ServiceStack/ServiceStack/wiki/C%23-client
        // This is just a starter template to see how it's done

        [Test]
        public void Sample1_WithDtos_Recommended()
        {
            var client = base.NewJsonServiceClient();

            // method 1: Dtos all the way
            var response1 = client.Get(new DTOs.EntitiesRequest());
            AssertResponseIsValid(response1);

            // method 2: Dtos response, path / querystring / formdata as objects
            var response2 = client.Get<DTOs.EntityCollectionResponse>("/entities");
            AssertResponseIsValid(response2);

            // method 2: Dtos response, specify method, path / and request as object
            var response3 = ((JsonServiceClient) client).Send<DTOs.EntityCollectionResponse>("GET", "/entities", null);
            AssertResponseIsValid(response3);

            Assert.That(response1.Result.Count, Is.EqualTo(response2.Result.Count));
            Assert.That(response1.Result.Count, Is.EqualTo(response3.Result.Count));
        }

        [Test]
        public void Sample2_WithoutDtos()
        {
            var client = base.NewJsonServiceClient();
            var webResponse = client.Get<HttpWebResponse>("/entities");

            using (var stream = webResponse.GetResponseStream())
            using (var sr = new StreamReader(stream))
            {
                var dto = sr.ReadToEnd();

                // do something with the json string
                var jsonObject = JsonObject.Parse(dto);
                Assert.That(jsonObject, Is.Not.Null);
                Assert.That(jsonObject["result"], Is.Not.Null);

                // try casting the json string to the DTO
                var response = dto.FromJson<EntityCollectionResponse>();
                AssertResponseIsValid(response);
            }
        }

        [Test]
        public void Sample3_RawHttpRequests()
        {
            var uri = (base.BaseUri + "/entities");

            // json from url
            var jsonString = uri.GetJsonFromUrl();
            var jsonObject = JsonObject.Parse(jsonString);
            Assert.That(jsonObject, Is.Not.Null);
            Assert.That(jsonObject["result"], Is.Not.Null);

            // or specify the format
            var jsonFormattedString = uri.GetStringFromUrl("application/json");
            jsonObject = JsonObject.Parse(jsonFormattedString);
            Assert.That(jsonObject, Is.Not.Null);
            Assert.That(jsonObject["result"], Is.Not.Null);

            // use xml instead
            var xmlFormattedString = uri.GetStringFromUrl("application/xml");
            var response = XmlSerializer.DeserializeFromString<EntityCollectionResponse>(xmlFormattedString);
            AssertResponseIsValid(response);
        }

        private void AssertResponseIsValid(EntityCollectionResponse response)
        {
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Result, Is.Not.Null);
            Assert.That(response.Result.Count, Is.Positive);
        }
    }
}
