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
    public class CarrinhoDeComprasSteps 
    {
        IWebDriver _driver;
        public CarrinhoDeComprasSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }


        public void addToCart(int num)
        {
            var buttonAddToCartLocator = By.XPath("//button[contains(text(), 'ADD TO CART')]");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(buttonAddToCartLocator));
            var buttonAddToCart = _driver.FindElement(buttonAddToCartLocator);

            while(num != 0)
            {
                buttonAddToCart.Click();
                num--;
            }

        }

        public Boolean ExisteElemento(By Locator)
        {
            bool isDisplayed = false;

            try
            {
                isDisplayed = _driver.FindElement(Locator).Displayed;           
            }
            catch (Exception e)
            {
                Console.Out.WriteLine($"Elemeto com locator {Locator} não foi localizado na tela causado por {e.Message}");
            }

            return isDisplayed;
        }


        public Boolean GetValueCart (String num)
        {
            var quantidadeItemsLocator = By.XPath("//div[@id = 'shopping_cart_container']/a/span");
            var quantidadeItems = _driver.FindElement(quantidadeItemsLocator);

            if(num == quantidadeItems.Text)
            {
                return true;
            }else
            {
                return false;
            }
        }

        [Given(@"que o usuário está no carrinho de compras")]
        public void DadoQueOUsuarioEstaNoCarrinhoDeCompras()
        {
            _driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        }
        
        [When(@"usuário não adicionar itens no carrinho")]
        public void DadoQueOUsuarioNaoAdicionouItensNoCarrinho()
        {
            var carrinhoContemItem = ExisteElemento(By.XPath("//div[@id = 'shopping_cart_container']/a/span"));
            if(carrinhoContemItem)
            {
                throw new Exception("Carrinho contém itens");
            }
        }
        
        [When(@"que o usuário adicionou no carrinho uma ""(.*)"":")]
        public void DadoQueOUsuarioAdicionouNoCarrinhoUma(int quantidade)
        {

            addToCart(quantidade);
            GetValueCart(quantidade.ToString());

        }
        
        [When(@"Clicar no botão checkout")]
        public void QuandoClicarNoBotaoCheckout()
        {
            var GoToCart = _driver.FindElement(By.XPath("//div[@id = 'shopping_cart_container']/a"));
            GoToCart.Click();
            var CheckoutButton = _driver.FindElement(By.ClassName("checkout_button"));
            CheckoutButton.Click();
        }
        
        [Then(@"O sistema solicitará as os dados de entrega")]
        public void EntaoOSistemaSolicitaraAsOsDadosDeEntrega()
        {
            Assert.IsTrue(_driver.Url.Contains("checkout-step-one.html"));

        }

        [Then(@"O sistema não solicitará as os dados de entrega")]
        public void EntaoOSistemaNaoSolicitaraAsOsDadosDeEntrega()
        {
            Assert.IsFalse(ExisteElemento(By.ClassName("checkout_info_container")),"Formulário de Dados de Entrega foi exibido");

        }

    }
}
