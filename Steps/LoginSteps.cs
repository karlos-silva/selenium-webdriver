using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumCore.Controllers;
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
        String url, CorrectUsername, wrongUsername, CorrectPassword, wrongPassword;
        IWebDriver _driver;
        LoginController login;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            appsettings = scenarioContext["APP_SETTINGS"] as IConfigurationRoot;

            url = appsettings.GetSection("baseUrl:url").Value;

            CorrectUsername = appsettings.GetSection("credenciais:correctUsername").Value;
            wrongUsername = appsettings.GetSection("credenciais:wrongUsername").Value;

            CorrectPassword = appsettings.GetSection("credenciais:correctPassword").Value;
            wrongPassword = appsettings.GetSection("credenciais:wrongPassword").Value;


            login = new LoginController(scenarioContext);
        }


        [Given(@"Que o usuário esteja na página de login")]
        public void DadoQueOUsuarioEstejaNaPaginaDeLogin()
        {
            _driver.Navigate().GoToUrl(url);

            login.ExisteBtnLogin();
        }
        
        [Given(@"Informar as credenciais corretamente")]
        [When(@"Informar as credenciais corretamente")]
        public void QuandoInformarAsCredenciaisCorretamente()
        {
            login
                .SetUsername(CorrectUsername)
                .SetPassword(CorrectPassword)
                .ClickBtnLogin();
        }
        
        [When(@"Informar as credenciais ""(.*)""")]
        public void QuandoInformarAsCredenciais(string incorretas)
        {

            switch (incorretas)
            {
                case "username vazio":

                    login
                        .SetUsername("")
                        .SetPassword(CorrectPassword)
                        .ClickBtnLogin();
                    break;

                case "username invalido":
                    login
                        .SetUsername(wrongUsername)
                        .SetPassword(CorrectPassword)
                        .ClickBtnLogin();
                    break;

                case "password vazio":
                    login
                        .SetUsername(CorrectUsername)
                        .SetPassword("")
                        .ClickBtnLogin();
                    break;

                case "password invalido":
                    login
                        .SetUsername(CorrectUsername)
                        .SetPassword(wrongPassword)
                        .ClickBtnLogin();
                    break;
            }

        }
        
        [Then(@"Sera redirecionado para a tela de Produtos")]
        public void EntaoSeraRedirecionadoParaATelaDeProdutos()
        {
            login.TakeScreenShoot();
            Assert.IsTrue(_driver.Url.Contains("inventory.html"));
        }
        
        [Then(@"Será exibida uma mensagem informando o erro")]
        public void EntaoSeraExibidaUmaMensagemInformandoOErro()
        {
            login.TakeScreenShoot();
            Assert.IsTrue(login.ExisteBtnError());
        }
    }
}
