using NUnit.Framework;
using OpenQA.Selenium;

namespace meddbase
{
    [TestFixture]
    class StartPage
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            Global.InitializeDriver(driver, "firefox");
            Global.LogIn(driver, "system10", "BRL.Automation", "aut0mati0n");
        }

        [Test]
        public void RunTest()
        {
            Assert.Pass();
        }

        [TearDown]
        public void Terminate()
        {
            Global.TerminateDriver(driver);
        }
    }
}
