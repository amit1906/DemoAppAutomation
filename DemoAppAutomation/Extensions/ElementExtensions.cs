using DemoAppAutomation.Utills;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Diagnostics;

namespace DemoAppAutomation.Extensions
{
    internal static class ElementExtensions
    {
        public static void SendKeysInfo(this AppiumWebElement elm, string value)
        {
            var name = new StackTrace().GetFrame(1)?.GetMethod()?.Name;
            Console.WriteLine($"{name} SendKeys: {value}");
            ExtentReportsHelper.Test.Pass($"{name} SendKeys: {value}");
            try
            {
                elm.SendKeys(value);
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to SendKeys: {value}, to {name}.\n{e.Message}");
            }
        }

        public static string GetText(this AppiumWebElement elm)
        {
            var name = new StackTrace().GetFrame(1)?.GetMethod()?.Name;
            Console.WriteLine($"{name} GetText: {elm.Text}");
            ExtentReportsHelper.Test.Pass($"{name} GetText: {elm.Text}");
            try
            {
                return elm.Text;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to GetText from: {name}.\n{e.Message}");
            }
        }

        public static void ClickInfo(this AppiumWebElement elm)
        {
            var name = new StackTrace().GetFrame(1)?.GetMethod()?.Name;
            Console.WriteLine($"{name} Click.");
            ExtentReportsHelper.Test.Pass($"{name} Click.");
            try
            {
                elm.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to Click on: {name}.\n{e.Message}");
            }
        }

        public static int CountElements(this AppiumDriver<AppiumWebElement> driver, By by)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            int count = driver.FindElements(by).Count();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Consts.TimeOutInSeconds);
            return count;
        }

    }
}
