using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using SortingGamesTest.Utility;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace SortingGamesTest.PageObjects
{
    class SearchResultsPageObject
    {
        private IWebDriver _webDriver;
        private WaitUntilXPath waitUntilXPath;

        private readonly By _sortByTrigger = By.XPath("//a[@id = 'sort_by_trigger']");
        private readonly By _sortByPriceDESC = By.XPath("//a[@id = 'Price_DESC']");
        private readonly By _sortInDiv = By.XPath("//div[contains(@class,'search_pagination_right')]//a[contains(@href, 'Price_DESC')]");
        private readonly By _prices = By.XPath("//div[@data-price-final]");
        private readonly By _searchBar = By.XPath("//div[contains(@class, 'searchbar')]");
        private readonly By _searchResultRow = By.XPath("//a[contains(@class, 'search_result_row')]");

        private int[] pricesArray;

        public SearchResultsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            waitUntilXPath = new WaitUntilXPath();
        }

        public bool CheckSearchPage()
        {
            waitUntilXPath.Wait(_webDriver, _searchBar);
            int n = _webDriver.FindElements(_searchBar).Count;
            if (n > 0)
                return true;
            else
                return false;
        }

        public bool CheckCheckingListItems()
        {
            int n = _webDriver.FindElements(_searchResultRow).Count;
            if (n > 0)
                return true;
            else
                return false;
        }

        public void ClickOnSortComboBox()
        {
            _webDriver.FindElement(_sortByTrigger).Click();

        }

        public void SelectSortByPriceDESC()
        {
            _webDriver.FindElement(_sortByPriceDESC).Click();
        }

        public int[] SelectPrices(string gameName)
        {
            switch (gameName)
            {
                case "The Witcher":
                    FillingArray(10);
                    break;
                case "Fallout":
                    FillingArray(20);
                    break;
                default:
                    pricesArray = new int[0];
                    break;
            }
            return pricesArray;
        }

        private void FillingArray(int i)
        {

            waitUntilXPath.Wait(_webDriver, _sortInDiv);
            IList <IWebElement> elementList = _webDriver.FindElements(_prices);
            pricesArray = new int[i];
            for (int j = 0; j < i; j++)
            {
                pricesArray[j] = Convert.ToInt32(elementList[j].GetAttribute("data-price-final"));
            }
        }
    }
}
