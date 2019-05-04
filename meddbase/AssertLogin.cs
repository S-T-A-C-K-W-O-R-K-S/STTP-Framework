using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using NUnit.Framework;

namespace meddbase
{
    class AssertLogin
    {
        /* THIS CODE IS SHIT !! */
        static IWebDriver driver;
        TestSetup setup = new TestSetup(driver, "firefox", "testb1", "LAB.Automation", "aut0mati0n");


        // [SetUp]

        // [TestCase("firefox", "testb1", "LAB.Automation", "aut0mati0n")]
        // [TestCase("chrome", "testb1", "LAB.Automation", "aut0mati0n")]
        //  [TestCase("edge", "testb1", "LAB.Automation", "aut0mati0n")]

        //  [Test]

        // [TearDown]
    }
}
