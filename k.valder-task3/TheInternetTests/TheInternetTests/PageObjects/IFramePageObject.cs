using OpenQA.Selenium;
using TheInternetTests.Abstractions;
using TheInternetTests.Elements;
using TheInternetTests.Logs;

namespace TheInternetTests.PageObjects
{
    public class IFramePageObject : BaseForm
    {
        private static Button alignLeftButton = new Button(By.XPath("//button[@title='Align left']"), "align left button");
        private Button formatButton = new Button(By.XPath("//button/span[text()='Format']/.."), "format button");
        private Button fontSize = new Button(By.XPath("//div[@title='Font sizes']"), "font size button");
        private Button size8Pt = new Button(By.XPath("//div[@title='8pt']"), "8pt size button");

        public IFramePageObject() : base(alignLeftButton, "iFrame page")
        {

        }

        public bool IsIFramePage()
        {
            Logger.Info("Check " + alignLeftButton.GetName());
            return IsDisplayd();
        }

        public void TextAlignLeft()
        {
            Logger.Info("Click " + alignLeftButton.GetName());
            alignLeftButton.Click();
        }

        public void ChangeFontSize()
        {
            Logger.Info("Click " + size8Pt.GetName());
            formatButton.Click();
            fontSize.Click();
            size8Pt.Click();
        }
    }
}
