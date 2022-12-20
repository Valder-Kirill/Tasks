using NUnit.Framework;
using TaskOne.PageObjects;
using TheInternetTests.Tests;

namespace TaskOne.Tests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.Self)]
    public class HelpTest : BaseTest
    {
        [Test]
        public void TestCase2()
        {
            HomePageObject homePageObject = new HomePageObject();
            HelpPageObject helpPageObject = new HelpPageObject();

            Assert.IsTrue(homePageObject.IsHomePage(), "Page not open.");

            homePageObject.ClickOnLink();
            helpPageObject.ClickOnSendButton();
            Assert.IsTrue(helpPageObject.State.WaitForNotDisplayed(), "Help form is displayed.");
        }
    }
}
