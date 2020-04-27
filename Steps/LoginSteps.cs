using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumCore.Hooks;
using SeleniumExtras.WaitHelpers;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SeleniumCore.Steps
{
    [Binding]
    public class LoginSteps 
    {
        IConfigurationRoot appsettings;
        String url;
        String username;
        String password;
        IWebDriver _driver;
        public LoginSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            appsettings = scenarioContext["APP_SETTINGS"] as IConfigurationRoot;

            url = appsettings.GetSection("baseUrl:url").Value;
            username = appsettings.GetSection("credenciais:username").Value;
            password = appsettings.GetSection("credenciais:password").Value;
        }


        [Given(@"Que o usuário esteja na página de login")]
        public void DadoQueOUsuarioEstejaNaPaginaDeLogin()
        {
            _driver.Navigate().GoToUrl(url);

            var LoginButtonLocator = By.ClassName("btn_action");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(
                ExpectedConditions.ElementIsVisible(LoginButtonLocator));

        }
        
        [Given(@"Informar as credenciais corretamente")]
        [When(@"Informar as credenciais corretamente")]
        public void QuandoInformarAsCredenciaisCorretamente()
        {

            var inputUsername = _driver.FindElement(By.Id("user-name"));
            var inputPassword = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(By.ClassName("btn_action"));

            inputUsername.SendKeys(username);
            inputPassword.SendKeys(password);
            loginButton.Click();

        }
        
        [When(@"Informar as credenciais ""(.*)""")]
        public void QuandoInformarAsCredenciais(string incorretas)
        {
            var inputUsername = _driver.FindElement(By.Id("user-name"));
            var inputPassword = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(By.ClassName("btn_action"));

            switch (incorretas)
            {
                case "username vazio":
                    inputUsername.SendKeys("");
                    inputPassword.SendKeys("secret_sauce");
                    loginButton.Click();
                    break;

                case "username invalido":
                    inputUsername.SendKeys("incorreto");
                    inputPassword.SendKeys("secret_sauce");
                    loginButton.Click();
                    break;

                case "password vazio":
                    inputUsername.SendKeys("standard-user");
                    inputPassword.SendKeys("");
                    loginButton.Click();
                    break;

                case "password invalido":
                    inputUsername.SendKeys("standard-user");
                    inputPassword.SendKeys("incorreto");
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
