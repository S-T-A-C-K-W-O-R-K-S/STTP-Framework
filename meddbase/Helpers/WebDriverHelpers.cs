using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace meddbase.Helpers
{
    partial class Global
    {
        // In the final version of the code, this needs to be a "foreach webdriver" statement.
        public static IWebDriver InitializeDriver(string browser)
        {
            IWebDriver webdriver;

            switch (browser)
            {
                case "firefox":
                    webdriver = new FirefoxDriver(AppDomain.CurrentDomain.BaseDirectory);
                    webdriver.Manage().Window.Maximize();
                    return webdriver;
                case "chrome":
                    webdriver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
                    webdriver.Manage().Window.Maximize();
                    return webdriver;
                case "edge":
                    webdriver = new EdgeDriver(AppDomain.CurrentDomain.BaseDirectory);
                    webdriver.Manage().Window.Maximize();
                    return webdriver;
                default:
                    throw new Exception("IWebDriver Uninitialized");
            }
        }

        public static void TestSetup(IWebDriver webdriver, string system, string username, string password)
        {
            string endpoint = $"https://{system}.meddbase.com/em.aspx/?p=Login/Password&direct=true";
            webdriver.Navigate().GoToUrl(endpoint);

            IWebElement usernameInput = webdriver.FindElement(By.CssSelector("#MasterPage_UserName"));
            IWebElement passwordInput = webdriver.FindElement(By.CssSelector("#LoginPasswordTextbox > div > input[type=password]"));
            IWebElement loginButton = webdriver.FindElement(By.CssSelector("#LoginButtonContainer > input"));

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
            loginButton.Click();
        }

        public static void TerminateDriver(IWebDriver webdriver)
        {
            webdriver.Close();
            webdriver.Quit();
        }

        public static bool IsDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }

            catch
            {
                return false;
            }
        }
    }
}
