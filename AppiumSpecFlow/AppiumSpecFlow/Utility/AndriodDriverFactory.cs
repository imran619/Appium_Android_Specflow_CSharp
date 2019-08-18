using System;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace AppiumSpecFlow.Utility
{
    public class AndriodDriverFactory
    {
        private static AndroidDriver<AndroidElement> _andriodDriver;
        public static AndroidDriver<AndroidElement> GetAndroidDriver()
        {
            if (_andriodDriver == null)
            {
                var commonFunctions = new CommonFunctions();
                var androidDataSetList = commonFunctions.ReadAndroidDataList();
                var capabilities = new DesiredCapabilities();
                capabilities.SetCapability("BROWSER_NAME", androidDataSetList[1][1]);
                capabilities.SetCapability("VERSION", androidDataSetList[1][2]);
                capabilities.SetCapability("deviceName", androidDataSetList[1][3]);
                capabilities.SetCapability("platformName", androidDataSetList[1][4]);
                capabilities.SetCapability("appPackage", androidDataSetList[1][5]);
                capabilities.SetCapability("appActivity", androidDataSetList[1][6]);

                _andriodDriver = new AndroidDriver<AndroidElement>(new Uri(androidDataSetList[1][0]), capabilities);
            }

            return _andriodDriver;
        }
    }
}
