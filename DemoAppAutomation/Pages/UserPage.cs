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
        public AppiumWebElement FirstName() => driver.FindElement(By.Id("com.example.demoapp:id/firstName"));
        public AppiumWebElement LastName() => driver.FindElement(By.Id("com.example.demoapp:id/lastName"));
        public AppiumWebElement BirthDate() => driver.FindElement(By.Id("com.example.demoapp:id/birthDate"));
        public AppiumWebElement Male() => driver.FindElement(By.Id("com.example.demoapp:id/male"));
        public AppiumWebElement Female() => driver.FindElement(By.Id("com.example.demoapp:id/female"));
        public AppiumWebElement City() => driver.FindElement(By.Id("com.example.demoapp:id/city"));
        public void Save() => driver.FindElement(By.Id("com.example.demoapp:id/saveBtn")).ClickInfo();
        public void Details() => driver.FindElement(By.Id("com.example.demoapp:id/detailsBtn")).ClickInfo();
        public void Exit() => driver.FindElement(By.Id("com.example.demoapp:id/btnLogOut")).ClickInfo();
        public AppiumWebElement SavedLbl() => driver.FindElement(By.Id("com.example.demoapp:id/savedLbl"));


        public void FillUserDate(UserData data)
        {
            if (FirstName().GetText() != data.FirstName) FirstName().SendKeysInfo(data.FirstName);
            if (LastName().GetText() != data.LastName) LastName().SendKeysInfo(data.LastName);
            if (BirthDate().GetText() != data.BirthDate) BirthDate().SendKeysInfo(data.BirthDate);
            if (data.Gender == "זכר" && Male().GetAttribute("checked") != "true")
            {
                Male().ClickInfo();
            }
            else if (data.Gender == "נקבה" && Female().GetAttribute("checked") != "true")
            {
                Female().ClickInfo();
            }
            if (City().GetText() != data.City) City().SendKeysInfo(data.City);
            Save();
        }

    }
}
