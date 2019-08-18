using System.Collections.Generic;
using AppiumSpecFlow.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumSpecFlow.ScreenObjects
{
    class EriBankLoginScreen
    {
        CommonFunctions _commonFunctions = new CommonFunctions();
        public static List<List<string>> androidDataSetList;        

        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@text='Username']")]
        [CacheLookup]
        public IWebElement userName { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@text='Password']")]
        [CacheLookup]
        public IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@text='Login']")]
        [CacheLookup]
        public IWebElement loginButton { get; set; }
        public EriBankLoginScreen(AndroidDriver<AndroidElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public List<List<string>> Datalist()
        {
            androidDataSetList = _commonFunctions.ReadAndroidDataList();
            return androidDataSetList;
        }
        public void EnterUserName()
        {
            userName.SendKeys(Datalist()[1][7]);
        }
        public void EnterPassword()
        {
            password.SendKeys(Datalist()[1][8]);
        }
        public void ClickLoginButton()
        {
            loginButton.Click();
        }
    }
}
