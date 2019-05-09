using Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace meddbase
{
    [TestFixture]
    class DeleteTemplates
    {
        readonly IWebDriver driver = WebDriverHelpers.InitializeDriver("firefox");

        [OneTimeSetUp]
        public void Initialize()
        {
            WebDriverHelpers.TestSetup(driver, "system10", TestDataHelpers.GetCredentials()[0].Item1, TestDataHelpers.GetCredentials()[0].Item2);
        }

        [Test, Order(1)]
        public void AssertTemplatesPage()
        {
            StartPageHelpers.GetStartPageTile(driver, "Templates").Click();
            Assert.AreEqual(driver.Title, "Templates");
        }

        [OneTimeTearDown]
        public void Terminate()
        {
            WebDriverHelpers.TerminateDriver(driver);
        }
    }
}
