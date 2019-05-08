using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;

namespace meddbase
{
    class Global
    {
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

        public static List<Tuple<string, string>> GetCredentials()
        {
            List<Tuple<string, string>> credentials = new List<Tuple<string, string>>();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            dynamic json = JsonConvert.DeserializeObject(File.ReadAllText(projectDirectory + "\\Test Data\\dataset.json"));

            foreach (dynamic login in json.logins)
            {
                credentials.Add(Tuple.Create(login.username.ToString(), login.password.ToString()));
            }

            return credentials;
        }

        public static void TestSetup(IWebDriver webdriver, string system, string username, string password)
        {
            string endpoint = $"https://{system}.meddbase.com/em.aspx/?p=Login/Password&direct=true";
            webdriver.Navigate().GoToUrl(endpoint);

            IWebElement UsernameInput = webdriver.FindElement(By.CssSelector("#MasterPage_UserName"));
            IWebElement PasswordInput = webdriver.FindElement(By.CssSelector("#LoginPasswordTextbox > div > input[type=password]"));
            IWebElement LoginButton = webdriver.FindElement(By.CssSelector("#LoginButtonContainer > input"));

            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
        }

        public static void TerminateDriver(IWebDriver webdriver)
        {
            webdriver.Quit();
        }
    }
}
