using Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace meddbase
{
    [TestFixture]
    class CreateTemplates
    {
        readonly IWebDriver driver = Global.InitializeDriver("firefox");

        IWebElement GetNewButton()
        {
            IWebElement newButton = driver.FindElement(By.XPath("//div[contains(text(), 'New')]"));
            return newButton;
        }

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
        public void CreateDocumentType()
        {
            GetNewButton().Click();
            driver.FindElement(By.XPath("//div[contains(text(), 'Document type')]")).Click();
            driver.FindElement(By.CssSelector("input#TypeName")).SendKeys("AUTOMATION");
            Global.SetDropdownOption(Global.GetDropdown(driver, "Policy"), "Medical Document");
            driver.FindElement(By.CssSelector("input[value='Save']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//div[contains(text(), 'AUTOMATION')]")).Enabled);
        }

        [OneTimeTearDown]
        public void Terminate()
        {
            Global.TerminateDriver(driver);
        }
    }
}
