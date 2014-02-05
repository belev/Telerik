using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public class Cat : Animal
    {
        public Cat(int age, string name, char gender)
            : base(age, name, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cat makes sound");
        }
    }
}
