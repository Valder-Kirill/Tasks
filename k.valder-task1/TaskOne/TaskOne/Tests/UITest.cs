using NUnit.Framework;
using System;
using TaskOne.PageObjects;
using TaskOne.Utils;
using TheInternetTests.Tests;

namespace TaskOne.Tests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.Self)]
    public class UITest : BaseTest
    {
        [Test]
        public void TestCase1()
        {
            HomePageObject homePageObject = new HomePageObject();
            LoginPageObject loginForm = new LoginPageObject();
            AvatarAndInterestsForm avatarAndInterestsForm = new AvatarAndInterestsForm();
            PersonalDetailPageObject personalDetailPageObject = new PersonalDetailPageObject();
            
            Assert.IsTrue(homePageObject.IsHomePage(), "Page not open.");

            homePageObject.ClickOnLink();
            Assert.AreEqual(GetTestData.Get("cardNumbersData", "one"), loginForm.GetNumberOfCard().ToString(), "Card not open or wrong card open.");

            loginForm.SetPassword(RandomUtil.Pass());
            loginForm.SetMailName(RandomUtil.Pass());
            loginForm.SetDomainTwo(RandomUtil.Pass());
            loginForm.SetDomainOne(RandomUtil.DomainOne());
            loginForm.AcceptTerms();
            loginForm.ClickNextButton();
            Assert.AreEqual(GetTestData.Get("cardNumbersData", "two"), avatarAndInterestsForm.GetNumberOfCard().ToString(), "Card not open or wrong card open.");
            
            avatarAndInterestsForm.SetAvatarImg();
            avatarAndInterestsForm.ClickOnUnselectall();
            avatarAndInterestsForm.ClickOnInterests(Convert.ToInt32(GetTestData.Get("interests", "interestsCount")));
            avatarAndInterestsForm.ClickNextButton();
            personalDetailPageObject.State.WaitForDisplayed();
            Assert.AreEqual(GetTestData.Get("cardNumbersData", "three"), personalDetailPageObject.GetNumberOfCard().ToString(), "Card not open or wrong card open.");
        }
    }
}