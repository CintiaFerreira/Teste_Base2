using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TesteBase2.Objetos;
using TesteBase2.Objetos.Pages;

namespace TesteBase2.Testes
{
    [TestFixture]
    public class ReportCase
    {
        public Browser _browser;
        public PLogin _PLogin;
        public Print _Print;
        public PReportCase _pReportCase;
        public PMyView _pMyView;
        int _timeoutSeconds = 10;
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();

            _PLogin = new PLogin(driver, _timeoutSeconds);
            _browser = new Browser(driver);
            _browser.Maximizar();
            _Print = new Print(driver);
            _pReportCase = new PReportCase(driver, _timeoutSeconds);
            _pMyView = new PMyView(driver, _timeoutSeconds);
            _PLogin.Visit();
            _PLogin.GetLoginTrue();
            _pReportCase.Visit();
            



        }
        [TearDown]
        public void TearDown()
        {
            _browser.CloseBrowser();

            if (driver != null)
                driver.Dispose();
        }

        [Test]
        public void ReportCaseFillAndSalve()
        {
            _pReportCase.RelatarCasoPreenchendoCamposObrigatorios(PReportCase.Categoria.TesteCintia, "teste", "resumoteste");
            Assert.IsTrue(_pMyView.MensagemOperacaoRealizadaComSucesso().Displayed);
        }
        [Test]
        public void ReportCaseNotFillAndSalve()
        {
            _pReportCase.RelatarCasoPreenchendoCamposObrigatorios(PReportCase.Categoria.TesteCintia, "resumoteste", "");
            Assert.IsTrue(_pMyView.Erro11CampoObrigatorioNaoPreenchido().Displayed);
            bool presencaOperacaoRealizadaComSucesso = driver.ElementIsPresent(_pMyView.ByMensagemOperacaoRealizadaComSucesso());
            Assert.AreEqual(presencaOperacaoRealizadaComSucesso, true);
        }
    }
}