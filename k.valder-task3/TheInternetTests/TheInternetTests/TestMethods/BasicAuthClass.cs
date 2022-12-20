using OpenQA.Selenium;
using TheInternetTests.Utils;

namespace TheInternetTests.TestMethods
{
    public class BasicAuthClass
    {
        public void Login()
        {
            IJavaScriptExecutor javaScript = (IJavaScriptExecutor)BrowserFactory.WebDriver;
            BrowserFactory.WebDriver.Url = GetTestData.Get("basicAuthData", "urlForLogin");
        }
    }
}
