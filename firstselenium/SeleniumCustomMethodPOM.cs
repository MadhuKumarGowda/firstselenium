using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstselenium
{
    internal class SeleniumCustomMethodPOM
    {
        public static void Click(IWebElement locator)
        {
            locator.Click();
        }

        public static void Submit(IWebElement locator)
        {
            locator.Submit();
        }

        public static void EnterText(IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void SelectDropDownByText(IWebElement locator, string text)
        {
            SelectElement selectElement = new SelectElement(locator);
            selectElement.SelectByText(text);
        }

        public static void SelectDropDownByValue(IWebElement locator, string value)
        {
            SelectElement selectElement = new SelectElement(locator);
            selectElement.SelectByValue(value);
        }

        public static void MultiSelectElements(IWebElement locator, string[] values)
        {
            SelectElement multiSelect = new SelectElement(locator);
            foreach (var value in values)
            {
                multiSelect.SelectByValue(value);
            }
        }

        public static List<string> GetAllSelectedListItems(IWebElement locator)
        {
            List<string> options = new List<string>();
            SelectElement multiSelect = new SelectElement(locator);
            IList<IWebElement> selectedOptions = multiSelect.AllSelectedOptions;

            foreach (IWebElement option in selectedOptions)
            {
                options.Add(option.Text);
            }

            return options;
        }
    }
}
