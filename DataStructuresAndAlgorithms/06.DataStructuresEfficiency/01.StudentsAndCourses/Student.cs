namespace _01.StudentsAndCourses
{
    using System;

    public class Student : IComparable<Student>
    {
        private string firstName;

        private string lastName;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null or empty!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("First name should have at least 3 letters in it!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty!");
                }

                if (value.Length <= 4)
                {
                    throw new ArgumentOutOfRangeException("Last name should have at least 5 letters in it!");
                }

                this.lastName = value;
            }
        }

        public int CompareTo(Student other)
        {
            if (this.LastName == other.LastName)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }

            return this.LastName.CompareTo(other.LastName);
        }

        public override string ToString()
        {
            return (this.FirstName + " " + this.LastName);
        }
    }
}