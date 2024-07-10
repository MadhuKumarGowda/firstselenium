using firstselenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

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
        // Reading data from Login method as input
        [TestCaseSource(nameof(Login))]
        public void TestWithData(LoginModel loginmodel)
        {

            // POM initalization
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(loginmodel.username, loginmodel.password);
        }

        // Yield return fresh input value everytime
        // We can multiple test with different set of inputs
        public static IEnumerable<LoginModel> Login()
        {
            // Test1 with one set of inputs
            yield return new LoginModel()
            {
                username = "admin",
                password = "password",
            };

            // Test2 with one set of inputs
            //yield return new LoginModel()
            //{
            //    username = "admin",
            //    password = "password123",
            //};
        }

        // Test with input values from reading json file
        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void TestWithDataJsonSource(LoginModel loginmodel)
        {

            // POM initalization
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(loginmodel.username, loginmodel.password);
        }

        // Method to read json file and return to TEST
        public static IEnumerable<LoginModel> LoginJsonDataSource()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

            yield return loginModel;
        }


        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginMultiData))]
        public void TestWithMoreJsonSource(LoginModel loginmodel)
        {

            // POM initalization
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(loginmodel.username, loginmodel.password);
        }

        // Reading multiple set of inputs for login from json
        // Test wille execute as many set of data provied in json file
        public static IEnumerable<LoginModel> LoginMultiData()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logins.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);

            foreach (var loginData in loginModel)
                yield return loginData;
        }

        [Test]
        [Category("ddt")]

        public void TestWithJsonData()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

            // POM initalization
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(loginModel.username, loginModel.password);
        }

        // Reading single value from json
        private void ReadJsonFile()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            // Last option is to set ignopre the case senstive of the json data
            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        // Better test appraches is Arrange, Act and Assert
        // Arrange require page with require environements
        // Act is to perform action on web page to get the result
        // Assertion is to validate the result of ACT
        [Test]
        [Category("ddt")]
        // Reading data from Login method as input
        [TestCaseSource(nameof(Login))]
        public void TestWithAssertion(LoginModel loginmodel)
        {

            // POM initalization
            // Arrange
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(loginmodel.username, loginmodel.password);

            // Assertion
            var isLoggedIn = loginPage.isLoggedIn();
            Assert.IsTrue(isLoggedIn);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

