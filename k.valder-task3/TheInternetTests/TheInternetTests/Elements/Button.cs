using OpenQA.Selenium;
using TheInternetTests.Abstractions;

namespace TheInternetTests.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator, string name) : base(locator, name) { }
    }
}
