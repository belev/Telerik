using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Person
{
    //04.Create a class Person with two fields – name and age. Age can be left unspecified 
    //(may contain null value. Override ToString() to display the information of a person and if age is not specified – to say so.
    //Write a program to test this functionality.

    class Tester
    {
        static void Main()
        {
            Person pesho = new Person("Petar Dimitrov", 15);
            Person mariq = new Person("Mariq Petrova", null);
            Person grigor = new Person("Grigor Vasilev");

            Console.WriteLine(pesho);
            Console.WriteLine();

            Console.WriteLine(mariq);
            Console.WriteLine();

            Console.WriteLine(grigor);
            Console.WriteLine();
        }
    }
}
