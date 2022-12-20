using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SortingGamesTest.PageObjects;
using SortingGamesTest.Utility;

namespace SortingGamesTest.Tests
{
    public class Tests
    {
        private IWebDriver _webDriver;
        private string language;
        private string url;
        private string gameName;

        [SetUp]
        public void Setup()
        {
            LenguageSettings lenguageSettings = new LenguageSettings();
            language = lenguageSettings.CheckLenguage("language");
            url = lenguageSettings.CheckLenguage("url");
            gameName = lenguageSettings.CheckLenguage("gameName");

            ChromeOptions options = new ChromeOptions();
            options.AddArguments(language);

            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver(options);
            _webDriver.Navigate().GoToUrl(url);
        }

        [Test]
        public void Test()
        {
            HomePageObject homePage = new HomePageObject(_webDriver);
            SearchResultsPageObject searchResultsPageObject = new SearchResultsPageObject(_webDriver);
            Sort—heck sort—heck = new Sort—heck();

            bool resultCheckHomePage = homePage.CheckHomePage();
            Assert.AreEqual(true, resultCheckHomePage, "This is not home page.");

            homePage.EnterGameName(gameName);
            homePage.ClickOnSearchButton();

            bool resultCheckSearchPage = searchResultsPageObject.CheckSearchPage();
            Assert.AreEqual(true, resultCheckSearchPage, "This is not search page.");

            bool resultCheckingListItems = searchResultsPageObject.CheckCheckingListItems();
            Assert.AreEqual(true, resultCheckingListItems, "The list is empty.");
            
            searchResultsPageObject.ClickOnSortComboBox();
            searchResultsPageObject.SelectSortByPriceDESC();
            bool result = sort—heck.SortCheck(_webDriver, gameName);
            Assert.AreEqual(true, result, "Sorting is wrong.");
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}