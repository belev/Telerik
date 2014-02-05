using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private char gender;

        public Animal(int age, string name, char gender)
        {
            this.Age = age;
            this.Name = name;
            this.Gender = gender;
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new IndexOutOfRangeException("Invalid age!");
                }

                this.age = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Invalid animal name! Name can not be null, whitespace or empty!");
                }

                this.name = value;
            }
        }

        public char Gender
        {
            get { return this.gender; }
            protected set
            {
                if (value != 'f' && value != 'm' && value != 'F' && value != 'M')
                {
                    throw new ArgumentException("Invalid gender input!");
                }

                this.gender = value;
            }
        }

        public abstract void ProduceSound();

        public override string ToString()
        {
            return string.Format("{0} - {1} {2} {3}", this.GetType().Name, this.Name, this.Age, this.Gender);
        }

        public static double AverageAge(Animal[] animals)
        {
            double sum = 0.0;

            foreach (Animal animal in animals)
            {
                sum += animal.Age;
            }
            sum /= animals.Length;

            return sum;
        }
    }
}