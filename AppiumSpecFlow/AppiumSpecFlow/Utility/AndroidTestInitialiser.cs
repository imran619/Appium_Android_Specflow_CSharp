using System.Diagnostics;
using System.Threading;

namespace AppiumSpecFlow.Utility
{
    class AndroidTestInitialiser
    {        
        public static void StartAppiumServer()
        {
            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + "appium -a 127.0.0.1");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;

            Process = Process.Start(ProcessInfo);
            
            ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + "adb devices");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;

            Process = Process.Start(ProcessInfo);

            Thread.Sleep(5000);
        }
        
    }
}
