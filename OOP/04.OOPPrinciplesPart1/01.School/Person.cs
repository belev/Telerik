using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Person : Comment
    {
        private string name;

        public Person(string name)
        {
            this.Name = name;
        }
        public string Name 
        {
            get { return this.name; }
            protected set
            {
                if (value == string.Empty || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("That's not a name! Invalid name input!");
                }

                this.name = value;
            }
        }
    }
}
