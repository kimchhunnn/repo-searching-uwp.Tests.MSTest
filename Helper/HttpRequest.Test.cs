using System;
using Newtonsoft.Json;
using System.Diagnostics;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using repo_searching_uwp.Model;

using static repo_searching_uwp.Helper.HttpRequest;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace repo_searching_uwp.Tests.MSTest
{
    [TestClass]
    public class HttpRequestTest
    {

        [TestMethod]
        public void TestSuccessResponseHttpGetRequest() // Sucess
        {
            string uriSample = "https://api.github.com/search/repositories?q=123123123123123123123123";

            Windows.Web.Http.HttpResponseMessage response;
            response = HttpGetRequest(uriSample).Result;

            Assert.IsTrue(response is Windows.Web.Http.HttpResponseMessage);
            Assert.IsTrue(response.IsSuccessStatusCode is true);
        }

        [TestMethod]
        public void TestFailedResponseHttpGetRequest() // Failed
        {
            string uriSample = "https://api.github.com/search/repositories?q=\\";

            Windows.Web.Http.HttpResponseMessage response;
            response = HttpGetRequest(uriSample).Result;

            Assert.IsTrue(response is Windows.Web.Http.HttpResponseMessage);
            Assert.IsTrue(response.IsSuccessStatusCode is false);
        }
    }
}
