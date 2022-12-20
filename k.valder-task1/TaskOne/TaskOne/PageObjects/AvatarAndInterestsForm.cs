using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using TaskOne.Utils;

namespace TaskOne.PageObjects
{
    public class AvatarAndInterestsForm : Form
    {
        private static ICheckBox unselectallCheckBox = ElementFactory.GetCheckBox(By.XPath("//label[@for='interest_unselectall']"), "UnselectallCheckBox");
        private static ICheckBox RndCheckBox(int i) => ElementFactory.GetCheckBox(By.XPath($"//div[contains(@class,'avatar-and-interests__interests-list__item')][{i}]//label"), "RundomCheckBox");
        private static ILink uploadLink = ElementFactory.GetLink(By.XPath("//a[contains(@class,'avatar-and-interests__upload-button')]"), "UploadLink");
        private static IButton nextButton = ElementFactory.GetButton(By.XPath("//button[contains(text(),'Next')]"), "NextButton");
        private static ILabel pageIndicator = ElementFactory.GetLabel(By.XPath("//div[contains(@class,'page-indicator')]"), "PageIndicator");

        public AvatarAndInterestsForm() : base (By.XPath("//div[@class='avatar-and-interests-page']"), "AvatarAndInterestsForm")
        {
            
        }

        public void ClickOnUnselectall()
        {
            unselectallCheckBox.Click();
        }

        public void ClickOnInterests(int count)
        {
            if (count > Convert.ToInt32(GetTestData.Get("interests", "maxInterests")))
                count = Convert.ToInt32(GetTestData.Get("interests", "maxInterests"));
            int[]  rundomInt = RandomUtil.MassRundomInt(count);
            for(int i = 0; i < rundomInt.Length; i++)
            {
                RndCheckBox(rundomInt[i]).Click();
            }
        }

        public void SetAvatarImg()
        {
            uploadLink.Click();
            OpenFile.Open();
        }

        public void ClickNextButton()
        {
            nextButton.Click();
        }

        public char GetNumberOfCard()
        {
            return pageIndicator.GetText()[0];
        }
    }
}
