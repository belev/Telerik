namespace Methods
{
    using System;

    public class Student
    {
        public Student(string firstName, string lastName, PersonalInformation personalInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PersonalInfo = personalInfo;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public PersonalInformation PersonalInfo { get; set; }

        public bool IsOlderThan(Student student)
        {
            var firstStudentBirthday = this.PersonalInfo.DateOfBirth;
            var secondStudentBirthday = student.PersonalInfo.DateOfBirth;

            bool isOlder = false;

            if (firstStudentBirthday.CompareTo(secondStudentBirthday) < 0)
            {
                isOlder = true;
            }

            return isOlder;
        }
    }
}