namespace PersonFactory
{
    using System;

    public class PersonFactory
    {
        public enum Gender 
        { 
            Male,
            Female
        }

        public static void Main(string[] args)
        {
        }

        public void CreatePerson(int age)
        {
            Person person = new Person();
            person.Age = age;

            if (age % 2 == 0)
            {
                person.Name = "Dude";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "Babe";
                person.Gender = Gender.Female;
            }
        }

        public class Person
        {
            public Gender Gender { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}