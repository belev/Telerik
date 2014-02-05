using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Student : Person
    {
        private int numberInClass;

        public Student(string name, int numberInClass)
            : base(name)
        {
            this.NumberInClass = numberInClass;

        }
        public int NumberInClass
        {
            get { return this.numberInClass; }
            private set
            {
                if (value > 0)
                {
                    this.numberInClass = value;
                }
                else
                {
                    throw new ArgumentException("Invalid class number!");
                }
            }
        }
    }
}
