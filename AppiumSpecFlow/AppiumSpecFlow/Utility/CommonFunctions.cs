using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace AppiumSpecFlow.Utility
{
    class CommonFunctions :WebDriverConfig
    {

        Excel _excelReader = new Excel();
        

        public void acceptAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void dismissAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Dismiss();
        }

        public string getTextAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            return alert.Text;
        }

        public void sendTextAlert(string textToType)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys(textToType);
        }

        public void waitforElement (IWebElement element)
        {

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(3));
        
        }

        public void takeScreenshot(IWebDriver driver)
        {
            string currentTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            //Save the screenshot
            image.SaveAsFile(getSolutionPath() + "Screenshots" + "\\"+ currentTime + ".png", ImageFormat.Png);
        }

        public void WaitForJQueryToExecute(int timout = 100)
        {
            Thread.Sleep(timout * 1000);
        }

        public string getSolutionPath()
        {
            DirectoryInfo assemblyPath = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            DirectoryInfo binPath = Directory.GetParent(assemblyPath.ToString());
            DirectoryInfo solutionPath = Directory.GetParent(binPath.ToString());

            return solutionPath.ToString();
        }

        public List<List<string>> ReadParaList()
        {
            string filePath = getSolutionPath() + "\\data.xlsx";
            string sheetName = getEnv();
            List<List<string>> paraList = _excelReader.readDataSheet(filePath, sheetName);
            return paraList;
        }

        public List<List<string>> ReadURLList()
        {
            string filePath = getSolutionPath() + "\\data.xlsx";
            string sheetName = getSheetNameforURL();
            List<List<string>> urlList = _excelReader.readDataSheet(filePath, sheetName);
            return urlList;
        }

        public List<List<string>> ReadInvitationCodesList()
        {
            string filePath = getSolutionPath() + "\\data.xlsx";
            string sheetName = getSheetNameforInvitationCodes();
            List<List<string>> invitationCodesList = _excelReader.readDataSheet(filePath, sheetName);
            return invitationCodesList;
        }

        /*Android App*/
        public List<List<string>> ReadAndroidDataList()
        {
            string filePath = getSolutionPath() + "\\data.xlsx";
            string sheetName = getSheetNameforApp();
            List<List<string>> androidDataList = _excelReader.readDataSheet(filePath, sheetName);
            return androidDataList;
        }

        public string getSheetNameforURL()
        {
            
            Excel excel = new Excel();

            string envName = excel.readExcel(_commonFunctions.getSolutionPath() + "\\data.xlsx", "Init", 7, 2);


            if (envName == "daily2")
            {
                return excel.readExcel(_commonFunctions.getSolutionPath() + "\\data.xlsx", "Init", 8, 2);
            }
            else
            {
                return excel.readExcel(_commonFunctions.getSolutionPath() + "\\data.xlsx", "Init", 8, 3);
            }

        }

        public string getSheetNameforInvitationCodes()
        {
            Excel excel = new Excel();
            return excel.readExcel(_commonFunctions.getSolutionPath() + "\\data.xlsx", "Init", 9, 2);
        }

        public string getSheetNameforApp()
        {

            Excel excel = new Excel();

            string envName = excel.readExcel(_commonFunctions.getSolutionPath() + "\\data.xlsx", "Init", 7, 2);


            if (envName == "ANDROID")
            {
                return excel.readExcel(_commonFunctions.getSolutionPath() + "\\data.xlsx", "Init", 8, 2);
            }
            else
            {
                return excel.readExcel(_commonFunctions.getSolutionPath() + "\\data.xlsx", "Init", 8, 3);
            }

        }


        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public string UserName()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(100000, 999999));
            return builder.ToString();
        }


        public string Email()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(UserName() + "@gmail.com");
            return builder.ToString();
        }

        public bool IsAndroidElementVisible(AppiumDriver<AndroidElement> andriodDriver, By by)
        {
            bool isElement = false;
            try
            {
                if (andriodDriver.FindElement(by) != null)
                {
                    isElement = true;
                    return isElement;
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
                isElement = false;
                return isElement;
            }

            return isElement;
        }

    }
}
