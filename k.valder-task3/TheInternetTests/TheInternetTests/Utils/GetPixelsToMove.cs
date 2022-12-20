using OpenQA.Selenium;
using System;

namespace TheInternetTests.Utils
{
    public static class GetPixelsToMove
    {
        public static int Get(IWebElement Slider, double Amount, double SliderMax, double SliderMin)
        {
            int pixels = 0;
            double tempPixels = Slider.Size.Width;
            tempPixels = tempPixels / (SliderMax - SliderMin);
            tempPixels = tempPixels * (Amount - SliderMin);
            pixels = Convert.ToInt32(tempPixels);
            return pixels;
        }
    }
}
