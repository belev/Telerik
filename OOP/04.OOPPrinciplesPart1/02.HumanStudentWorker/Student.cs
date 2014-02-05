using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanStudentWorker
{
    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }
        public int Grade
        {
            get { return this.grade; }
            set
            {
                if (value <= 0 || value >= 13)
                {
                    throw new ArgumentException("Invalid grade input!");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2} grade", this.FirstName, this.LastName, this.Grade);
        }
    }
}
