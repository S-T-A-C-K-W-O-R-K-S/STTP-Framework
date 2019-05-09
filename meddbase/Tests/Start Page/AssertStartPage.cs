using NUnit.Framework;
using OpenQA.Selenium;
using Helpers;

namespace meddbase
{
    [TestFixture]
    class AssertStartPage
    {
        readonly IWebDriver driver = WebDriverHelpers.InitializeDriver("firefox");

        [SetUp]
        public void Initialize()
        {
            WebDriverHelpers.TestSetup(driver, "system10", TestDataHelpers.GetCredentials()[0].Item1, TestDataHelpers.GetCredentials()[0].Item2);
        }

        [Test]
        public void AssertLogin()
        {
            Assert.AreEqual(driver.Title, "Start Page");
        }

        [TearDown]
        public void Terminate()
        {
            WebDriverHelpers.TerminateDriver(driver);
        }
    }
}
