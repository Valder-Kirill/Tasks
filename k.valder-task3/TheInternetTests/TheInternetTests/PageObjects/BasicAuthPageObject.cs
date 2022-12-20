using OpenQA.Selenium;
using TheInternetTests.Abstractions;
using TheInternetTests.Elements;
using TheInternetTests.Logs;

namespace TheInternetTests.PageObjects
{
    public class BasicAuthPageObject : BaseForm
    {
        private static Text text = new Text(By.XPath("//p"), "message after authorization");
        public BasicAuthPageObject() : base(text, "basic authentication page") { }

        public bool IsSuccessfulAuthorization()
        {
            Logger.Info("Check " + text.GetName());
            return IsDisplayd();
        }
    }
}
