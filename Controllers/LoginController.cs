using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCore.Pages;
using SeleniumCore.Utils;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumCore.Controllers
{
    [Binding]
    public class LoginController : CommonInterfaceMethods
    {
        private IWebDriver _driver;
        LoginPage loginPage;
        ScenarioContext scenarioContext;

        public LoginController(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            loginPage = new LoginPage();
            _driver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            this.scenarioContext = scenarioContext;
        }

        public LoginController SetUsername(string username)
        {
            _driver.FindElement(loginPage.InputUsername).SendKeys(username);
            return this;
        }

        public LoginController SetPassword(string pass)
        {
            _driver.FindElement(loginPage.InputPassword).SendKeys(pass);
            return this;
        }

        public productsController ClickBtnLogin()
        {
            _driver.FindElement(loginPage.BtnLogin).Click();
            return new productsController(scenarioContext);
        }

        public bool ExisteBtnLogin()
        {
            return ExisteElemento(loginPage.BtnLogin, _driver);
        }

        public bool ExisteBtnError()
        {
            return ExisteElemento(loginPage.btnError, _driver);
        }
    }
}
