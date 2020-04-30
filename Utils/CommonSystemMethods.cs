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

    }
}
