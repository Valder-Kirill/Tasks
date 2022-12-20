using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TheInternetTests.Abstractions;
using TheInternetTests.Logs;
using TheInternetTests.Utils;


namespace TheInternetTests.Elements
{
    public class Slider : BaseElement
    {
        public Slider(By locator, string name) : base(locator, name)
        {
        }

        public double MoveSlider()
        {
            Logger.Info("Move slider " + GetName());
            Actions sliderAction = new Actions(BrowserFactory.WebDriver);
            double rnd = RandomInt.RandomIntValue();
            for (int i = 0; i < 5; i++)
            {
                sliderAction.SendKeys(Keys.Left);
            }
            sliderAction.Release().Perform();
            for (int i = 0; i < rnd; i++)
            {
                sliderAction.SendKeys(Keys.Right);
            }
            sliderAction.Release().Perform();
            return rnd;
        }
    }
}
