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
            Global.TestSetup(driver, "system10", "BRL.Automation", "aut0mati0n");
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
