using OpenQA.Selenium;
using SortingGamesTest.PageObjects;

namespace SortingGamesTest.Utility
{
    class SortСheck
    {
        public bool SortCheck(IWebDriver webDiver, string gameName)
        {
            SearchResultsPageObject searchResultsPageObject = new SearchResultsPageObject(webDiver);
            int[]  allPrices = searchResultsPageObject.SelectPrices(gameName);
            bool result = true;
            for (int i = 1; i < allPrices.Length; i++)
            {
                if (allPrices[i - 1] < allPrices[i])
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
