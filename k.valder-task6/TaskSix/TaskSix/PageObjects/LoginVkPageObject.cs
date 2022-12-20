using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TaskSix.PageObjects
{
    public class LoginVkPageObject : Form
    {
        private static ITextBox loginTB = ElementFactory.GetTextBox(By.XPath("//input[@id='index_email']"), "Login text box");
        private static ITextBox passTB = ElementFactory.GetTextBox(By.XPath("//input[@id='index_pass']"),"Password text box");
        private static IButton loginBtn = ElementFactory.GetButton(By.XPath("//button[@id='index_login_button']"), "Login button");

        public LoginVkPageObject() : base(By.XPath("//div[@id='index_login']"), "Login form")
        {

        }

        public void SetLogin(string login)
        {
            loginTB.SendKeys(login);
        }

        public void SetPass(string pass)
        {
            passTB.SendKeys(pass);
        }

        public void ClickLoginBtn()
        {
            loginBtn.Click();
        }
    }
}
