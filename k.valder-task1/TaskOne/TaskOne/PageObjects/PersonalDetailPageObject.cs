using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TaskOne.PageObjects
{
    public class PersonalDetailPageObject : Form
    {
        private static ILabel pageIndicator = ElementFactory.GetLabel(By.XPath("//div[contains(@class,'page-indicator')]"), "PageIndicator");

        public PersonalDetailPageObject() : base(By.XPath("//div[contains(@class,'personal-details__form')]"), "PersonalDetailPage")
        {

        }

        public char GetNumberOfCard()
        {
            return pageIndicator.GetText()[0];
        }
    }
}
