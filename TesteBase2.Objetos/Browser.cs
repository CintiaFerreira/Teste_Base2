using OpenQA.Selenium;

namespace TesteBase2.Objetos
{
    public class Browser
    {
        IWebDriver _driver;
        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }
        public void GoTo(string uri)
        {
            _driver.Navigate().GoToUrl(uri);
        }
        public void Maximizar()
        {
            _driver.Manage().Window.Maximize();
        }
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}
