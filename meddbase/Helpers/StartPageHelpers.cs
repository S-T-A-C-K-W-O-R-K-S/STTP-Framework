using OpenQA.Selenium;

namespace Helpers
{
    class StartPageHelpers
    {
        public static IWebElement GetStartPageTile(IWebDriver webdriver, string title)
        {
            IWebElement tile = webdriver.FindElement(By.XPath($"//div[contains(text(), '{title}')]"));
            return tile;
        }
    }
}
