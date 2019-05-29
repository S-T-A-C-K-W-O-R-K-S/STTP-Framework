using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace meddbase.Helpers
{
    partial class Global
    {
        public static IWebElement GetDropdown(IWebDriver webdriver, string id)
        {
            return webdriver.FindElement(By.CssSelector($"#{id}"));
        }

        public static IList<IWebElement> GetDropdownOptions(IWebElement dropdown)
        {
            SelectElement select = new SelectElement(dropdown);

            return select.Options;
        }

        public static void SetDropdownOption(IWebElement dropdown, string option)
        {
            SelectElement select = new SelectElement(dropdown);

            select.SelectByText(option);
        }
    }
}
