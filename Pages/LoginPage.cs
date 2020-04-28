using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCore.Pages
{
    public class LoginPage
    {
        public By InputUsername => By.Id("user-name");
        public By InputPassword => By.Id("password");
        public By BtnLogin => By.ClassName("btn_action");
        public By btnError => By.ClassName("error-button");

    }
}
