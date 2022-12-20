using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TaskOne.PageObjects
{
    public class CookiesPageObject : Form
    {
        private static IButton acceptButton = ElementFactory.GetButton(By.XPath("//div[contains(@class,'cookies')]//button[contains(text(),'No')]"), "AcceptCookiesButton");

        public CookiesPageObject() : base(By.XPath("//div[contains(@class,'cookies')]"), "CookiesBlock")
        {

        }

        public void AcceptCookies()
        {
            acceptButton.Click();
        }
    }
}
