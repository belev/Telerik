namespace Methods
{
    using System;

    public class PersonalInformation
    {
        public PersonalInformation(string dateOfBirthAsString, string city = null, string hobby = null)
        {
            DateTime outParamBirthDate;
            if (!DateTime.TryParse(dateOfBirthAsString, out outParamBirthDate))
            {
                throw new FormatException("Incorrect Date format! Suggest to (15.04.1999)");
            }

            this.DateOfBirth = outParamBirthDate;
            this.City = city;
            this.Hobby = hobby;
        }

        public DateTime DateOfBirth { get; set; }

        public string City { get; set; }

        public string Hobby { get; set; }
    }
}
