using DemoAppAutomation.Pages;
using DemoAppAutomation.Utills;
using DemoAppAutomation.Validations;

namespace DemoAppAutomation.Tests
{
    internal class LoginTests : BaseTest
    {
        [Test, TestCaseSource("GetCsvTestCasesBaseLoginCredentials")]
        public void LoginWithBadCredentialsFail(string user, string pass)
        {
            using var driver = InitDriver(true);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.PerformLogin(user, pass);

            string message = loginPage.GetMessage();
            LoginValidations.ValidateLoginError(user, pass, message);
        }

        [Test]
        public void LoginWithValidCredentialsPass()
        {
            using var driver = InitDriver(true);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.PerformLogin(Consts.UserName, Consts.Password);
            new UserPage(driver);
        }
    }
}
