using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using TaskOne.Utils;

namespace TaskOne.PageObjects
{
    public class LoginPageObject : Form
    {
        private static ILabel pageIndicator = ElementFactory.GetLabel(By.XPath("//div[contains(@class,'page-indicator')]"), "PageIndicator");
        private static ITextBox passwordInput = ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Choose Password']"), "PasswordInput");
        private static ITextBox mailNameInput = ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Your email']"), "MailNameInput");
        private static ITextBox domainTwoInput = ElementFactory.GetTextBox(By.XPath("//input[@placeholder='Domain']"), "DomainTwoInputInput");
        private static IButton domainOneButton = ElementFactory.GetButton(By.XPath("//div[contains(@class,'dropdown__opener')]"), "DomainOneButton");
        private static ILabel DomainOneDropdownElement(int domain) => ElementFactory.GetLabel(By.XPath($"//div[contains(@class,'dropdown__list')]/div[{domain}]"), "DomainOneDropdownElement");
        private static ICheckBox acceptCheckBox = ElementFactory.GetCheckBox(By.XPath("//span[contains(@class,'checkbox__box')]"), "AcceptCheckBox");
        private static IButton nextButton = ElementFactory.GetButton(By.XPath("//a[contains(@class,'button--secondary')]"), "NextButton");
        private static ILabel timer = ElementFactory.GetLabel(By.XPath("//div[contains(@class,'timer')]"), "Timer");
        
        public LoginPageObject() : base(By.XPath("//div[@class='login-form']"), "GamePage")
        {
        }

        public char GetNumberOfCard()
        {
            return pageIndicator.GetText()[0];
        }

        public void SetPassword(string pass)
        {
            passwordInput.Click();
            ClearTextBox.Clear();
            passwordInput.SendKeys(pass);
        }

        public void SetMailName(string pass)
        {
            mailNameInput.Click();
            ClearTextBox.Clear();
            mailNameInput.SendKeys(pass);
        }

        public void SetDomainTwo(string pass)
        {
            domainTwoInput.Click();
            ClearTextBox.Clear();
            domainTwoInput.SendKeys(pass);
        }

        public void SetDomainOne(int num)
        {
            domainOneButton.Click();
            DomainOneDropdownElement(num).Click();
        }

        public void AcceptTerms()
        {
            acceptCheckBox.Click();
        }

        public void ClickNextButton()
        {
            nextButton.Click();
        }

        public string GetTimerValue()
        {
            return timer.GetText();
        }
    }
}
