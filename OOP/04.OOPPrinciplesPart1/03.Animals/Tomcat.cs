using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(int age, string name)
            : base(age, name, 'M')
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Tomcat make sound.");
        }
    }
}
