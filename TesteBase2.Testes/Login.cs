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
    class Login
    {
        public IWebDriver _driver { get; private set; }
        public PLogin _Login { get; private set; }
        public Browser _browser { get; private set; }
        public Print _print { get; private set; }
        public int _timeoutSeconds { get; private set; }
        public PMyView _PMyView { get; private set; }

        public string path = @"C:\Users\Cintia\desktop";

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _Login = new PLogin(_driver, _timeoutSeconds);
            _browser = new Browser(_driver);
            _print = new Print(_driver);
            _Login.Visit();
            _browser.Maximizar();
        }
        [Test]
        public void SucessLogin()
        {
            _Login.GetLoginTrue();
            _PMyView = new PMyView(_driver, _timeoutSeconds);
            Assert.AreEqual(_PMyView.TextoAcessandoComo().Text, "cintia.ferreira");
        }
        [Test, Pairwise]
        public void FailLogin(
            [Values("usererror", "!?", "")] string user,
            [Values("pass", "!?", "")] string password)
        {
            _Login.GetLogin(user, password);
            _PMyView = new PMyView(_driver, _timeoutSeconds);
            Assert.IsTrue(_PMyView.TextoSenhaUsuarioIncorreta().Displayed);
            bool presencaTextoAcessandoComo = _driver.ElementIsPresent(_PMyView.byAcessandoComo());
            Assert.IsFalse(presencaTextoAcessandoComo);
        }
        [TearDown]
        public void TearDown()
        {
            _browser.CloseBrowser();
            if (_driver != null)
                _driver.Dispose();

        }
    }
}
