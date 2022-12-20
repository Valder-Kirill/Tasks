using NUnit.Framework;
using TheInternetTests.PageObjects;
using TheInternetTests.Utils;

namespace TheInternetTests.Tests
{
    public class HorizontalSliderTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            BrowserFactory.WebDriver.Url = GetTestData.Get("projectData", "url") + 
                GetTestData.Get("sliderData","urlForizontalSlider");
        }

        [Test]
        public void Test()
        {
            HorizontalSliderPageObject horizontalSliderPageObject = new HorizontalSliderPageObject();
            Assert.IsTrue(horizontalSliderPageObject.IsHorizontalSliderPage(), "Key item not found.");
            horizontalSliderPageObject.SetSliderValue();
            Assert.AreEqual(horizontalSliderPageObject.GetExpectedSliderValue(), horizontalSliderPageObject.GetActualSliderValue(), "The values differ.");
        }
    }
}