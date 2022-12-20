using OpenQA.Selenium;
using TheInternetTests.Abstractions;
using TheInternetTests.Elements;
using TheInternetTests.Logs;

namespace TheInternetTests.PageObjects
{
    public class Frame : BaseForm
    {
        private static Text text = new Text(By.XPath("//p"), "text");
        private Text changedText = new Text(By.XPath("//p/span[@style='font-size: 8pt;']"), "changed text");
        private const string frameLocator = "mce_0_ifr";

        public Frame() : base(text, "frame page") { }

        public IWebElement GetFraimParagraph()
        {
            return BrowserFactory.WebDriver.FindElement(By.XPath("//p"));
        }

        public string GetFraimParagraphAttribute(string attribute)
        {
            Logger.Info("Get fraim changed attribute");
            return text.GetAttribute(attribute);
        }

        public string GetFraimChangedParagraphAttribute(string attribute)
        {
            Logger.Info("Get fraim changed attribute");
            return changedText.GetAttribute(attribute);
        }

        public void SwitchToFrame()
        {
            DriverUtils.SwitchToFrame(frameLocator);
        }
    }
}
