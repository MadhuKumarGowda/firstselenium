using firstselenium.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstselenium
{
    public class DataDrivenTesting
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
        [Category("ddt")]
        [TestCaseSource(nameof(Login))]
        public void TestWithData(LoginModel loginmodel)
        {

            // POM initalization
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(loginmodel.username, loginmodel.password);
        }

        public static IEnumerable<LoginModel> Login()
        {
            // Test1 with one set of inputs
            yield return new LoginModel()
            {
                username = "admin",
                password = "password",
            };

            // Test2 with one set of inputs
            yield return new LoginModel()
            {
                username = "admin",
                password = "password123",
            };
        }
       

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

