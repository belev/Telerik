using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FindStudentsWithFirstNameBeforeLast
{
    public class Student
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            StringBuilder studentOutput = new StringBuilder();

            studentOutput.AppendLine("Student:");
            studentOutput.AppendLine("First name: " + this.FirstName);
            studentOutput.AppendLine("Last name: " + this.LastName);

            return studentOutput.ToString();
        }
    }
}
