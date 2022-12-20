using NUnit.Framework;
using TaskOne.PageObjects;
using TheInternetTests.Tests;

namespace TaskOne.Tests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.Self)]
    public class CookieTest : BaseTest
    {
        [Test]
        public void TestCase3()
        {
            HomePageObject homePageObject = new HomePageObject();
            CookiesPageObject cookiesPageObject = new CookiesPageObject();

            Assert.IsTrue(homePageObject.IsHomePage(), "Page not open.");

            homePageObject.ClickOnLink();
            cookiesPageObject.AcceptCookies();
            Assert.IsTrue(cookiesPageObject.State.WaitForNotDisplayed(), "Cookies block is displayed.");
        }
    }
}
