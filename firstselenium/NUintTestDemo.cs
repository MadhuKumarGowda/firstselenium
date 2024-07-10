using firstselenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace firstselenium
{
    [TestFixture("admin","password")]
    internal class NUintTestDemo
    {

        private IWebDriver _driver;
        private readonly string _username;
        private readonly string _password;

        public NUintTestDemo(string username, string password)
        {
            this._username = username;
            this._password = password;
        }

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http:/eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [Category("smoke")]
        public void TestWithPOM()
        {
           
            // POM initalization
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(_username, _password);
        }

        [Test]
        [TestCase("chrome", "30")]
        public void TestBrowserVersions(string browser, string version)
        {
            Console.WriteLine($"The Browser is {browser} with version {version}");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
