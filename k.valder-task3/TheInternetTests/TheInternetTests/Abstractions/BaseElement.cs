using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using TheInternetTests.Logs;

namespace TheInternetTests.Abstractions
{
    public abstract class BaseElement
    {
        private By locator;
        private string name;

        public BaseElement(By locator, string name)
        {
            this.locator = locator;
            this.name = name;
        }

        public void MoveCursorOnElement()
        {
            Logger.Info("Move cursor on " + name);
            Actions action = new Actions(BrowserFactory.WebDriver);
            action.MoveToElement(FindElement()).Build().Perform();
        }

        public virtual bool IsDisplayed()
        {
            Logger.Info("Check displayed " + name);
            return FindElementsCount() > 0;
        }

        public virtual void Click()
        {
            Logger.Info("Click on " + name);
            FindElement().Click();
        }

        public string GetContent()
        {
            Logger.Info("Get content " + name);
            return FindElement().Text;
        }

        public By GetLocator()
        {
            Logger.Info("Get lokator " + name);
            return locator;
        }

        public string GetName()
        {
            Logger.Info("Get name " + name);
            return name;
        }

        public virtual string GetAttribute(string attribute)
        {
            Logger.Info("Get attribute " + name);
            return FindElement().GetAttribute(attribute);
        }

        public virtual string GetCss(string value)
        {
            Logger.Info("Get css " + name);
            return FindElement().GetCssValue(value);
        }

        public virtual int GetWidth()
        {
            Logger.Info("Get width " + name);
            return FindElement().Size.Width;
        }

        public virtual int GetHeight()
        {
            Logger.Info("Get height " + name);
            return FindElement().Size.Height;
        }

        public int FindElementsCount()
        {
            Logger.Info("Find element count " + name);
            return FindElements().Count;
        }

        protected IWebElement FindElement()
        {
            Logger.Info("Find element " + name);
            
            return BrowserFactory.WebDriver.FindElement(locator);
        }

        protected IList<IWebElement> FindElements()
        {
            Logger.Info("Find elements " + name);
            return BrowserFactory.WebDriver.FindElements(locator);
        }
    }
}
