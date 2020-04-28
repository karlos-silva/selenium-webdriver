using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCore.Pages
{
    public class ProductsPage
    {
        public By BtnAddToCart => By.XPath("//button[contains(text(), 'ADD TO CART')]");

        public By BtnGoToCart => By.ClassName("shopping_cart_link");



    }
}
