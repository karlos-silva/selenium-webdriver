using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using SeleniumCore.Utils;
using OpenQA.Selenium.Remote;
using Gherkin.Ast;
using System.Security.Policy;
using TechTalk.SpecFlow;


namespace SeleniumCore.Hooks
{

    public class WebDriverFactory
    {
        IWebDriver _driver;
        private ScenarioContext scenarioContext;
        CommonSystemMethods utils => new CommonSystemMethods();
        string browser, driverType, deviceName;

        public WebDriverFactory(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        public WebDriverFactory()
        {

        }


        public IWebDriver DriverSelector(string type, string browser)
        {

            if (type == "local")
            {
                switch (browser)
                {
                    case "chrome":
                        _driver = new ChromeDriver(utils.GetProjectPath());
                        break;
                    case "firefox":
                        _driver = new FirefoxDriver(utils.GetProjectPath());
                        break;
                }
                return _driver;
            }
            else if (type == "remote")
            {

                BuildRemoteDriver(browser);

            }
            return _driver;


        }

        private IWebDriver BuildRemoteDriver(string browser)
        {

            var hubUri = new Uri("http://192.168.99.100:4444/wd/hub");

            switch (browser)
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("disable-gpu");
                    //chromeOptions.PlatformName = "WINDOWS";
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.EnableMobileEmulation("BlackBerry Z30");


                    _driver = new RemoteWebDriver(hubUri, chromeOptions);
                    break;
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("headless");
                    firefoxOptions.AddArgument("disable-gpu");
                    //firefoxOptions.PlatformName = "WINDOWS";
                    firefoxOptions.AddArgument("--start-maximized");

                    _driver = new RemoteWebDriver(hubUri, firefoxOptions);
                    break;
            }

            return _driver;
        }

    }
}
