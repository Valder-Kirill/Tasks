using OpenQA.Selenium;
using SortingGamesTest.Utility;

namespace SortingGamesTest.PageObjects
{
    class HomePageObject
    {
        private IWebDriver _webDriver;
        private WaitUntilXPath waitUntilXPath;

        private readonly By _specialOffersBlock = By.XPath("//div[contains(@class, 'special_offers')]");
        private readonly By _searchTermInput = By.XPath("//input[@id = 'store_nav_search_term']");
        private readonly By _searchButton = By.XPath("//a[@id = 'store_search_link']//img");

        public HomePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            waitUntilXPath = new WaitUntilXPath();
        }

        public bool CheckHomePage()
        {
            waitUntilXPath.Wait(_webDriver, _specialOffersBlock);
            int a = _webDriver.FindElements(_specialOffersBlock).Count;
            if (a > 0)
                return true;
            else
                return false;
        }

        public void EnterGameName(string nameGame)
        {
            _webDriver.FindElement(_searchTermInput).SendKeys(nameGame);
        }

        public void ClickOnSearchButton()
        {
            _webDriver.FindElement(_searchButton).Click();
        }
    }
}
