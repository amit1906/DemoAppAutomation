using DemoAppAutomation.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace DemoAppAutomation.Pages
{
    internal class LoginPage : BasePage
    {
        public LoginPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }

        public bool IsCurrentPage() => driver.CountElements(By.XPath("//android.widget.TextView[@text=\"כניסה\"]")) > 0;
        public void UserField(string value) => driver.FindElement(By.Id("com.example.demoapp:id/email")).SendKeysInfo(value);
        public void PassField(string value) => driver.FindElement(By.Id("com.example.demoapp:id/password")).SendKeysInfo(value);
        public void Connect() => driver.FindElement(By.Id("com.example.demoapp:id/btnLogIn")).ClickInfo();
        public string GetMessage() => driver.FindElement(By.Id("com.example.demoapp:id/txtMessage")).GetText();


        public void PerformLogin(string user, string pass)
        {
            UserField(user);
            PassField(pass);
            Connect();
        }

    }
}
