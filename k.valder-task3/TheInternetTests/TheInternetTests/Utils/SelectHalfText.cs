using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TheInternetTests.Logs;

namespace TheInternetTests.Utils
{
    public static class SelectHalfText
    {
        public static void Select(IWebElement element)
        {
            Logger.Info("Select half text");
            Actions actions = new Actions(BrowserFactory.WebDriver);
            actions.KeyDown(Keys.Shift).Release().Perform();
            for (int i = 0; i < element.Text.Length/2; i++)
            {
                actions.SendKeys(Keys.Right);
            }
            actions.KeyUp(Keys.Shift).Release().Perform();
        }
    }
}
