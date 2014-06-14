namespace _01.School
{
    using System;

    public class Student
    {
        public const int MinIdValue = 10000;
        public const int MaxIdValue = 99999;

        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Student's name can not be null or empty.");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (value < MinIdValue || value > MaxIdValue)
                {
                    throw new ArgumentOutOfRangeException("Student's id must be between 10 000 and 99 999.");
                }

                this.id = value;
            }
        }
    }
}
