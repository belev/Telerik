using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FindStudentsBetween18And24YearsOld
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName { get { return this.firstName; } }
        public string LastName { get { return this.lastName; } }
        public int Age { get { return this.age; } }

        public Student(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public override string ToString()
        {
            StringBuilder studentOutput = new StringBuilder();

            studentOutput.AppendLine("Student:");
            studentOutput.AppendLine("First name: " + this.firstName);
            studentOutput.AppendLine("Last name: " + this.lastName);
            studentOutput.AppendLine("Age: " + this.age);

            return studentOutput.ToString();
        }
    }
}
