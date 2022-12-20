using NUnit.Framework;
using TheInternetTests.PageObjects;
using TheInternetTests.Utils;

namespace TheInternetTests.Tests
{
    public class AlertsTest : BaseTest
    {
        /*[SetUp]
        public void Setup()
        {
            BrowserFactory.WebDriver.Url = GetTestData.Get("projectData", "url") + 
                GetTestData.Get("alertsData","urlForAlerts");
        }*/

        [Test]
        public void Test()
        {

            int a = 128;
            sbyte b = (sbyte)a;
            System.Console.WriteLine(a.ToString());


            AlertPageObject alertPageObject = new AlertPageObject();
            
            Assert.IsTrue(alertPageObject.IsAlertPage(), "Key item not found.");

            alertPageObject.ClickForJSAlertButton();
            Assert.AreEqual("I am a JS Alert", DriverUtils.GetAlertText(), "Messages in alert differ.");
            
            DriverUtils.ClickOkOnAlert();
            Assert.AreEqual("You successfully clicked an alert", alertPageObject.GetResult(), "Result messages vary.");

            alertPageObject.ClickForJSConfirmButton();
            Assert.AreEqual("I am a JS Confirm", DriverUtils.GetAlertText(), "Messages in alert differ.");

            DriverUtils.ClickOkOnAlert();
            Assert.AreEqual("You clicked: OK", alertPageObject.GetResult(), "Result messages vary.");

            alertPageObject.ClickForJSPromptButton();
            Assert.AreEqual("I am a JS prompt", DriverUtils.GetAlertText(), "Messages in alert differ.");

            DriverUtils.ClickOkOnAlert();
            Assert.AreEqual("You entered:", alertPageObject.GetResult(), "Result messages vary.");
        }
    }
}
