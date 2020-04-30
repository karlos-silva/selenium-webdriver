using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using SeleniumCore.Utils;

namespace SeleniumCore.Hooks
{

    public class WebDriver
    {
        IWebDriver _driver;
        CommonSystemMethods utils => new CommonSystemMethods();

        public IWebDriver DriverSelector(string driver)
        {
            var outPutDirectory =
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


            switch (driver)
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
    }
}
