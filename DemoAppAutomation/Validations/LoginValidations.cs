namespace DemoAppAutomation.Validations
{
    internal class LoginValidations
    {
        public static void ValidateLoginError(string user, string pass, string message)
        {
            string errorMessage = "connecting message is incorrect.";
            if (user == "" && pass == "")
            {
                Assert.That(message, Is.EqualTo("Provide user and password!"), errorMessage);
            }
            else if (user == "")
            {
                Assert.That(message, Is.EqualTo("Provide user!"), errorMessage);
            }
            else if (pass == "")
            {
                Assert.That(message, Is.EqualTo("Provide password!"), errorMessage);
            }
            else
            {
                Assert.That(message, Is.EqualTo("Invalid credentials, try again."), errorMessage);
            }
        }

    }
}
