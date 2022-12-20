using NUnit.Framework;
using TheInternetTests.PageObjects;
using TheInternetTests.Utils;

namespace TheInternetTests.Tests
{
    public class IFrameTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            BrowserFactory.WebDriver.Url = GetTestData.Get("projectData", "url") +
                GetTestData.Get("iFameData", "urlIFame");
        }

        [Test]
        public void Test()
        {
            Frame frame = new Frame();
            IFramePageObject famePageObject = new IFramePageObject();
            Assert.IsTrue(famePageObject.IsIFramePage(), "Key item not found.");
            
            famePageObject.TextAlignLeft();
            frame.SwitchToFrame();
            Assert.AreEqual(GetTestData.Get("iFameData", "textAlignLeftStyle"), frame.GetFraimParagraphAttribute(GetTestData.Get("iFameData", "attribute")),
                "Invalid text formatting.");

            SelectHalfText.Select(frame.GetFraimParagraph());
            DriverUtils.GoBackFromFrame();
            famePageObject.ChangeFontSize();
            frame.SwitchToFrame();
            Assert.AreEqual(GetTestData.Get("iFameData", "styleResult"), frame.GetFraimChangedParagraphAttribute(GetTestData.Get("iFameData", "attribute")),
                "Invalid text formatting.");
        }
    }
}
