using Northwind.Data.Dtos;
using NUnit.Framework;
using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace Northwind.Data.Services.Tests.ServicesTests
{
    [TestFixture]
    public class ValidationTests : ServiceTestBase
    {
        [SetUp]
        public override void OnBeforeEachTest()
        {
            base.OnBeforeEachTest();

            // initialize some data here
        }

        [TearDown]
        public override void OnAfterEachTest()
        {
            base.OnAfterEachTest();

            // initialize some data here
        }

        /*
         * Validation tests: https://github.com/ServiceStack/ServiceStack/wiki/Validation
         */

        [Test]
        [ExpectedException(typeof(WebServiceException))]
        public void Throws_Error_OnDelete_401_WithoutAuthentication()
        {
            try
            {
                var client = base.NewJsonServiceClient();
                client.Delete(new CategoryDeleteRequest {CategoryId = 0});
            }
            catch (WebServiceException webEx)
            {
                var statusCode = webEx.StatusCode;
                var errorCode = webEx.ErrorCode;
                var message = webEx.Message;
                var responseDto = webEx.ResponseDto;
                var responseStatus = webEx.ResponseStatus;
                var fieldErrors = webEx.GetFieldErrors();

                Assert.That(statusCode, Is.EqualTo(401));
                Assert.That(errorCode, Is.EqualTo("Unauthorized"));
                Assert.That(message, Is.EqualTo("Unauthorized"));
                Assert.That(responseDto, Is.Null);
                Assert.That(responseStatus, Is.Null);
                Assert.That(fieldErrors.Count, Is.EqualTo(0));

                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(WebServiceException))]
        public void Throws_Error_OnDelete_400_WithAuthentication_AndBadParameter()
        {
            try
            {
                var client = base.NewJsonServiceClient(true);
                client.Delete(new CategoryDeleteRequest { CategoryId = 0 });
            }
            catch (WebServiceException webEx)
            {
                var statusCode = webEx.StatusCode;
                var errorCode = webEx.ErrorCode;
                var message = webEx.Message;
                var responseDto = webEx.ResponseDto;
                var responseStatus = webEx.ResponseStatus;
                var fieldErrors = webEx.GetFieldErrors();

                Assert.That(statusCode, Is.EqualTo(400));
                Assert.That(errorCode, Is.EqualTo("ValidationException"));
                Assert.That(message, Is.EqualTo("ValidationException"));
                Assert.That(responseDto, Is.Not.Null);
                Assert.That(responseDto, Is.TypeOf<SimpleResponse<bool>>());
                Assert.That(responseStatus, Is.Not.Null);
                Assert.That(responseStatus.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(responseStatus.Message, Is.StringStarting("Validation failed:"));
                Assert.That(fieldErrors.Count, Is.EqualTo(1));
                Assert.That(fieldErrors[0].ErrorCode, Is.StringStarting("GreaterThan"));
                Assert.That(fieldErrors[0].FieldName, Is.EqualTo("CategoryId"));

                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(WebServiceException))]
        public void Throws_Error_OnDelete_400_WithAuthentication_AndBadParameter_UsingUrlMethod()
        {
            try
            {
                var client = base.NewJsonServiceClient(true);
                client.Post<object>("/categories/0/delete", null);
            }
            catch (WebServiceException webEx)
            {
                var statusCode = webEx.StatusCode;
                var statusDescription = webEx.StatusDescription;

                Assert.That(statusCode, Is.EqualTo(400));
                Assert.That(statusDescription, Is.EqualTo("ValidationException"));

                // because we specified <object> as the response, the body is not yet deserialized
                // you can use JsonObject to parse the response, but it's easier when you know and can use the type
                var webExBody = JsonSerializer.DeserializeFromString<SimpleResponse<bool>>(webEx.ResponseBody);
                var errorCode = webExBody.ResponseStatus.ErrorCode;
                var responseStatus = webExBody.ResponseStatus;
                var fieldErrors = webExBody.ResponseStatus.Errors;
                Assert.That(errorCode, Is.EqualTo("ValidationException"));
                Assert.That(responseStatus, Is.Not.Null);
                Assert.That(responseStatus.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(responseStatus.Message, Is.StringStarting("Validation failed:"));
                Assert.That(fieldErrors.Count, Is.EqualTo(1));
                Assert.That(fieldErrors[0].ErrorCode, Is.StringStarting("GreaterThan"));
                Assert.That(fieldErrors[0].FieldName, Is.EqualTo("CategoryId"));

                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(WebServiceException))]
        public void Throws_Error_OnDelete_404_WithAuthentication_AndNonExistingCategory()
        {
            try
            {
                var client = base.NewJsonServiceClient(true);
                var response = client.Delete(new CategoryDeleteRequest { CategoryId = int.MaxValue });
            }
            catch (WebServiceException webEx)
            {
                var statusCode = webEx.StatusCode;
                var statusDescription = webEx.StatusDescription;

                Assert.That(statusCode, Is.EqualTo(404));
                Assert.That(statusDescription, Is.EqualTo("NullReferenceException"));

                // because we specified <object> as the response, the body is not yet deserialized
                // you can use JsonObject to parse the response, but it's easier when you know and can use the type
                var webExBody = JsonSerializer.DeserializeFromString<SimpleResponse<bool>>(webEx.ResponseBody);
                var errorCode = webExBody.ResponseStatus.ErrorCode;
                var responseStatus = webExBody.ResponseStatus;
                var fieldErrors = webExBody.ResponseStatus.Errors;
                Assert.That(errorCode, Is.EqualTo("NullReferenceException"));
                Assert.That(responseStatus, Is.Not.Null);
                Assert.That(responseStatus.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(responseStatus.Message, Is.StringStarting("Category matching"));
                Assert.That(fieldErrors.Count, Is.EqualTo(0));

                throw;
            }
        }
    }
}
