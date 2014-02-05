using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SortStudentsInDescendingOrder
{
    public class Student
    {
        private string firstName;
        private string lastName;

        public string FirstName { get { return this.firstName; } }
        public string LastName { get { return this.lastName; } }

        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.firstName, this.lastName);
        }
    }
}
