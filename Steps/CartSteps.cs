using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumCore.Controllers;
using SeleniumCore.Hooks;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SeleniumCore.Steps
{
    [Binding]
    public class CartSteps
    {
        IWebDriver _driver;
        productsController products;
        CartController cart;
        CheckoutController checkout;
        public CartSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            products = new productsController(scenarioContext);
            cart = new CartController(scenarioContext);
            checkout = new CheckoutController(scenarioContext);
        }

        [Given(@"que o usuário está na tela de produtos")]
        public void DadoQueOUsuarioEstaNoCarrinhoDeCompras()
        {
            _driver.Url.Contains("inventory.html");
        }

        [When(@"usuário não adicionar itens no carrinho")]
        public void DadoQueOUsuarioNaoAdicionouItensNoCarrinho()
        {
            cart.CartContainItems();
        }

        [When(@"que o usuário adicionou no carrinho uma ""(.*)"":")]
        public void DadoQueOUsuarioAdicionouNoCarrinhoUma(int quantidade)
        {

            products.AddItemToCart(quantidade);

            cart.GetValueCart(quantidade.ToString());

        }

        [When(@"Clicar no botão checkout")]
        public void QuandoClicarNoBotaoCheckout()
        {
            products.GoToCart();
            cart.GoToCheckout();
        }

        [Then(@"O sistema solicitará as os dados de entrega")]
        public void EntaoOSistemaSolicitaraAsOsDadosDeEntrega()
        {
            cart.TakeScreenShoot();
            Assert.IsTrue(_driver.Url.Contains("checkout-step-one.html"));

        }

        [Then(@"O sistema não solicitará as os dados de entrega")]
        public void EntaoOSistemaNaoSolicitaraAsOsDadosDeEntrega()
        {
            cart.TakeScreenShoot();
            Assert.IsFalse(checkout.ExisteCheckoutContainer(),"Formulário de Dados de Entrega foi exibido");
        }

    }
}
