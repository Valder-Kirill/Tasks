using Aquality.Selenium.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TaskOne.Utils
{
    public static class ClearTextBox
    {
        public static void Clear()
        {
            Actions actionProvider = new Actions(AqualityServices.Browser.Driver);
            IAction pressCtrl = actionProvider.KeyDown(Keys.LeftControl).Build();
            pressCtrl.Perform();
            IAction pressA = actionProvider.SendKeys("a").Build();
            pressCtrl.Perform();
            IAction releaseCtrl = actionProvider.KeyUp(Keys.LeftControl).Build();
            releaseCtrl.Perform();
        }
    }
}
