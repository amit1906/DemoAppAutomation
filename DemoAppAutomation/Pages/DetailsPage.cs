using DemoAppAutomation.Extensions;
using DemoAppAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace DemoAppAutomation.Pages
{
    internal class DetailsPage : BasePage
    {
        public DetailsPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }

        public void Wait() => driver.FindElement(By.XPath("//android.widget.TextView[contains(@text,'פרטים')]"));
        public bool IsCurrentPage() => driver.CountElements(By.XPath("//android.widget.TextView[contains(@text,'פרטים')]")) > 0;
        public string FirstName() => driver.FindElement(By.Id("com.example.demoapp:id/fname")).GetText();
        public string LastName() => driver.FindElement(By.Id("com.example.demoapp:id/lname")).GetText();
        public string BirthDate() => driver.FindElement(By.Id("com.example.demoapp:id/birth")).GetText();
        public string Gender() => driver.FindElement(By.Id("com.example.demoapp:id/gender")).GetText();
        public string City() => driver.FindElement(By.Id("com.example.demoapp:id/city")).GetText();
        public void Back() => driver.FindElement(By.Id("com.example.demoapp:id/backBtn")).ClickInfo();
        public void Exit() => driver.FindElement(By.Id("com.example.demoapp:id/btnLogOut")).ClickInfo();

        public UserData GetUserData()
        {
            return new UserData()
            {
                FirstName = FirstName(),
                LastName = LastName(),
                BirthDate = BirthDate(),
                Gender = Gender(),
                City = City()
            };
        }

    }
}
