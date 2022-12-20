using Aquality.Selenium.Browsers;
using NUnit.Framework;
using TaskOne.Utils;

namespace TheInternetTests.Tests
{
    public abstract class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            var browser = AqualityServices.Browser;
            
            browser.Maximize();
            browser.GoTo(GetTestData.Get("homePageData", "url"));
            browser.WaitForPageToLoad();
        }

        [TearDown]
        public void TearDown()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
