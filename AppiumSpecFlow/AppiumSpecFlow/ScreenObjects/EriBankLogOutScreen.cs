using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumSpecFlow.ScreenObjects
{
    class EriBankLogOutScreen
    {
        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@text='Logout']")]
        [CacheLookup]
        public IWebElement logOut { get; set; }
        public EriBankLogOutScreen(AndroidDriver<AndroidElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public void LogOutFromEriBankApp()
        {
            logOut.Click();
        }
    }
}
