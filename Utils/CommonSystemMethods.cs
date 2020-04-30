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

        public void KillProccess(string processName)
        {
            Process[] DriverProcesses = Process.GetProcessesByName(processName);
            foreach (var Process in DriverProcesses)
            {
                Process.Kill();
            }
        }
    }
}
