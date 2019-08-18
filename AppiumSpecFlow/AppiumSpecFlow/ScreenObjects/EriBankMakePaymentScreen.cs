using System;
using System.Collections.Generic;
using AppiumSpecFlow.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumSpecFlow.ScreenObjects
{
    class EriBankMakePaymentScreen
    {
        CommonFunctions _commonFunctions = new CommonFunctions();
        public static List<List<string>> androidDataSetList;
        TouchAction _act = new TouchAction(AndriodDriverFactory.GetAndroidDriver());

        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@text = 'Phone']")]
        [CacheLookup]
        public IWebElement phone { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@text = 'Name']")]
        [CacheLookup]
        public IWebElement name { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.SeekBar[@index = '1']")]
        [CacheLookup]
        public IWebElement amountSeekBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@text='Select']")]
        [CacheLookup]
        public IWebElement selectCountryButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text = 'Norway']")]
        [CacheLookup]
        public IWebElement selectedCountry { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@text='Send Payment']")]
        [CacheLookup]
        public IWebElement sendPaymentButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@text='Yes']")]
        [CacheLookup]
        public IWebElement confirmPaymentButton { get; set; }
        public EriBankMakePaymentScreen(AndroidDriver<AndroidElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public void MakePayment()
        {
            androidDataSetList = _commonFunctions.ReadAndroidDataList();

            phone.SendKeys(androidDataSetList[1][9]);
            name.SendKeys(androidDataSetList[1][10]);

            //Get start point of seekbar.
            double startX = amountSeekBar.Location.X;
            Console.WriteLine(startX);

            //Get end point of seekbar.
            double endX = amountSeekBar.Size.Width;
            Console.WriteLine(endX);

            //Get vertical location of seekbar.
            double yAxis = amountSeekBar.Location.Y;

            //Set sllebar move to position. 
            //endX * 0.1 means at 10% of seek bar width.
            double moveToXDirectionAt = endX * 0.61;

            //TouchAction act = new TouchAction(AndroidTestInitialiser.driver);
            _act.Press(startX, yAxis).MoveTo(moveToXDirectionAt, yAxis).Release().Perform();

            selectCountryButton.Click();
            selectedCountry.Click();
            sendPaymentButton.Click();
            confirmPaymentButton.Click();
        }
    }
}
