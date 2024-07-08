using firstselenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

        [Test]
        public void EAWebisteTest()
        {
            // Sudo code for setting up selenium
            // 1. Create a new instance of selenium web driver
            IWebDriver driver = new ChromeDriver();
            // 2. Maximize the chrome window
            driver.Manage().Window.Maximize();
            // 3. Navigate to the URL
            driver.Navigate().GoToUrl("http:/eaapp.somee.com/");
            // 4. Find the login link
            var loginLink = driver.FindElement(By.Id("loginLink"));
            //IWebElement loginLink = driver.FindElement(By.LinkText("Login"));
            // 5. Click on the login link
            loginLink.Click();
            // 6. Find the username text box
            var txtUsername = driver.FindElement(By.Name("UserName"));
            // 7. Enter username
            txtUsername.SendKeys("admin");
            // 8. Enter tab key
            txtUsername.SendKeys(Keys.Tab);
            // 9. Find password text box
            var txtpassword = driver.FindElement(By.Id("Password"));
            // 10. Enter password
            txtpassword.SendKeys("password");
            // 11. Enter tab
            txtpassword.SendKeys(Keys.Tab);
            // 12. identify login button
            var btnLogin = driver.FindElement(By.ClassName("btn"));
            // 13. Click login button
            btnLogin.Submit();
        }

        [Test]
        public void EAWebisteTestReducedCode()
        {
            // Sudo code for setting up selenium
            // 1. Create a new instance of selenium web driver
            IWebDriver driver = new ChromeDriver();
            // 2. Maximize the chrome window
            driver.Manage().Window.Maximize();
            // 3. Navigate to the URL
            driver.Navigate().GoToUrl("http:/eaapp.somee.com/");
            // 4. Find the login link
            driver.FindElement(By.Id("loginLink")).Click();
            // 5. Find the username text box
            driver.FindElement(By.Name("UserName")).SendKeys("admin");
            // 6. Find password text box
            driver.FindElement(By.Id("Password")).SendKeys("password");
            // 7. identify login button
            driver.FindElement(By.ClassName("btn")).Submit();
        }


        //[Test]
        public void WorkingWithAdvanceControls()
        {
            // Sudo code for setting up selenium
            // 1. Create a new instance of selenium web driver
            IWebDriver driver = new ChromeDriver();
            // 2. Maximize the chrome window
            driver.Manage().Window.Maximize();
            // 3. Navigate to the URL
            driver.Navigate().GoToUrl("http:/eaapp.somee.com/");      
            // 4. Working with Dropdown with select option
            // Need to install new package called selenium.support from NuGet packages
            SelectElement selectElement = new SelectElement(driver.FindElement(By.Id("dropdown")));
            selectElement.SelectByText("Option 2");
            // 5. Working with multi select options
            SelectElement multiSelected = new SelectElement(driver.FindElement(By.Id("dropdown")));
            multiSelected.SelectByValue("Multi 1");
            multiSelected.SelectByValue("Multi 2");

            // Step to verify what are options being selected from above code
            IList<IWebElement> selectedOptions = multiSelected.AllSelectedOptions;

            foreach (IWebElement option in selectedOptions)
            {
                Console.WriteLine(option.Text);
            }

        }

        [Test]
        public void workingwithCustomMethods()
        {
            // Sudo code for setting up selenium
            // 1. Create a new instance of selenium web driver
            IWebDriver driver = new ChromeDriver();
            // 2. Maximize the chrome window
            driver.Manage().Window.Maximize();
            // 3. Navigate to the URL
            driver.Navigate().GoToUrl("http:/eaapp.somee.com/");
            // 4. Find the login link using custom method            
            SeleniumCustomMethods.Click(driver, By.Id("loginLink"));
            // 5. Find the username text box and enter user name by using cutom methods
            SeleniumCustomMethods.EnterText(driver, By.Name("UserName"), "admin");           
            // 6. Find the password text box and enter password by using cutom methods
            SeleniumCustomMethods.EnterText(driver, By.Id("Password"), "password");            
            // 7. identify login button
            driver.FindElement(By.ClassName("btn")).Submit();

        }

        [Test]
        public void advanceMethodswithCustom()
        {
            // Sudo code for setting up selenium
            // 1. Create a new instance of selenium web driver
            IWebDriver driver = new ChromeDriver();
            // Select dropdown by text using custom methods
            SeleniumCustomMethods.SelectDropDownByText(driver, By.Id("dropdown"), "Option 2");
            string []multiOptions = { "multi 1", "multi 2" };
            SeleniumCustomMethods.MultiSelectElements(driver, By.Id("dropdown"), multiOptions);
            var selectedOptions = SeleniumCustomMethods.GetAllSelectedListItems(driver, By.Id("dropdown"));
            selectedOptions.ForEach(Console.WriteLine);

        }

        [Test]
        public void TestWithPOM()
        {
            // Sudo code for setting up selenium
            // 1. Create a new instance of selenium web driver
            IWebDriver driver = new ChromeDriver();
            // 2. Maximize the chrome window
            driver.Manage().Window.Maximize();
            // 3. Navigate to the URL
            driver.Navigate().GoToUrl("http:/eaapp.somee.com/");
            // POM initalization
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLogin();
            loginPage.Login("admin","password");
        }

        [Test]
        public void TestWithPOMCusotmMethods()
        {
            // Sudo code for setting up selenium
            // 1. Create a new instance of selenium web driver
            IWebDriver driver = new ChromeDriver();
            // 2. Maximize the chrome window
            driver.Manage().Window.Maximize();
            // 3. Navigate to the URL
            driver.Navigate().GoToUrl("http:/eaapp.somee.com/");
            // POM initalization
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickCusotmLogin();
            loginPage.CusomtLogin("admin", "password");
        }

        [Test]
        public void TestWithPOMCusotmExtendMethods()
        {
            // Sudo code for setting up selenium
            // 1. Create a new instance of selenium web driver
            IWebDriver driver = new ChromeDriver();
            // 2. Maximize the chrome window
            driver.Manage().Window.Maximize();
            // 3. Navigate to the URL
            driver.Navigate().GoToUrl("http:/eaapp.somee.com/");
            // POM initalization
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickExtendLogin();
            loginPage.CustomExtendLogin("admin", "password");
        }
    }
}