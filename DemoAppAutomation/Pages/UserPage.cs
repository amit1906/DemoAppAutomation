using DemoAppAutomation.Extensions;
using DemoAppAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace DemoAppAutomation.Pages
{
    internal class UserPage : BasePage
    {
        public UserPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { Wait(); }

        public void Wait() => driver.FindElement(By.Id("com.example.demoapp:id/txtMessage"));
        public void FirstName(string value) => driver.FindElement(By.Id("com.example.demoapp:id/firstName")).SendKeysInfo(value);
        public void LastName(string value) => driver.FindElement(By.Id("com.example.demoapp:id/lastName")).SendKeysInfo(value);
        public void BirthDate(string value) => driver.FindElement(By.Id("com.example.demoapp:id/birthDate")).SendKeysInfo(value);
        public void Male() => driver.FindElement(By.Id("com.example.demoapp:id/male")).ClickInfo();
        public void Female() => driver.FindElement(By.Id("com.example.demoapp:id/female")).ClickInfo();
        public void City(string value) => driver.FindElement(By.Id("com.example.demoapp:id/city")).SendKeysInfo(value);
        public void Save() => driver.FindElement(By.Id("com.example.demoapp:id/saveBtn")).ClickInfo();
        public void Details() => driver.FindElement(By.Id("com.example.demoapp:id/detailsBtn")).ClickInfo();
        public void Exit() => driver.FindElement(By.Id("com.example.demoapp:id/btnLogOut")).ClickInfo();
        public AppiumWebElement SavedLbl() => driver.FindElement(By.Id("com.example.demoapp:id/savedLbl"));


        public void FillUserDate(UserData data)
        {
            FirstName(data.FirstName);
            LastName(data.LastName);
            BirthDate(data.BirthDate);
            if (data.Gender == "זכר")
            {
                Male();
            }
            else if (data.Gender == "נקבה")
            {
                Female();
            }
            City(data.City);
            Save();
        }

    }
}
