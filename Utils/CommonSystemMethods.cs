using Google.Protobuf.WellKnownTypes;
using Microsoft.OData.Edm;
using NPOI.SS.Util;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace SeleniumCore.Utils
{
    public class CommonSystemMethods
    {
        public string GetProjectPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public void TakeScreenShoot(IWebDriver _driver, string NomeDoCenario)
        {
            String timestamp = DateTime.Now.ToString("ddMMyyy_hhmmss");

            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile("C:\\Users\\karlo\\source\\repos\\SeleniumCore\\ScreenShots\\" + NomeDoCenario + timestamp +".png", ScreenshotImageFormat.Png);
        }
    }
}

