using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBase2.Objetos;
using TesteBase2.Objetos.Pages;

namespace TesteBase2.Testes
{
    [TestFixture]
    class ViewCase
    {
        public Browser _browser;
        public PLogin _PLogin;
        public Print _Print;
        public PReportCase _PReportCase;
        public PMyView _pMyView;
        public PViewCase _pViewCase;

        int timeoutSeconds = 10;
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();

            _PLogin = new PLogin(driver, timeoutSeconds);
            _browser = new Browser(driver);
            _Print = new Print(driver);
            _PReportCase = new PReportCase(driver, timeoutSeconds);
            _pMyView = new PMyView(driver, timeoutSeconds);
            _pMyView = new PMyView(driver, timeoutSeconds);
            _pViewCase = new PViewCase(driver, timeoutSeconds);

            _PLogin.Visit();
            _browser.Maximizar();
            _PLogin.GetLoginTrue();
        }

        [TearDown]
        public void TearDown()
        {
            _browser.CloseBrowser();

            if (driver != null)
                driver.Dispose();
        }
        [Test]
        public void VerCasos_ValidarDadosDoCaso()
        {
            PReportCase.Categoria categoria = PReportCase.Categoria.TesteCintia;
            string resumo = "Resumo teste";
            string descricao = "Descrição teste";

            _PReportCase.Visit();
            _PReportCase.RelatarCasoPreenchendoCamposObrigatorios(categoria, resumo, descricao);

            _pMyView.ClicarEmVisualizarCasoEnviado();

            Assert.AreEqual(_pViewCase.DescricaoDoCaso().Text, descricao);
        }
    }
}
