using NUnit.Framework;

namespace TheInternetTests.Tests
{
    public class BaseTest
    {
        [TearDown]
        public void TearDown()
        {
            BrowserFactory.StopBrowser();
        }
    }
}
