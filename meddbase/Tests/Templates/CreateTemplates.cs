using Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace meddbase
{
    [TestFixture]
    class CreateTemplates
    {
        readonly IWebDriver driver = WebDriverHelpers.InitializeDriver("firefox");

        IWebElement GetNewButton()
        {
            IWebElement newButton = driver.FindElement(By.XPath("//div[contains(text(), 'New')]"));
            return newButton;
        }

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

        [Test, Order(2)]
        public void CreateDocumentType()
        {
            GetNewButton().Click();
            driver.FindElement(By.XPath("//div[contains(text(), 'Document type')]")).Click();
            driver.FindElement(By.CssSelector("input#TypeName")).SendKeys("AUTOMATION");
            driver.FindElement(By.CssSelector("input[value='Save']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//div[contains(text(), 'AUTOMATION')]")).Enabled);
        }

        [OneTimeTearDown]
        public void Terminate()
        {
            WebDriverHelpers.TerminateDriver(driver);
        }
    }
}
