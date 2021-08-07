using System;
using Newtonsoft.Json;
using System.Diagnostics;

using repo_searching_uwp.Model;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace repo_searching_uwp.Tests.MSTest
{
    [TestClass]
    public class ErrorResponseTest
    {

        [TestMethod]
        public void TestError()
        {
            string expected = "None of the search qualifiers apply to this search type.";
            string errorSample = "{\"message\": \"None of the search qualifiers apply to this search type.\"}";
            Errors error = Newtonsoft.Json.JsonConvert.DeserializeObject<Errors>(errorSample);
            Assert.AreEqual(expected, error.Message);
        }

        [TestMethod]
        public void TestErrorResponse()
        {
            string errorResponseSample = "{\"message\":\"Validation Failed\",\"errors\":[{\"message\":\"None of the search qualifiers apply to this search type.\",\"resource\":\"Search\",\"field\":\"q\",\"code\":\"invalid\"}],\"documentation_url\":\"https://docs.github.com/v3/search/\"}";
            string expectedMessage = "Validation Failed";

            string errorSample = "{\"message\":\"None of the search qualifiers apply to this search type.\"}";
            Errors error = Newtonsoft.Json.JsonConvert.DeserializeObject<Errors>(errorSample);
            Errors[] expectedErrors = new Errors[]{error};

            ErrorResponse errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse>(errorResponseSample);

            Assert.AreEqual(expectedMessage, errorResponse.Message);
            Assert.AreEqual(expectedErrors[0].Message, errorResponse.Errors[0].Message);
        }
    }
}
