using OpenQA.Selenium;
using SeleniumCore.Pages;
using SeleniumCore.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumCore.Controllers
{
    public class productsController : CommonInterfaceMethods
    {
        ScenarioContext scenarioContext;
        private IWebDriver _driver;
        ProductsPage productsPage;
        public productsController(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _driver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            productsPage = new ProductsPage();
            this.scenarioContext = scenarioContext;
        }

        public void AddItemToCart(int num)
        {
            while (num != 0)
            {
                _driver.FindElement(productsPage.BtnAddToCart).Click();
                num--;
            }
        }

        public CartController GoToCart()
        {
            _driver.FindElement(productsPage.BtnGoToCart).Click();
            return new CartController(scenarioContext);
        }


    }
}
