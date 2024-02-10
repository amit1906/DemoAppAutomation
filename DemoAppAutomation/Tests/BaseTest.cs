using DemoAppAutomation.Utills;
using Microsoft.VisualBasic.FileIO;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace DemoAppAutomation.Tests;

internal class BaseTest
{
    protected static IEnumerable<TestCaseData> GetCsvTestCasesBaseLoginCredentials()
    {
        return GetCsvTestCases("BadCredentials");
    }
    protected static IEnumerable<TestCaseData> GetCsvUserDetailsCases()
    {
        return GetCsvTestCases("UserDetails");
    }

    private static IEnumerable<TestCaseData> GetCsvTestCases(string csvName)
    {
        var file = Path.Combine(Environment.CurrentDirectory, $"../../../DataSource/{csvName}.csv");
        using var parser = new TextFieldParser(file);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(";");
        while (!parser.EndOfData)
        {
            yield return new TestCaseData(parser.ReadFields());
        }
    }

    protected static ExtentReportsHelper extent = null;

    [OneTimeSetUp]
    public void SetUpReporter()
    {
        if (extent == null)
        {
            extent = new ExtentReportsHelper();
        }
    }

    [SetUp]
    public void SetUp()
    {
        extent.CreateTest(TestContext.CurrentContext.Test.Name);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
            switch (status)
            {
                case TestStatus.Failed:
                    extent.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                    //extent.AddTestFailureScreenshot(driver.());
                    break;
                case TestStatus.Skipped:
                    extent.SetTestStatusSkipped();
                    break;
                default:
                    extent.SetTestStatusPass("Test Executed Sucessfully!");
                    break;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OneTimeTearDown]
    public void CloseAll()
    {
        try
        {
            extent.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static AppiumOptions GetOptions()
    {
        var options = new AppiumOptions();
        options.AddAdditionalCapability("appium:udid", "emulator-5554");
        options.AddAdditionalCapability("appium:automationName", "UIAutomator2");
        options.AddAdditionalCapability("appium:DeviceName", "Android");
        options.AddAdditionalCapability("platformName", "Android");
        options.AddAdditionalCapability("appium:noReset", false);
        return options;
    }

    public static AppiumDriver<AppiumWebElement> InitDriver(bool backToLogin = false)
    {
        try
        {
            var driver = new AndroidDriver<AppiumWebElement>(Consts.AppUrl, GetOptions());
            driver.ActivateApp("com.example.demoapp");
            if (backToLogin && driver.CurrentActivity != ".MainActivity")
            {
                driver.Navigate().Back();
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Consts.TimeOutInSeconds);
            return driver;
        }
        catch (Exception e)
        {
            throw new Exception($"Init driver failed. {e}\n{e.Message}");
        }
    }



}