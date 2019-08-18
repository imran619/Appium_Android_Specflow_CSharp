using AppiumSpecFlow.ScreenObjects;
using AppiumSpecFlow.Utility;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AppiumSpecFlow.SpecFlow.StepDefinitions
{
    [Binding]
    public class EriBankAppFlowSteps
    {
        EriBankLoginScreen _EriBankLoginScreen = new EriBankLoginScreen(AndriodDriverFactory.GetAndroidDriver());
        EriBankBalanceScreen _EriBankBalanceScreen = new EriBankBalanceScreen(AndriodDriverFactory.GetAndroidDriver());
        EriBankMakePaymentScreen _EriBankMakePaymentScreen = new EriBankMakePaymentScreen(AndriodDriverFactory.GetAndroidDriver());
        EriBankLogOutScreen _EriBankLogOutScreen = new EriBankLogOutScreen(AndriodDriverFactory.GetAndroidDriver());

        ExtentReporting _extentReport = new ExtentReporting();
        CommonFunctions _CommonFunctions = new CommonFunctions();
        ExtentTest test;


        [Given(@"I have launched the Eribank app")]
        public void GivenIHaveLaunchedTheEribankApp()
        {
            _extentReport.setupExtentReport("EriBankApp Test", "EriBankApp Test");
            test = _extentReport.createTest("Test");

            if (_CommonFunctions.IsAndroidElementVisible(AndriodDriverFactory.GetAndroidDriver(), By.XPath("//android.widget.EditText[@text='Username']")))
            {

                _extentReport.testStatusWithMsg("Pass", "EriBank app was launched successfully");
                _extentReport.flushReport();
            }

            else
            {
                _extentReport.testStatusWithMsg("Fail", "EriBank app test failed");
                _extentReport.flushReport();
                _extentReport.getScreenShotMobile(AndriodDriverFactory.GetAndroidDriver(), test);

                Assert.AreEqual("//android.widget.EditText[@text='Username']", "//android.widget.EditText[@text='Username']2");
            }

        }
        
        [When(@"I logged into the EriBank app with valid username and password")]
        public void WhenILoggedIntoTheEriBankAppWithValidUsernameAndPassword()
        {
            _EriBankLoginScreen.EnterUserName();
            _EriBankLoginScreen.EnterPassword();
            _EriBankLoginScreen.ClickLoginButton();

            /*Log the current balance to the report*/
            if (_CommonFunctions.IsAndroidElementVisible(AndriodDriverFactory.GetAndroidDriver(), By.XPath("//android.widget.Button[@text='Make Payment']")))
            {

                _extentReport.testStatusWithMsg("Pass", "Logged into the EriBank app successfully. The current balance is " + _EriBankBalanceScreen.balanceAmount());
                _extentReport.flushReport();
            }

            else
            {
                _extentReport.testStatusWithMsg("Fail", "EriBank app test failed");
                _extentReport.flushReport();
                _extentReport.getScreenShotMobile(AndriodDriverFactory.GetAndroidDriver(), test);

                Assert.AreEqual("//android.widget.Button[@text='Make Payment']", "//android.widget.Button[@text='Make Payment']2");
            }
        }
        
        [When(@"I click on the Make Payment button")]
        public void WhenIClickOnTheMakePaymentButton()
        {
            /*Proceed to make pament*/
            if (_CommonFunctions.IsAndroidElementVisible(AndriodDriverFactory.GetAndroidDriver(), By.XPath("//android.widget.Button[@text='Make Payment']")))
            {

                _extentReport.testStatusWithMsg("Pass", "Navigated to the balance screen successfully");
                _extentReport.flushReport();
            }

            else
            {
                _extentReport.testStatusWithMsg("Fail", "EriBank app test failed");
                _extentReport.flushReport();
                _extentReport.getScreenShotMobile(AndriodDriverFactory.GetAndroidDriver(), test);

                Assert.AreEqual("//android.widget.Button[@text='Make Payment']", "//android.widget.Button[@text='Make Payment']2");
            }

            _EriBankBalanceScreen.clickOnMakePaymentButton();
        }
        
        [When(@"I enter all the details and click on Send Payment button")]
        public void WhenIEnterAllTheDetailsAndClickOnSendPaymentButton()
        {
            /*Make payment*/
            if (_CommonFunctions.IsAndroidElementVisible(AndriodDriverFactory.GetAndroidDriver(), By.XPath("//android.widget.EditText[@text = 'Phone']")))
            {

                _extentReport.testStatusWithMsg("Pass", "Navigated to the make payment screen successfully");
                _extentReport.flushReport();
            }

            else
            {
                _extentReport.testStatusWithMsg("Fail", "EriBank app test failed");
                _extentReport.flushReport();
                _extentReport.getScreenShotMobile(AndriodDriverFactory.GetAndroidDriver(), test);

                Assert.AreEqual("//android.widget.EditText[@text = 'Phone']", "//android.widget.EditText[@text = 'Phone']2");
            }

            _EriBankMakePaymentScreen.makePayment();
        }
        
        [When(@"I click on the Logout button")]
        public void WhenIClickOnTheLogoutButton()
        {
            /*Logout from EriBank app*/
            if (_CommonFunctions.IsAndroidElementVisible(AndriodDriverFactory.GetAndroidDriver(), By.XPath("//android.widget.Button[@text='Logout']")))
            {

                _extentReport.testStatusWithMsg("Pass", "Payment made successfully. The current balance is " + _EriBankBalanceScreen.balanceAmount());
                _extentReport.flushReport();
            }

            else
            {
                _extentReport.testStatusWithMsg("Fail", "EriBank app test failed");
                _extentReport.flushReport();
                _extentReport.getScreenShotMobile(AndriodDriverFactory.GetAndroidDriver(), test);

                Assert.AreEqual("//android.widget.Button[@text='Logout']", "//android.widget.Button[@text='Logout']2");
            }

            _EriBankLogOutScreen.logOutFromEriBankApp();
        }
        
        
        [Then(@"I am navigated to the login screen")]
        public void ThenIAmNavigatedToTheLoginScreen()
        {
            /*Successfull logout in report*/
            if (_CommonFunctions.IsAndroidElementVisible(AndriodDriverFactory.GetAndroidDriver(), By.XPath("//android.widget.EditText[@text='Username']")))
            {

                _extentReport.testStatusWithMsg("Pass", "Logged out from the EriBank app successfully");
                _extentReport.flushReport();
            }

            else
            {
                _extentReport.testStatusWithMsg("Fail", "EriBank app test failed");
                _extentReport.flushReport();
                _extentReport.getScreenShotMobile(AndriodDriverFactory.GetAndroidDriver(), test);

                Assert.AreEqual("//android.widget.EditText[@text='Username']", "//android.widget.EditText[@text='Username']2");
            }
        }
    }
}
