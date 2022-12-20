using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TaskOne.PageObjects
{
    public class HomePageObject : Form
    {
        private static ILink startLink = ElementFactory.GetLink(By.XPath("//a[contains(@class,'start__link')]"), "StartLink");

        public HomePageObject() : base(By.XPath("//div[@id='app']"), "HomePage")
        {
            
        }

        public bool IsHomePage()
        {
            return DisplayedElements.Count > 0;
        }

        public void ClickOnLink()
        {
            startLink.Click();
        }
    }
}
