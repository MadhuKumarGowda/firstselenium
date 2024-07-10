using OpenQA.Selenium;

namespace firstselenium.Pages
{
    internal class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));
        IWebElement txtUsername => driver.FindElement(By.Name("UserName"));
        IWebElement txtPassword => driver.FindElement(By.Id("Password"));
        IWebElement btnLogin => driver.FindElement(By.ClassName("btn"));

        IWebElement LnkEmpDetails => driver.FindElement(By.LinkText("Employee Details"));
        IWebElement LnkManageUsers => driver.FindElement(By.LinkText("Manage Users"));
        IWebElement LnkLogOff => driver.FindElement(By.LinkText("Log off"));

        public void ClickLogin()
        {
            LoginLink.Click();
        }

        // Invoking click event using custom method
        public void ClickCusotmLogin()
        {
            SeleniumCustomMethodPOM.Click(LoginLink);
        }

        public void ClickExtendLogin()
        {
            LoginLink.Click();
        }

        public void Login(string username, string password)
        {
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
            btnLogin.Submit();
        }

        // Invoking Submit operation using cusomt methods
        public void CusomtLogin(string username, string password)
        {
            SeleniumCustomMethodPOM.EnterText(txtUsername, username);
            SeleniumCustomMethodPOM.EnterText(txtPassword, password);
            SeleniumCustomMethodPOM.Submit(btnLogin);
        }

        // Invoking Submit operation using cusomt methods
        public void CustomExtendLogin(string username, string password)
        {
            txtUsername.EnterText(username);
            txtPassword.EnterText(password);
            btnLogin.Submit();
        }

        public bool isLoggedIn()
        {
            return LnkEmpDetails.Displayed;
        }



    }
}
