using NUnit.Framework;
using OpenQA.Selenium;

namespace meddbase
{
    [TestFixture]
    class StartPage
    {
        readonly IWebDriver driver = Global.InitializeDriver("firefox");

        [SetUp]
        public void Initialize()
        {
            Global.TestSetup(driver, "system10", TestData.GetCredentials()[0].Item1, TestData.GetCredentials()[0].Item2);
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
