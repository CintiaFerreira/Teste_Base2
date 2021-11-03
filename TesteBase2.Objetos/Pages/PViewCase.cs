using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBase2.Objetos.Pages
{
    public class PViewCase
    {
        IWebDriver _driver;
        int _timeoutSeconds;

        public PViewCase(IWebDriver driver, int timeoutSeconds)
        {
            _driver = driver;
            _timeoutSeconds = timeoutSeconds;
        }

        public IWebElement DescricaoDoCaso()
        {
            return _driver.FindElement(By.XPath("/html/body/table[3]/tbody/tr[12]/td[2]"), _timeoutSeconds);
        }

       
    }
}
