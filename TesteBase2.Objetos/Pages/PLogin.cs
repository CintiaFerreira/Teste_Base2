using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBase2.Objetos.Pages
{
    public class PLogin
    {
        IWebDriver _driver;
        public Browser _browser { get; set; }
        int _timeoutSeconds;

        public PLogin(IWebDriver driver, int timeoutSeconds)
        {
            _driver = driver;
            _timeoutSeconds = timeoutSeconds;
        }
        public void Visit()
        {
            _browser = new Browser(_driver);
            _browser.GoTo("https://mantis-prova.base2.com.br/");
        }
        public IWebElement getuser()
        {
            return _driver.FindElement(By.Name("username"), _timeoutSeconds);
        }
        public IWebElement getpassword()
        {
            return _driver.FindElement(By.Name("password"), _timeoutSeconds);
        }
        public IWebElement login()
        {
            return _driver.FindElement(By.ClassName("button"), _timeoutSeconds);
        }
        public void GetLogin(string user, string password)
        {
            var userInput = getuser();
            var passwordInput = getpassword();
            var loginButton = login();
            userInput.Clear();
            userInput.SendKeys(user);
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            loginButton.Click();
        }
        public void GetLoginTrue()
        {
            string user = "cintia.ferreira";
            string password = "Cf@84125969";
            GetLogin(user, password);
        }
    }
}
