using AppiumSpecFlow.ScreenObjects;
using AppiumSpecFlow.Utility;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AppiumSpecFlow.SpecFlow
{
    [Binding]
    public class EriBankAppFeatureSteps
    {
        EriBankLoginScreen _EriBankLoginScreen = new EriBankLoginScreen(AndriodDriverFactory.GetAndroidDriver());
        EriBankBalanceScreen _EriBankBalanceScreen = new EriBankBalanceScreen(AndriodDriverFactory.GetAndroidDriver());
        EriBankMakePaymentScreen _EriBankMakePaymentScreen = new EriBankMakePaymentScreen(AndriodDriverFactory.GetAndroidDriver());
        EriBankLogOutScreen _EriBankLogOutScreen = new EriBankLogOutScreen(AndriodDriverFactory.GetAndroidDriver());

        ExtentReporting _extentReport = new ExtentReporting();
        CommonFunctions _CommonFunctions = new CommonFunctions();
        ExtentTest test;

        [Given(@"I have launched the Eribank mobile app")]
        public void GivenIHaveLaunchedTheEribankMobileApp()
        {
            _extentReport.setupExtentReport("EriBankApp Test", "EriBankApp Test");
            test = _extentReport.createTest("EriBankApp Test");

            if (_CommonFunctions.IsAndroidElementVisible(AndriodDriverFactory.GetAndroidDriver(), By.XPath("//android.widget.EditText[@text='Username4']")))
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
        
        [When(@"I logged into the EriBank mobile app with valid username and password")]
        public void WhenILoggedIntoTheEriBankMobileAppWithValidUsernameAndPassword()
        {           
            _EriBankLoginScreen.EnterUserName();
            _EriBankLoginScreen.EnterPassword();
            _EriBankLoginScreen.ClickLoginButton();           
        }

        [Then(@"I view the balance")]
        public void ThenIViewTheBalance()
        {
            /*Log the current balance to the report*/
            if (_CommonFunctions.IsAndroidElementVisible(AndriodDriverFactory.GetAndroidDriver(), By.XPath("//android.widget.Button[@text='Make Payment']")))
            {
                _extentReport.testStatusWithMsg("Pass", "Logged into the EriBank app successfully. The current balance is " + _EriBankBalanceScreen.BalanceAmount());
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

        [When(@"I click on the Make Payment button for payment")]
        public void WhenIClickOnTheMakePaymentButtonForPayment()
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

            _EriBankBalanceScreen.ClickOnMakePaymentButton();
        }

        [Then(@"I am navigated to the Make Payment screen")]
        public void ThenIAmNavigatedToTheMakePaymentScreen()
        {
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
        }

        [When(@"I enter all the details for payment and click on Send Payment button")]
        public void WhenIEnterAllTheDetailsForPaymentAndClickOnSendPaymentButton()
        {
            _EriBankMakePaymentScreen.MakePayment();
        }

        [Then(@"I am navigated to the balance screen")]
        public void ThenIAmNavigatedToTheBalanceScreen()
        {
            if (_CommonFunctions.IsAndroidElementVisible(AndriodDriverFactory.GetAndroidDriver(), By.XPath("//android.widget.Button[@text='Logout']")))
            {
                _extentReport.testStatusWithMsg("Pass", "Payment made successfully. The current balance is " + _EriBankBalanceScreen.BalanceAmount());
                _extentReport.flushReport();
            }

            else
            {
                _extentReport.testStatusWithMsg("Fail", "EriBank app test failed");
                _extentReport.flushReport();
                _extentReport.getScreenShotMobile(AndriodDriverFactory.GetAndroidDriver(), test);

                Assert.AreEqual("//android.widget.Button[@text='Logout']", "//android.widget.Button[@text='Logout']2");
            }
        }

        [When(@"I click on the Logout button on app")]
        public void WhenIClickOnTheLogoutButtonOnApp()
        {
            _EriBankLogOutScreen.LogOutFromEriBankApp();
        }
                
        [Then(@"I am navigated back to the login screen")]
        public void ThenIAmNavigatedBackToTheLoginScreen()
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
