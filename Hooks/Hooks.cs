﻿using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using TechTalk.SpecFlow;
using SeleniumCore.Utils;
using SeleniumCore.Hooks;

namespace SeleniumCore.Hooks
{
    [Binding]
    public class Hooks 
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public static ScenarioContext _scenarioContext { get; set; }
        static FeatureContext _featureContext { get; set; }
        static ScenarioStepContext _stepContext { get; set; }
        public static TestContext msContext { get; set; }
        private CommonSystemMethods utils => new CommonSystemMethods();
        private WebDriverFactory webDriver => new WebDriverFactory();
        string browser, driverType;


        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            msContext = _scenarioContext.ScenarioContainer.Resolve<TestContext>();

            browser = msContext.Properties["browser"].ToString();
            driverType = msContext.Properties["driver"].ToString();

            _driver = webDriver.DriverSelector(driverType, browser);

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            scenarioContext["WEB_DRIVER"] = _driver;
            scenarioContext["DRIVER_WAIT"] = _wait;

            var ambiente = msContext.Properties["ambiente"].ToString();

            var appsettings = new ConfigurationBuilder().AddJsonFile(utils.GetProjectPath()+"\\appsettings." + ambiente + ".json").Build();

            scenarioContext["APP_SETTINGS"] = appsettings;

        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}
