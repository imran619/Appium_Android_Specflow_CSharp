using AppiumSpecFlow.Utility;
using TechTalk.SpecFlow;

namespace AppiumSpecFlow
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeTestRun]
        public static void BeforeScenario()
        {
            //AndroidTestInitialiser.StartAppiumServer();
        }

        [AfterTestRun]
        public static void AfterScenario()
        {
            AndriodDriverFactory.GetAndroidDriver().Quit();
        }
    }
}
