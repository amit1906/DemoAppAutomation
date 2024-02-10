using DemoAppAutomation.Models;
using DemoAppAutomation.Pages;
using DemoAppAutomation.Utills;
using DemoAppAutomation.Validations;

namespace DemoAppAutomation.Tests
{
    internal class UpdateDetailsTests : BaseTest
    {
        static UserData data = new UserData();

        [Test, TestCaseSource("GetCsvUserDetailsCases")]
        public void UpdateUserDetails(string firstName, string lastName, string birthDate, string gender, string city)
        {
            data.Update(firstName, lastName, birthDate, gender, city);
            using var driver = InitDriver();
            LoginPage loginPage = new LoginPage(driver);
            if (loginPage.IsCurrentPage())
            {
                loginPage.PerformLogin(Consts.UserName, Consts.Password);
            }
            DetailsPage detailsPage = new DetailsPage(driver);
            if (detailsPage.IsCurrentPage())
            {
                detailsPage.Back();
            }

            UserPage userPage = new UserPage(driver);
            userPage.Wait();
            userPage.FillUserDate(data);
            Assert.That(userPage.SavedLbl().Displayed, Is.True, "Saved label should be displayed");
            extent.SetStepStatusPass("Saved label is displayed.");
            userPage.Details();

            var actualData = detailsPage.GetUserData();
            detailsPage.Back();
            UserDetailsValidations.ValidateUserDetails(data, actualData);
        }

    }
}
