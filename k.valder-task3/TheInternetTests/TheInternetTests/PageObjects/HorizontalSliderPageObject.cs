using OpenQA.Selenium;
using System;
using TheInternetTests.Abstractions;
using TheInternetTests.Elements;
using TheInternetTests.Logs;

namespace TheInternetTests.PageObjects
{
    public class HorizontalSliderPageObject : BaseForm
    {
        private static Slider horizontalSlider = new Slider(By.XPath("//input[@type='range']"), "horizontal slider");
        private Text sliderRange = new Text(By.XPath("//span[@id='range']"), "slider ange value");
        private double sliderValue;

        public HorizontalSliderPageObject() : base(horizontalSlider, "horizontal slider page")
        {

        }

        public bool IsHorizontalSliderPage()
        {
            Logger.Info("Check " + horizontalSlider.GetName());
            return IsDisplayd();
        }

        public void SetSliderValue()
        {
            Logger.Info("Click on " + horizontalSlider.GetName() + " and move slider");
            horizontalSlider.Click();
            sliderValue = horizontalSlider.MoveSlider();
        }

        public string GetExpectedSliderValue()
        {
            Logger.Info("Get expected " + horizontalSlider.GetName() + " value");
            return Convert.ToString(sliderValue / 2);
        }

        public string GetActualSliderValue()
        {
            Logger.Info("Get actual " + horizontalSlider.GetName() + " value");
            return sliderRange.GetContent().Replace(".", ",");
        }
    }
}
