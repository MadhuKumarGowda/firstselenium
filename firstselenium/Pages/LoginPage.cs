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

        public void ClickLogin()
        {
            LoginLink.Click();
        }

        public void Login(string username, string password)
        {
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
            btnLogin.Submit();
        }
                


    }
}
