using TheInternetTests.Logs;

namespace TheInternetTests
{
    public static class DriverUtils
    {
        public static string GetAlertText()
        {
            Logger.Info("Get alert text");
            return BrowserFactory.WebDriver.SwitchTo().Alert().Text;
        }

        public static void ClickOkOnAlert()
        {
            Logger.Info("Click ok on alert");
            BrowserFactory.WebDriver.SwitchTo().Alert().Accept();
        }

        public static string GetUrl()
        {
            Logger.Info("Get url");
            return BrowserFactory.WebDriver.Url;
        }

        public static void GoBack()
        {
            Logger.Info("Go to the previous page");
            BrowserFactory.WebDriver.Navigate().Back();
        }

        public static void GoBackFromFrame()
        {
            Logger.Info("Go to the previous frame");
            BrowserFactory.WebDriver.SwitchTo().DefaultContent();
        }

        public static void SwitchToFrame(string locator)
        {
            BrowserFactory.WebDriver.SwitchTo().Frame(locator);
        }
    }
}
