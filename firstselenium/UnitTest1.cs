using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace firstselenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Assert.Pass();
            // Sudo code for setting up selenium
            // 1. Create a new instance of selenium web driver
            IWebDriver driver = new ChromeDriver();
            // Navigate to the URL
            driver.Navigate().GoToUrl("https://www.google.com/");
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            // Find the element
            IWebElement webElement = driver.FindElement(By.Name("q"));
            // Type in the element
            webElement.SendKeys("Madhu Kumar Gowda");
            // Click on the element
            webElement.SendKeys(Keys.Return);
        }
    }
}