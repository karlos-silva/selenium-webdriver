using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumCore.Utils
{
    public class CommonInterfaceMethods
    {
        WebDriverWait wait;

        public CommonInterfaceMethods(ScenarioContext scenarioContext)
        {
            wait = scenarioContext["DRIVER_WAIT"] as WebDriverWait;
        }

        public Boolean ExisteElemento(By Locator, IWebDriver _driver)
        {
            bool isDisplayed = false;

            try
            {
                isDisplayed = wait.Until(ExpectedConditions.ElementIsVisible(Locator)).Displayed;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine($"Elemeto com locator {Locator} não foi localizado na tela causado por {e.Message}");
            }

            return isDisplayed;
        }

    }
}
