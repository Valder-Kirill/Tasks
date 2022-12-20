using OpenQA.Selenium;
using TheInternetTests.Abstractions;
using TheInternetTests.Elements;
using TheInternetTests.Logs;
using TheInternetTests.Utils;

namespace TheInternetTests.PageObjects
{
    public class UserPageObject : BaseForm
    {
        private static Text text = new Text(By.XPath("//body/*[text()='Not Found']"), "text on page");
        private string user;

        public UserPageObject() : base(text, "user page")
        {

        }

        public bool IsUrlFormLink()
        {
            Logger.Info("Check link user page");
            return GetTestData.Get("hoversData", "user" + user + "Link") == DriverUtils.GetUrl();
        }

        public void SetUser(string user)
        {
            this.user = user;
        }

        public void GoBack()
        {
            Logger.Info("Go to the previous page");
            DriverUtils.GoBack();
        }
    }
}
