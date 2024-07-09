using firstselenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace firstselenium
{
    internal class NUintTestDemo
    {

        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http:/eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestWithPOM()
        {
           
            // POM initalization
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login("admin", "password");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
