using OpenQA.Selenium;
using TheInternetTests.Abstractions;
using TheInternetTests.Elements;
using TheInternetTests.Logs;

namespace TheInternetTests.PageObjects
{
    public class AlertPageObject : BaseForm
    {
        private static Button jsAlertButton = new Button(By.XPath("//button[@onclick='jsAlert()']"), "jsAlert Button");
        private Button jsConfirmButton = new Button(By.XPath("//button[@onclick='jsConfirm()']"), "jsConfirm Button");
        private Button jsPromptButton = new Button(By.XPath("//button[@onclick='jsPrompt()']"), "jsPrompt Button");
        private Text textResult = new Text(By.XPath("//p[@id='result']"), "text result");

        public AlertPageObject() : base(jsAlertButton, "alert page") { }

        public bool IsAlertPage()
        {
            Logger.Info("Check " + jsAlertButton.GetName());
            return IsDisplayd();
        }

        public void ClickForJSAlertButton()
        {
            Logger.Info("Click on " + jsAlertButton.GetName() + " and check alert text");
            jsAlertButton.Click();
        }

        public void ClickForJSConfirmButton()
        {
            Logger.Info("Click on " + jsConfirmButton.GetName() + " and check alert text");
            jsConfirmButton.Click();
        }

        public void ClickForJSPromptButton()
        {
            Logger.Info("Click on " + jsPromptButton.GetName() + " and check alert text");
            jsPromptButton.Click();
        }

        public string GetResult()
        {
            Logger.Info("Check " + textResult.GetName());
            return textResult.GetContent();
        }
    }
}
