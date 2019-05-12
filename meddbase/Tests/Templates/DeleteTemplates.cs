using Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace meddbase
{
    [TestFixture]
    class DeleteTemplates
    {
        readonly IWebDriver driver = Global.InitializeDriver("firefox");

        [OneTimeSetUp]
        public void Initialize()
        {
            Global.TestSetup(driver, Global.GetSystems()[0], Global.GetCredentials()[0].Item1, Global.GetCredentials()[0].Item2);
        }

        [Test, Order(1)]
        public void AssertTemplatesPage()
        {
            Global.GetStartPageTile(driver, "Templates").Click();
            Assert.AreEqual(driver.Title, "Templates");
        }

        [Test, Order(2)]
        public void DeleteDocumentType()
        {
            driver.FindElement(By.XPath("//div[contains(text(), 'AUTOMATION')]")).Click();
            driver.FindElement(By.XPath("//div[contains(text(), 'Delete type')]")).Click();
            driver.FindElement(By.CssSelector("input.MessageBoxButton[value='Yes']")).Click();
            Assert.IsFalse(driver.FindElement(By.XPath("//div[contains(text(), 'AUTOMATION')]")).Displayed);
        }

        [OneTimeTearDown]
        public void Terminate()
        {
            Global.TerminateDriver(driver);
        }
    }
}
