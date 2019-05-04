using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;

namespace meddbase
{
    public class TestSetup
    {
        public IWebDriver Driver { get; set; }
        public string Browser { get; set; }
        public string System { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public TestSetup(IWebDriver driver, string browser, string system, string username, string password)
        {
            Driver = driver; Browser = browser; System = system; Username = username; Password = password;

            switch (browser)
            {
                case "firefox":
                    Driver = new FirefoxDriver(AppDomain.CurrentDomain.BaseDirectory);
                    Driver.Manage().Window.Maximize();
                    break;
                case "chrome":
                    Driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
                    Driver.Manage().Window.Maximize();
                    break;
                case "edge":
                    Driver = new EdgeDriver(AppDomain.CurrentDomain.BaseDirectory);
                    Driver.Manage().Window.Maximize();
                    break;
                default:
                    throw new Exception("IWebDriver Uninitialized");
            }

            string endpoint = $"https://{system}.meddbase.com/em.aspx/?p=Login/Password&direct=true";
            Driver.Navigate().GoToUrl(endpoint);

            IWebElement UsernameInput = Driver.FindElement(By.CssSelector("#MasterPage_UserName"));
            IWebElement PasswordInput = Driver.FindElement(By.CssSelector("#LoginPasswordTextbox > div > input[type=password]"));
            IWebElement LoginButton = Driver.FindElement(By.CssSelector("#LoginButtonContainer > input"));

            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
        }
    }
}
