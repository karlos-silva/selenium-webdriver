using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCore.Pages
{
    public class CartPage
    {
        public By ItemsCount => By.XPath("//div[@id = 'shopping_cart_container']/a/span");

        public By BtnCheckout => By.ClassName("checkout_button");

    }
}