namespace DemoAppAutomation.Models
{
    internal class UserData
    {
        public void Update(string firstName, string lastName, string birthDate, string gender, string city)
        {
            if (firstName != "") FirstName = firstName;
            if (lastName != "") LastName = lastName;
            if (birthDate != "") BirthDate = birthDate;
            if (gender != "") Gender = gender;
            if (city != "") City = city;
        }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string BirthDate { get; set; } = "";
        public string Gender { get; set; } = "";
        public string City { get; set; } = "";

    }
}
