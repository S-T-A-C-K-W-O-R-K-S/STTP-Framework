using NUnit.Framework;
using OpenQA.Selenium;
using Helpers;

namespace meddbase
{
    [TestFixture]
    class AssertStartPage
    {
        readonly IWebDriver driver = Global.InitializeDriver("firefox");

        [SetUp]
        public void Initialize()
        {
            Global.TestSetup(driver, Global.GetSystems()[0], Global.GetCredentials()[0].Item1, Global.GetCredentials()[0].Item2);
        }

        [Test]
        public void AssertLogin()
        {
            Assert.AreEqual(driver.Title, "Start Page");
        }

        [TearDown]
        public void Terminate()
        {
            Global.TerminateDriver(driver);
        }
    }
}
