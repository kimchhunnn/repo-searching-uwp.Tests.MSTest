using System;
using Newtonsoft.Json;
using System.Diagnostics;

using repo_searching_uwp.Model;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace repo_searching_uwp.Tests.MSTest
{
    [TestClass]
    public class ResultTest
    {

        [TestMethod]
        public void TestRepo()
        {
            string expectedFullName = "hackudown/Hackudown";
            string expectedHtmlUrl = "https://github.com/hackudown/Hackudown";
            string expectedDescription = "123123123123123123123123";
            int expectedStargazersCount = 1978;
            string expectedLanguage = "JavaScript";

            string repoSample = "{\"full_name\":\"hackudown/Hackudown\",\"html_url\":\"https://github.com/hackudown/Hackudown\", \"description\":\"123123123123123123123123\",\"stargazers_count\":1978,\"language\":\"JavaScript\"}";
            
            Repo repo = Newtonsoft.Json.JsonConvert.DeserializeObject<Repo>(repoSample);

            Assert.AreEqual(expectedFullName, repo.FullName);
            Assert.AreEqual(expectedHtmlUrl, repo.HtmlUrl);
            Assert.AreEqual(expectedDescription, repo.Description);
            Assert.AreEqual(expectedStargazersCount, repo.StargazersCount);
            Assert.AreEqual(expectedLanguage, repo.Language);
        }

        [TestMethod]
        public void TestResult()
        {
            int expectedTotalCount = 1;

            string resultSample = "{\"total_count\":1,\"items\":[{\"full_name\":\"hackudown/Hackudown\",\"html_url\":\"https://github.com/hackudown/Hackudown\",\"description\":\"123123123123123123123123\",\"stargazers_count\":1978,\"language\":\"JavaScript\"}]}";

            Result result = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(resultSample);

            string repoSample = "{\"full_name\":\"hackudown/Hackudown\",\"html_url\":\"https://github.com/hackudown/Hackudown\",\"description\":\"123123123123123123123123\",\"stargazers_count\":1978,\"language\":\"JavaScript\"}";
            Repo repo = Newtonsoft.Json.JsonConvert.DeserializeObject<Repo>(repoSample);
            List<Repo> expectedItems = new List<Repo> { repo };

            Assert.AreEqual(expectedTotalCount, result.TotalCount);
            Assert.AreEqual(expectedItems.ToString(), result.Items.ToString());
        }
    }
}
