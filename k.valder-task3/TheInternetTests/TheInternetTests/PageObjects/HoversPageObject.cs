using OpenQA.Selenium;
using TheInternetTests.Abstractions;
using TheInternetTests.Elements;
using TheInternetTests.Logs;

namespace TheInternetTests.PageObjects
{
    public class HoversPageObject : BaseForm
    {
        private static Text textHovers = new Text(By.XPath("//div[contains(@class,'example')]/p"), "text on hovers page");
        private Figure FigureUser(string user) => new Figure(By.XPath($"//*[text()='name: user{user}']/../.."), "first user figure");
        private Text UserName(string user) => new Text(By.XPath($"//*[text()='name: user{user}']"), "username");
        private Text UserLink(string user) => new Text(By.XPath($"//a[@href='/users/{user}']"), "user link");

        private string user;

        public HoversPageObject() : base(textHovers, "hover page")
        {

        }

        public bool IsHoversPage()
        {
            Logger.Info("Check " + textHovers.GetName());
            return IsDisplayd();
        }

        public void SetUser(string number)
        {
            user = number;
        }

        public void MoveCursorOnUser()
        {
            Logger.Info("Click on " + FigureUser(user).GetName());
            FigureUser(user).MoveCursorOnElement();
        }

        public string GetUserName()
        {
            Logger.Info("Check " + UserName(user).GetName() + " and " + UserLink(user).GetName());
            return UserName(user).GetContent();
        }

        public string GetLinkUser()
        {
            Logger.Info("Check " + UserName(user).GetName() + " and " + UserLink(user).GetName());
            return UserLink(user).GetAttribute("href");
        }

        public void ClickLinkUser()
        {
            Logger.Info("Click on " + UserLink(user).GetName());
            UserLink(user).Click();
        }
    }
}
