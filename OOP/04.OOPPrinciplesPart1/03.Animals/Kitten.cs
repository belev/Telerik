using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class Kitten : Cat
    {
        public Kitten(int age, string name)
            : base(age, name, 'F')
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Kitten makes sound.");
        }
    }
}
