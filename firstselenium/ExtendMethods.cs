using OpenQA.Selenium;

namespace firstselenium
{
    internal static class ExtendMethods
    {
        public static void Click(this IWebElement locator)
        {
            locator.Click();
        }

        public static void Submit(this IWebElement locator)
        {
            locator.Submit();
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }
    }
}
