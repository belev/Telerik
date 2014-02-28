using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Person
{
    public class Person
    {
        private string name;
        private int? age;

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(string name, int? age)
            : this(name)
        {
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == string.Empty || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can't be null, whitespace or empty!");
                }
                this.name = value;
            }
        }

        public int? Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0 || value >= 120)
                {
                    throw new ArgumentOutOfRangeException("Age of person can't be negative or bigger than 120!");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Name: " + this.Name);

            if (this.Age != null)
            {
                result.Append("Age: " + this.Age);
            }
            else
            {
                result.Append("Age: no information");
            }

            return result.ToString();
        }
    }
}
