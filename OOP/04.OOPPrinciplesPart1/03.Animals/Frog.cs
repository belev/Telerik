using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public class Frog : Animal
    {
        public Frog(int age, string name, char gender)
            : base(age, name, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Frog makes sound.");
        }
    }
}
