using OpenQA.Selenium;
using SeleniumCore.Pages;
using SeleniumCore.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumCore.Controllers
{
    public class CartController : CommonInterfaceMethods
    {
        IWebDriver _driver;
        CartPage cartpage;
        ScenarioContext scenarioContext;
        private CommonSystemMethods utils => new CommonSystemMethods();

        public CartController(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _driver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            cartpage = new CartPage();
            this.scenarioContext = scenarioContext;
        }

        public Boolean GetValueCart(String quantidadeItens)
        {

            if (quantidadeItens == _driver.FindElement(cartpage.ItemsCount).Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CartController CartContainItems()
        {
            if(ExisteElemento(By.XPath("//div[@id = 'shopping_cart_container']/a/span"), _driver))
            {
                throw new Exception("Carrinho Contém itens!");
            }

            return this;
        }

        public CheckoutController GoToCheckout()
        {
            _driver.FindElement(cartpage.BtnCheckout).Click();
            return new CheckoutController(scenarioContext);
        }

        public void TakeScreenShoot()
        {
            utils.TakeScreenShoot(_driver, "ScreenshotCarrinho");
        }


    }

}
