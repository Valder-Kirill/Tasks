using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TheInternetTests.Logs;
using TheInternetTests.Utils;

namespace TheInternetTests
{
    public class DriverWait
    {
        private static WebDriverWait _browserWait;

        private static WebDriverWait BrowserWait
        {
            get
            {
                if (_browserWait == null)
                {
                    Logger.Info("Start waiting");
                    _browserWait = new WebDriverWait(BrowserFactory.WebDriver, TimeSpan.FromSeconds(Convert.ToDouble(GetConfig.Get("defaultTimeOut"))));
                }
                return _browserWait;
            }
            set => _browserWait = value;
        }

        public static void WaitElementForXPath(By xPath)
        {
            BrowserWait.Until(e => e.FindElement(xPath));
        } 

        public static void StopWait()
        {
            BrowserWait = null;
        }
    }
}
