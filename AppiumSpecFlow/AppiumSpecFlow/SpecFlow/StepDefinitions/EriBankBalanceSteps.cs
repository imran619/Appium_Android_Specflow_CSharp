using AppiumSpecFlow.ScreenObjects;
using AppiumSpecFlow.Utility;
using System;
using TechTalk.SpecFlow;

namespace AppiumSpecFlow.SpecFlow.StepDefinitions
{
    [Binding]
    public class EriBankBalanceSteps
    {
        EriBankBalanceScreen _EriBankBalanceScreen = new EriBankBalanceScreen(AndriodDriverFactory.GetAndroidDriver());

        [Given(@"I have logged into the EriBank app")]
        public void GivenIHaveLoggedIntoTheEriBankApp()
        {
            Console.WriteLine("Balancescreen.................");
        }
        
        [When(@"I am in the balance screen")]
        public void WhenIAmInTheBalanceScreen()
        {
            Console.WriteLine("Balancescreen.................");
        }
        
        [Then(@"I check the balance")]
        public void ThenICheckTheBalance()
        {
            Console.WriteLine("Balancescreen.................");
        }
    }
}
