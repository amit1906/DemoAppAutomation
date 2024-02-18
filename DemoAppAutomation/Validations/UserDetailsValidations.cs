using DemoAppAutomation.Models;

namespace DemoAppAutomation.Validations
{
    internal class UserDetailsValidations
    {
        public static void ValidateUserDetails(UserData data, UserData actualData)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actualData.FirstName, Is.EqualTo(data.FirstName), "FirstName");
                Assert.That(actualData.LastName, Is.EqualTo(data.LastName), "LastName");
                Assert.That(actualData.BirthDate, Is.EqualTo(data.BirthDate), "BirthDate");
                Assert.That(actualData.Gender, Is.EqualTo(data.Gender), "Gender");
                Assert.That(actualData.City, Is.EqualTo(data.City), "City");
            });
        }
    }
}
