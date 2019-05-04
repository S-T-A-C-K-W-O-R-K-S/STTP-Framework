using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;

namespace Helpers
{
    class Helpers
    {
        public static IWebDriver driver;

        private static void Main()
        {
            Login("firefox", "testb1", "LAB.Automation", "aut0mati0n");
            driver.Quit();
        }

        public static void Login(string browser, string system, string username, string password)
        {
            switch (browser)
            {
                case "firefox":
                    driver = new FirefoxDriver(AppDomain.CurrentDomain.BaseDirectory);
                    driver.Manage().Window.Maximize();
                    break;
                case "chrome":
                    driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
                    driver.Manage().Window.Maximize();
                    break;
                case "edge":
                    driver = new EdgeDriver(AppDomain.CurrentDomain.BaseDirectory);
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    throw new Exception("IWebDriver Uninitialized");
            }

            string endpoint = $"https://{system}.meddbase.com/em.aspx/?p=Login/Password&direct=true";
            driver.Navigate().GoToUrl(endpoint);

            IWebElement UsernameInput = driver.FindElement(By.CssSelector("#MasterPage_UserName"));
            IWebElement PasswordInput = driver.FindElement(By.CssSelector("#LoginPasswordTextbox > div > input[type=password]"));
            IWebElement LoginButton = driver.FindElement(By.CssSelector("#LoginButtonContainer > input"));

            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
        }
    }
}
