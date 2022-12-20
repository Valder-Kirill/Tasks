using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TaskSix.PageObjects
{
    public class MenuVkPageObject : Form
    {
        private static IButton myPageBtn = ElementFactory.GetButton(By.XPath("//li[@id='l_pr']"),"My page button");

        public MenuVkPageObject() : base(By.XPath("//nav[contains(@class,'side_bar_nav')]"), "Navigation bar")
        {

        }

        public void ClickOnMyPage()
        {
            myPageBtn.Click();
        }
    }
}
