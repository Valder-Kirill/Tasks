using OpenQA.Selenium;
using TheInternetTests.Abstractions;

namespace TheInternetTests.Elements
{
    public class TextField : BaseElement
    {
        public TextField(By locator, string name) : base (locator, name) { }
        
    }
}
