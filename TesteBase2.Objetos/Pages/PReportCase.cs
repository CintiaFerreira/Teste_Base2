using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBase2.Objetos.Pages
{
    public class PReportCase
    {
        IWebDriver _driver;
        public Browser _browser;
        int _timeoutSeconds;

        public PReportCase(IWebDriver driver, int timeoutSeconds)
        {
            _driver = driver;
            _timeoutSeconds = timeoutSeconds;
        }

        public enum Categoria
        {
            Selecione = 1,
            app_14 = 42,
            Appteste = 43,
            DesafiojMeter = 45,
            General = 1,
            Principado = 34,
            TesteCintia = 33
        }
        public void PreencherListaCategoria(Categoria categoria)
        {
            _driver.FindElement(By.Name("category_id"), _timeoutSeconds).Click();
            _driver.FindElement(By.XPath("//option[@value='" + (int)categoria + "']"), _timeoutSeconds).Click();
        }
        public void PreencherTextAreaDescrição(string descricao)
        {
            _driver.FindElement(By.Name("description"), _timeoutSeconds).SendKeys(descricao);
        }

        public void PreencherInputResumo(string resumo)
        {
            _driver.FindElement(By.Name("summary"), _timeoutSeconds).SendKeys(resumo);
        }

        public void ClicarButtonEnviarRelatorio()
        {
            _driver.FindElement(By.XPath("/html/body/div[3]/form/table/tbody/tr[15]/td[2]/input"), _timeoutSeconds).Click();
        }

        public void RelatarCasoPreenchendoCamposObrigatorios(Categoria categoria, string resumo, string descricao)
        {
            PreencherListaCategoria(categoria);
            PreencherInputResumo(resumo);
            PreencherTextAreaDescrição(descricao);
            ClicarButtonEnviarRelatorio();
        }

        public void Visit()
        {
            _browser = new Browser(_driver);
            _browser.GoTo("http://mantis-prova.base2.com.br/bug_report_page.php");
        }
    }
}
