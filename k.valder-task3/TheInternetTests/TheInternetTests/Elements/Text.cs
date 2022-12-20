using OpenQA.Selenium;
using TheInternetTests.Abstractions;

namespace TheInternetTests.Elements
{
    public class Text : BaseElement
    {
        public Text(By locator, string name) : base (locator, name) { }
    }
}
