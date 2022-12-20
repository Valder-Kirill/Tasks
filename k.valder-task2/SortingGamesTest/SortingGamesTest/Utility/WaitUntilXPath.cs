using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SortingGamesTest.Utility
{
    class WaitUntilXPath
    {
        public void Wait(IWebDriver _webDriver, By xPath)
        {
            WebDriverWait waitForElement = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            waitForElement.Until(e => e.FindElement(xPath));
        }
    }
}
