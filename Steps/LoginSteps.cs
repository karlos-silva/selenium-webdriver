using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumCore.Hooks;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SeleniumCore.Steps
{
    [Binding]
    public class LoginSteps 
    {

        IWebDriver _driver;
        public LoginSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }


        [Given(@"Que o usuário esteja na página de login")]
        public void DadoQueOUsuarioEstejaNaPaginaDeLogin()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var LoginButtonLocator = By.ClassName("btn_action");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(
                ExpectedConditions.ElementIsVisible(LoginButtonLocator));

        }
        
        [Given(@"Informar as credenciais corretamente")]
        [When(@"Informar as credenciais corretamente")]
        public void QuandoInformarAsCredenciaisCorretamente()
        {

            var username = _driver.FindElement(By.Id("user-name"));
            var password = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(By.ClassName("btn_action"));

            username.SendKeys("standard_user");
            password.SendKeys("secret_sauce");
            loginButton.Click();

        }
        
        [When(@"Informar as credenciais ""(.*)""")]
        public void QuandoInformarAsCredenciais(string incorretas)
        {
            var username = _driver.FindElement(By.Id("user-name"));
            var password = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(By.ClassName("btn_action"));

            switch (incorretas)
            {
                case "username vazio":
                    username.SendKeys("");
                    password.SendKeys("secret_sauce");
                    loginButton.Click();
                    break;

                case "username invalido":
                    username.SendKeys("incorreto");
                    password.SendKeys("secret_sauce");
                    loginButton.Click();
                    break;

                case "password vazio":
                    username.SendKeys("standard-user");
                    password.SendKeys("");
                    loginButton.Click();
                    break;

                case "password invalido":
                    username.SendKeys("standard-user");
                    password.SendKeys("incorreto");
                    loginButton.Click();
                    break;
            }

        }
        
        [Then(@"Sera redirecionado para a tela de Produtos")]
        public void EntaoSeraRedirecionadoParaATelaDeProdutos()
        {
            Assert.IsTrue(_driver.Url.Contains("inventory.html"));
        }
        
        [Then(@"Será exibida uma mensagem informando o erro")]
        public void EntaoSeraExibidaUmaMensagemInformandoOErro()
        {
            Assert.IsTrue(_driver.FindElement(By.ClassName("error-button")).Displayed);

        }
    }
}
