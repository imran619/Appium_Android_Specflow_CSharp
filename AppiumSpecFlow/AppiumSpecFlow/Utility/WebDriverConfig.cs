using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
//using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;
using ExcelSheet = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Appium.Android;

namespace AppiumSpecFlow.Utility
{
    class WebDriverConfig
    {
        private static WebDriverConfig _instance;
        public static IWebDriver Driver { get; set; }
        public static AndroidDriver<AndroidElement> _Driver { get; set;}
        private static readonly object Lock = new object();
        private static string BrowserValue;
        public static CommonFunctions _commonFunctions = new CommonFunctions();
        public static List<List<string>> urlList;
        public static WebDriverConfig Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new WebDriverConfig();
                    }
                }

                return _instance;
            }
        }

        public string getBrowser()
        {
            return BrowserValue;

        }

        public string getEnv()
        {
            Excel excel = new Excel();
            return excel.readExcel(_commonFunctions.getSolutionPath() + "\\data.xlsx", "Init", 7, 2);

        }

        public IWebDriver InitiliaseDriver()
        {

            Excel excel = new Excel();
            var configData = new List<string>();
            configData = excel.readBrowserData(_commonFunctions.getSolutionPath() + "\\data.xlsx");
            string hubURL = configData[4];
            string Browser = configData[0];
            string HeadlesMode = configData[3];
            BrowserValue = Browser;
            string URL = excel.readExcel(_commonFunctions.getSolutionPath() + "\\data.xlsx", getEnv(), 1, 2);

            string grid_status = configData[2];
            if (grid_status.Equals("No"))
            {
                switch (Browser)
                {
                    case "Chrome":
                        if (HeadlesMode.Equals("Yes"))
                        {
                            var chromeOptions = new ChromeOptions();
                            chromeOptions.AddArguments("headless");

                            Driver = new ChromeDriver(chromeOptions);
                            // Starting chrome headless 
                        }
                        else
                        {
                            var chromeOptions = new ChromeOptions();
          
                            Driver = new ChromeDriver();
                        }
                        break;
                    case "IE":
                        Driver = new InternetExplorerDriver();
                        break;
                    case "Firefox":
                        if (HeadlesMode.Equals("Yes"))
                        {
                            FirefoxOptions options = new FirefoxOptions();
                            options.AddArguments("--headless");
                            Driver = new FirefoxDriver(options);
                            // Starting firefox headless
                        }
                        else
                        {
                            Driver = new FirefoxDriver();
                        }
                        break;
                }

                Driver.Manage().Window.Maximize();
                Driver.Navigate().GoToUrl(URL);

                return Driver;
            }
            else
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                switch (Browser)
                {
                    case "Firefox":

                        FirefoxOptions options = new FirefoxOptions();
                        if (HeadlesMode.Equals("Yes"))
                        {
                            options.AddArguments("--headless");
                            Driver = new FirefoxDriver(options);

                            // Starting firefox headless in grid
                        }
                        else
                        {
                            Driver = new FirefoxDriver();
                        }
                        capabilities = options.ToCapabilities() as DesiredCapabilities;

                        capabilities.SetCapability(CapabilityType.BrowserName, "firefox");
                        capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.WinNT));
                        break;
                    case "Chrome":

                        var chromeOptions = new ChromeOptions();
                        if (HeadlesMode.Equals("Yes"))
                        {

                            chromeOptions.AddArgument("--headless");

                        }

                        else
                        {
                            // var chromeOptions = new ChromeOptions();
                            chromeOptions.AddArguments("user-data-dir=C:/Users/isa/AppData/Local/Google/Chrom/User Data/Default");
                            Driver = new ChromeDriver(chromeOptions);
                            // Driver = new ChromeDriver();
                        }

                        capabilities = chromeOptions.ToCapabilities() as DesiredCapabilities;
                        // capabilities.SetCapability(ChromeOptions.Capability, chromeOptions);
                        capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
                        capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.WinNT));

                        break;

                }
                Driver = new RemoteWebDriver(new Uri(hubURL), capabilities);
                Driver.Manage().Window.Maximize();
                Driver.Navigate().GoToUrl(URL);

                return Driver;


            }
        }


        public IWebDriver InitiliaseDriver(string url)
        {

            Excel excel = new Excel();
            var configData = new List<string>();
            configData = excel.readBrowserData(_commonFunctions.getSolutionPath() + "\\data.xlsx");
            string hubURL = configData[4];
            string Browser = configData[0];
            string HeadlesMode = configData[3];
            BrowserValue = Browser;
            string URL = url;

            string grid_status = configData[2];
            if (grid_status.Equals("No"))
            {
                switch (Browser)
                {
                    case "Chrome":
                        if (HeadlesMode.Equals("Yes"))
                        {
                            var chromeOptions = new ChromeOptions();
                            chromeOptions.AddArguments("headless");

                            Driver = new ChromeDriver(chromeOptions);
                            // Starting chrome headless 
                        }
                        else
                        {
                            var chromeOptions = new ChromeOptions();

                            Driver = new ChromeDriver();
                        }
                        break;
                    case "IE":
                        Driver = new InternetExplorerDriver();
                        break;
                    case "Firefox":
                        if (HeadlesMode.Equals("Yes"))
                        {
                            FirefoxOptions options = new FirefoxOptions();
                            options.AddArguments("--headless");
                            Driver = new FirefoxDriver(options);
                            // Starting firefox headless
                        }
                        else
                        {
                            Driver = new FirefoxDriver();
                        }
                        break;
                }

                Driver.Manage().Window.Maximize();
                Driver.Navigate().GoToUrl(URL);

                return Driver;
            }
            else
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                switch (Browser)
                {
                    case "Firefox":

                        FirefoxOptions options = new FirefoxOptions();
                        if (HeadlesMode.Equals("Yes"))
                        {
                            options.AddArguments("--headless");
                            Driver = new FirefoxDriver(options);

                            // Starting firefox headless in grid
                        }
                        else
                        {
                            Driver = new FirefoxDriver();
                        }
                        capabilities = options.ToCapabilities() as DesiredCapabilities;

                        capabilities.SetCapability(CapabilityType.BrowserName, "firefox");
                        capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.WinNT));
                        break;
                    case "Chrome":

                        var chromeOptions = new ChromeOptions();
                        if (HeadlesMode.Equals("Yes"))
                        {

                            chromeOptions.AddArgument("--headless");

                        }

                        else
                        {
                            // var chromeOptions = new ChromeOptions();
                            chromeOptions.AddArguments("user-data-dir=C:/Users/isa/AppData/Local/Google/Chrom/User Data/Default");
                            Driver = new ChromeDriver(chromeOptions);
                            // Driver = new ChromeDriver();
                        }

                        capabilities = chromeOptions.ToCapabilities() as DesiredCapabilities;
                        // capabilities.SetCapability(ChromeOptions.Capability, chromeOptions);
                        capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
                        capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.WinNT));

                        break;

                }
                Driver = new RemoteWebDriver(new Uri(hubURL), capabilities);
                Driver.Manage().Window.Maximize();
                Driver.Navigate().GoToUrl(URL);

                return Driver;


            }
        }

        //public IWebDriver InitiliaseDriver()
        //{
        //    //var chromeOptions = new ChromeOptions();
        //    //Driver = new ChromeDriver(chromeOptions);
        //    Driver = new ChromeDriver();
        //    Driver.Manage().Window.Maximize();
        //    return Driver;
        // }


        private static void EnsureProcessTermination(string processName)
        {
            try
            {
                var driverProcesses = Process.GetProcessesByName(processName);
                foreach (var driverProcess in driverProcesses)
                {
                    driverProcess.Kill();
                }
            }
            catch
            {
                // ignored
            }
        }

        //Code added by Imran 17/10/2018
        public void WaitForJQueryToExecute(int timout = 100)
        {
            Thread.Sleep(timout * 1000);
        }
        //

        
        public void QuitDriver()
        {
            
            Excel excel = new Excel();
            string Browser = excel.readExcel(_commonFunctions.getSolutionPath() + "\\data.xlsx", getEnv(), 1, 2);
            string URL = excel.readExcel(_commonFunctions.getSolutionPath() + "\\data.xlsx", getEnv(), 2, 2);

            try
            {
                Driver.Quit();
            }
            finally
            {
                if (Browser.Equals("Phantom"))
                {
                    EnsureProcessTermination("phantomjs");
                }
                else if (Browser.Equals("IE"))
                {
                    EnsureProcessTermination("ieexplore");
                }
                else if (Browser.Equals("Firefox"))
                {
                    EnsureProcessTermination("firefox");
                }

                else if (Browser.Equals("Chrome"))
                {
                    EnsureProcessTermination("chrome");
                }
            }

         
        
            



        }
       
    }
    
}
