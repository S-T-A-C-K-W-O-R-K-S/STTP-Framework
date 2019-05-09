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

        [Test, Order(2)] // this needs to be the last one, after deleting all the documents under the document type
        public void DeleteDocumentType()
        {
            driver.FindElement(By.XPath("//div[contains(text(), 'AUTOMATION')]")).Click();
            driver.FindElement(By.XPath("//div[contains(text(), 'Delete type')]")).Click();
            driver.FindElement(By.CssSelector("input.MessageBoxButton[value='Yes']")).Click();
            Assert.IsFalse(driver.FindElement(By.XPath("//div[contains(text(), 'AUTOMATION')]")).Enabled);
        }

        [OneTimeTearDown]
        public void Terminate()
        {
            WebDriverHelpers.TerminateDriver(driver);
        }
    }
}
