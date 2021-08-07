using System;
using Newtonsoft.Json;
using System.Diagnostics;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using repo_searching_uwp.Model;
using static repo_searching_uwp.Data.GitHubSearchStore;
using static repo_searching_uwp.Tests.MSTest.Mock.GitHubSearchRepoMockReponse;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FakeItEasy;
using System.Reflection;
using System.Collections;

namespace repo_searching_uwp.Tests.MSTest
{
    [TestClass]
    public class GitHubSearchStoreTest
    {

        [TestMethod]
        public void TestValidKeywordSingleRepoSearchRepo() // Valid Keyword
        {
            string keyword = "123123123123123123123123";

            string expectedResponseSample = GetValidResult();
            Result expectedReponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(expectedResponseSample);

            Result response = (Result)SearchRepo(keyword).Result;

            Assert.IsTrue(response is Result);

            Assert.AreEqual(expectedReponse.TotalCount, response.TotalCount);
            Assert.AreEqual(expectedReponse.Items.Count(), response.Items.Count());
            for (int i = 0; i < expectedReponse.Items.Count(); i++)
            {
                Assert.AreEqual(expectedReponse.Items[i].FullName, response.Items[i].FullName);
                Assert.AreEqual(expectedReponse.Items[i].Description, response.Items[i].Description);
                Assert.AreEqual(expectedReponse.Items[i].HtmlUrl, response.Items[i].HtmlUrl);
                Assert.AreEqual(expectedReponse.Items[i].Language, response.Items[i].Language);
                Assert.AreEqual(expectedReponse.Items[i].StargazersCount, response.Items[i].StargazersCount);
            }
            Debug.WriteLine(expectedReponse.Items.Count());
        }

        [TestMethod]
        public void TestValidKeywordMultipleRepoSearchRepo() // Valid Keyword
        {
            string keyword = "123123123123123123123";

            string expectedResponseSample = GetValidResultMultipleRepo();
            Result expectedReponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(expectedResponseSample);

            Result response = (Result)SearchRepo(keyword).Result;

            Assert.IsTrue(response is Result);

            Assert.AreEqual(expectedReponse.TotalCount, response.TotalCount);
            Assert.AreEqual(expectedReponse.Items.Count(), response.Items.Count());
        }

        [TestMethod]
        public void TestInvalidKeywordMultipleRepoSearchRepo() // Inalid Keyword
        {
            string keyword = "\\";

            string expectedResponseSample = GetInvalidResult();
            ErrorResponse expectedReponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse>(expectedResponseSample);

            ErrorResponse response = (ErrorResponse)SearchRepo(keyword).Result;

            Assert.IsTrue(response is ErrorResponse);

            Assert.AreEqual(expectedReponse.Message, response.Message);
            Assert.AreEqual(expectedReponse.Errors[0].Message, response.Errors[0].Message);
        }

        [TestMethod]
        public void TestValidKeywordEmptyRepoSearchRepo() // Valid Keyword
        {
            string keyword = "asdf34Ndhfa";

            string expectedResponseSample = GetValidEmptyResult();
            Result expectedReponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(expectedResponseSample);

            Result response = (Result)SearchRepo(keyword).Result;

            Assert.IsTrue(response is Result);

            Assert.AreEqual(expectedReponse.TotalCount, response.TotalCount);
            Assert.AreEqual(expectedReponse.Items.Count(), response.Items.Count());
        }
    }
}
