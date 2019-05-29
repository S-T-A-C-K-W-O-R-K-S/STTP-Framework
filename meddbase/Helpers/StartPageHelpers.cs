using OpenQA.Selenium;

namespace meddbase.Helpers
{
    partial class Global
    {
        public static IWebElement GetStartPageTile(IWebDriver webdriver, string title)
        {
            IWebElement tile = webdriver.FindElement(By.XPath($"//div[contains(text(), '{title}')]"));
            return tile;
        }
    }
}
