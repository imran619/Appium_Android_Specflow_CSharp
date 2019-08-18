using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System.IO;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumSpecFlow.Utility
{

    class ExtentReporting : CommonFunctions
    {
      

        public static ExtentReports extRptDrv;
        private ExtentReports extent;
        ExtentReports report;
        ExtentHtmlReporter htmlReporter;

       // ExtentTest test;
        public static ExtentTest testCase;

        WebDriverConfig configurator = new WebDriverConfig();

        public object LogStatus { get; private set; }

        public void setupExtentReport(string reportName, string documentTitle )
        {
            
            string currentTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
            string solPath = _commonFunctions.getSolutionPath();


            htmlReporter = new ExtentHtmlReporter(_commonFunctions.getSolutionPath() + "\\Reports" + "\\" + reportName + "_" + currentTime + "-" + ".html");
            htmlReporter.Configuration().Theme = Theme.Dark;
            htmlReporter.Configuration().DocumentTitle = documentTitle;
            htmlReporter.Configuration().ReportName = reportName + " Execution App: Android App ";// + configurator.getBrowser();
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extRptDrv = extent;

        }

       public ExtentTest createTest (string testName)
       {
            //ExtentTest test;
            testCase = extent.CreateTest(testName);
            return testCase;
           
       }
       
        public void logReportStatement (Status status, string message)
        {
            testCase.Log(status, message);
        }

    

        public void flushReport ()
        {
            extent.Flush();
        }

        public void attachScreenShot(ExtentTest test)
        {
            string currentTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");

            Screenshot ss = ((ITakesScreenshot)WebDriverConfig._Driver).GetScreenshot();
            string fileName = currentTime + ".png";
            ss.SaveAsFile(_commonFunctions.getSolutionPath() + "\\Reports" + "\\" + fileName , ImageFormat.Png);



            //ElementNotVisibleException e = null;

            test.Log(AventStack.ExtentReports.Status.Error, "Screenshot: " + testCase.AddScreenCaptureFromPath(_commonFunctions.getSolutionPath() + "\\Reports\\" + currentTime + ".png"));

            test.Log(AventStack.ExtentReports.Status.Error, Environment.StackTrace);


            extRptDrv.Flush();

          
        }

        public void getScreenShotMobile(AppiumDriver<AndroidElement> appdriver, ExtentTest test)
        {
            string currentTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");

            Screenshot image = ((ITakesScreenshot)appdriver).GetScreenshot();
            //image.SaveAsFile(string.Format("C:\\<SystemPath>\\{0}.Png", getcurrentTime() + "_" + testCaseId), ScreenshotImageFormat.Png);
            string fileName = currentTime + ".png";
            image.SaveAsFile(_commonFunctions.getSolutionPath() + "\\Reports" + "\\" + fileName, ImageFormat.Png);

            test.Log(AventStack.ExtentReports.Status.Error, "Screenshot: " + testCase.AddScreenCaptureFromPath(_commonFunctions.getSolutionPath() + "\\Reports\\" + currentTime + ".png"));

            test.Log(AventStack.ExtentReports.Status.Error, Environment.StackTrace);
            
            extRptDrv.Flush();
        }

        public void testStatusWithMsg (string status, string message)
        {
            if (status.Equals("Pass"))
           {
                testCase.Pass(message);
            }
           else
            {
                testCase.Fail(message);
            }
        }
    }
}
