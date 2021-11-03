using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBase2.Objetos.Pages
{
    public class PMyView
    {
        IWebDriver _driver;
        int _timeoutSeconds;

        public PMyView(IWebDriver driver, int timeoutSeconds)
        {
            _driver = driver;
            _timeoutSeconds = timeoutSeconds;
        }
        public IWebElement TextoAcessandoComo()
        {
            return _driver.FindElement(byAcessandoComo(), _timeoutSeconds);
        }

        public By byAcessandoComo()
        {
            return By.XPath("/html/body/table[1]/tbody/tr/td[1]/span[1]");
        }
        public IWebElement TextoSenhaUsuarioIncorreta()
        {
            return _driver.FindElement(By.XPath("//font[text() = 'Your account may be disabled or blocked or the username/password you entered is incorrect.']"), _timeoutSeconds);
        }
        public IWebElement MensagemOperacaoRealizadaComSucesso()
        {
            return _driver.FindElement(ByMensagemOperacaoRealizadaComSucesso());
        }
        public By ByMensagemOperacaoRealizadaComSucesso()
        {
            return By.XPath("/html/body/div[2]");
        }
        public IWebElement Erro11CampoObrigatorioNaoPreenchido()
        {
            return _driver.FindElement(By.XPath("//td[text()='APPLICATION ERROR #11']"), _timeoutSeconds);
        }
        public void ClicarEmVisualizarCasoEnviado()
        {
            _driver.FindElement(By.XPath("//*[@id=\"buglist\"]/tbody/tr[4]/td[4]/a"), _timeoutSeconds).Click();
        }
    }
}
