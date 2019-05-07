using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace meddbase
{
    [TestFixture]
    class AssertLogin
    {
        readonly IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            Global.InitializeDriver(driver, "firefox");
            Global.LogIn(driver, "system10", "BRL.Automation", "aut0mati0n");
        }

        [Test]
        public void RunTest()
        {
            Console.WriteLine("This Is AssertLogin.CS");
        }

        [TearDown]
        public void Terminate()
        {
            Global.TerminateDriver(driver);
        }
    }
}
