using System;
using AppiumSpecFlow.ScreenObjects;
using AppiumSpecFlow.Utility;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AppiumSpecFlow.SpecFlow.StepDefinitions
{
    [Binding]
    public class EriBankLoginSteps
    {
        EriBankLoginScreen _EriBankLoginScreen = new EriBankLoginScreen(AndriodDriverFactory.GetAndroidDriver());
        ExtentReporting _ExtentReport = new ExtentReporting();
        CommonFunctions _CommonFunctions = new CommonFunctions();
        ExtentTest test;

        [Given(@"I launch the EriBank app")]
        public void GivenILaunchTheEriBankApp()
        {
            _ExtentReport.setupExtentReport("EriBankApp Test", "EriBankApp Test");
            test = _ExtentReport.createTest("Test");

            if (_CommonFunctions.IsAndroidElementVisible(AndriodDriverFactory.GetAndroidDriver(), By.Id("com.experitest.ExperiBank:id/usernameTextField")))
            {
                _ExtentReport.testStatusWithMsg("Pass", "EriBank app was launched successfully");
                _ExtentReport.flushReport();
            }
            else
            {
                _ExtentReport.testStatusWithMsg("Fail", "EriBank app test failed");
                _ExtentReport.flushReport();
                _ExtentReport.getScreenShotMobile(AndriodDriverFactory.GetAndroidDriver(), test);

                Assert.AreEqual("//android.widget.EditText[@text='Username']", "//android.widget.EditText[@text='Username']2");
            }


            Console.WriteLine("App launched.................");
        }
        
        [When(@"I enter the username")]
        public void WhenIEnterTheUsername()
        {
            _EriBankLoginScreen.EnterUserName();
        }
        
        [When(@"I enter the password")]
        public void WhenIEnterThePassword()
        {
            _EriBankLoginScreen.EnterPassword();
        }
        
        [When(@"click on login button")]
        public void WhenClickOnLoginButton()
        {
            _EriBankLoginScreen.ClickLoginButton();
        }
        
        [Then(@"I am logged into the EriBank app successfully")]
        public void ThenIAmLoggedIntoTheEriBankAppSuccessfully()
        {
            Console.WriteLine("App logged.................");
        }
    }
}
