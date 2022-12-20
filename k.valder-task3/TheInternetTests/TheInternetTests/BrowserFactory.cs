using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TheInternetTests.Logs;
using TheInternetTests.Utils;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TheInternetTests
{
    public static class BrowserFactory
    {
        private static IWebDriver _webDriver;

        public static IWebDriver WebDriver
        {
            get
            {
                if (_webDriver == null)
                {
                    Logger.Info("Start browser");
                    StartBrowser(GetConfig.Get("browserName"));
                }
                return _webDriver;
            }
            private set => _webDriver = value;
        }

        private static void StartBrowser(string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _webDriver = new ChromeDriver();
                    break;
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    _webDriver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException("You need to set a valid browser type.");
            }
        }

        public static void StopBrowser()
        {
            WebDriver.Quit();
            WebDriver = null;
        }
    }
}
