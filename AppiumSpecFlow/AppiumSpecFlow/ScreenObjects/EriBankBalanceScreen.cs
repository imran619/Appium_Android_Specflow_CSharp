using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumSpecFlow.ScreenObjects
{
    class EriBankBalanceScreen
    {
        [FindsBy(How = How.XPath, Using = "//android.view.View[@index = '0']")]
        [CacheLookup]
        public IWebElement balanceField { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@text='Make Payment']")]
        [CacheLookup]
        public IWebElement makePaymentButton { get; set; }
        public EriBankBalanceScreen(AndroidDriver<AndroidElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public void ClickOnMakePaymentButton()
        {
            makePaymentButton.Click();
        }
        public string BalanceAmount()
        {
            string startingBalanceAmount = balanceField.Text.Substring(16).ToString();
            return startingBalanceAmount;
        }
    }
}
