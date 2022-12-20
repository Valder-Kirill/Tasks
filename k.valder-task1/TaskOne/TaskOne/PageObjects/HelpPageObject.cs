using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TaskOne.PageObjects
{
    public class HelpPageObject : Form
    {
        private static IButton sendHelpButton = ElementFactory.GetButton(By.XPath("//button[contains(@class,'help-form__send-to-bottom-button')]"), "SendHelpButton");

        public HelpPageObject() : base(By.XPath("//div[contains(@class,'help-form')]"), "HelpForm")
        {

        }

        public void ClickOnSendButton()
        {
            sendHelpButton.Click();
        }
    }
}
