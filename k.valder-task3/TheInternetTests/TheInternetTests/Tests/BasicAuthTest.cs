using NUnit.Framework;
using TheInternetTests.PageObjects;
using TheInternetTests.Utils;

namespace TheInternetTests.Tests
{
    public class BasicAuthTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            BrowserFactory.WebDriver.Url = GetTestData.Get("basicAuthData", "urlForLogin");
        }

        [Test]
        public void Test()
        {
            BasicAuthPageObject basicAuthPageObject = new BasicAuthPageObject();
            Assert.IsTrue(basicAuthPageObject.IsSuccessfulAuthorization(), "Login failed.");
        }
    }
}