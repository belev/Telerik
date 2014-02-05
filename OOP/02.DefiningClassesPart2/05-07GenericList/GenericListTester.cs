using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_07GenericList
{
    class ProGenericListTestergram
    {
        static void Main(string[] args)
        {
            GenericList<int> numbers = new GenericList<int>(9);

            numbers.Add(15);
            numbers.Add(20);
            numbers.Add(100);
            numbers.Add(-200);
            numbers.Add(-20);
            //remove at position 2 (this is 100)
            numbers.RemoveAt(2);

            //print element on position 2
            //the output is -200
            Console.WriteLine(numbers[2]);

            //check method for finding element
            int index = numbers.FindElementIndex(-20);
            Console.WriteLine("The index of {0} is {1}", -20, index);

            //if there is no such element the result is -1
            index = numbers.FindElementIndex(-30);
            if (index < 0)
            {
                Console.WriteLine("There is no such element!");
            }

            //test the override ToString method
            Console.WriteLine(numbers.ToString());

            //test Min and Max methods
            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Min());

            numbers.Clear();
        }
    }
}
