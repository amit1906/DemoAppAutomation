using OpenQA.Selenium.Appium;

namespace DemoAppAutomation.Pages
{
    internal class BasePage
    {
        protected readonly AppiumDriver<AppiumWebElement> driver;

        public BasePage(AppiumDriver<AppiumWebElement> driver)
        {
            this.driver = driver;
        }
    }
}