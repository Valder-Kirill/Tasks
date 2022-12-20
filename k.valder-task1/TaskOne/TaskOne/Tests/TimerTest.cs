using NUnit.Framework;
using TaskOne.PageObjects;
using TaskOne.Utils;
using TheInternetTests.Tests;

namespace TaskOne.Tests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.Self)]
    public class TimerTest : BaseTest
    {
        [Test]
        public void TestCase4()
        {
            HomePageObject homePageObject = new HomePageObject();
            LoginPageObject loginPageObject = new LoginPageObject();

            homePageObject.ClickOnLink();
            Assert.AreEqual(GetTestData.Get("timerData", "value"),loginPageObject.GetTimerValue(), "TimerIsNotNull");
        }
    }
}
