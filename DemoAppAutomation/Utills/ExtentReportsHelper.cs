using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace DemoAppAutomation.Utills
{
    internal class ExtentReportsHelper
    {
        public ExtentReports Extent { get; set; }
        public ExtentV3HtmlReporter Reporter { get; set; }
        public static ExtentTest Test { get; set; }

        public ExtentReportsHelper()
        {
            Extent = new ExtentReports();
            var path = Path.Combine(Environment.CurrentDirectory, "../../../Reports/");
            Reporter = new ExtentV3HtmlReporter(path + $"report_{DateTime.Now:dd_mm_yy_hh_mm}.html");
            Reporter.Config.DocumentTitle = "Automation Testing Report";
            Reporter.Config.ReportName = "Regression Testing";
            Reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            Extent.AttachReporter(Reporter);
            Extent.AddSystemInfo("Team", "Platform");
            Extent.AddSystemInfo("Application", "app1");
            Extent.AddSystemInfo("Environment", "QA");
            Extent.AddSystemInfo("Machine", Environment.MachineName);
            Extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
        }
        public void CreateTest(string testName)
        {
            Test = Extent.CreateTest(testName);
        }

        public void SetStepStatusPass(string stepDescription)
        {
            Console.WriteLine(stepDescription);
            Test.Log(Status.Pass, stepDescription);
        }

        public void SetStepStatusWarning(string stepDescription)
        {
            Test.Log(Status.Warning, stepDescription);
        }

        public void SetTestStatusPass(string value)
        {
            Test.Pass(value);
        }

        public void SetTestStatusFail(string message = null)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            Test.Fail(printMessage);
        }

        public void AddTestFailureScreenshot(string base64ScreenCapture)
        {
            Test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot on Error:");
        }

        public void SetTestStatusSkipped()
        {
            Test.Skip("Test skipped!");
        }

        public void Close()
        {
            Extent.Flush();
        }

    }
}

