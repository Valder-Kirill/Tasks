using NUnit.Framework;
using TheInternetTests.PageObjects;
using TheInternetTests.Utils;

namespace TheInternetTests.Tests
{
    public class HoversTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            BrowserFactory.WebDriver.Url = GetTestData.Get("projectData", "url") +
                GetTestData.Get("hoversData", "urlHoversData");
        }

        [TestCase("1",TestName = "UserOne")]
        [TestCase("3",TestName = "UserThree")]
        public void Test(string number)
        {
            HoversPageObject hoversPageObject = new HoversPageObject();
            UserPageObject userPageObject = new UserPageObject();

            userPageObject.SetUser(number);
            hoversPageObject.SetUser(number);

            Assert.IsTrue(hoversPageObject.IsHoversPage(), "Key item not found.");

            hoversPageObject.MoveCursorOnUser();
            Assert.AreEqual(GetTestData.Get("hoversData", $"user{number}Name").ToString(), hoversPageObject.GetUserName(), "User link or name not found.");
            Assert.AreEqual(GetTestData.Get("hoversData", $"user{number}Link").ToString(), hoversPageObject.GetLinkUser(), "Url not found.");

            hoversPageObject.ClickLinkUser();
            Assert.IsTrue(userPageObject.IsUrlFormLink(), "Url not found.");

            userPageObject.GoBack();
            Assert.IsTrue(hoversPageObject.IsHoversPage(), "Key item not found.");
        }
    }
}
