using OpenQA.Selenium;
using SeleniumCore.Pages;
using SeleniumCore.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumCore.Controllers
{
    public class CheckoutController : CommonInterfaceMethods
    {
        ScenarioContext scenarioContext;
        private IWebDriver _driver;
        CheckoutPage checkoutController;
        public CheckoutController(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _driver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            checkoutController = new CheckoutPage();
            this.scenarioContext = scenarioContext;
        }

        public bool ExisteCheckoutContainer()
        {
            return ExisteElemento(checkoutController.checkoutContainer, _driver);
        }
    }
}
