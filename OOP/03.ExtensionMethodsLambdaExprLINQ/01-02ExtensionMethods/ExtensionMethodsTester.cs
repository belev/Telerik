using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _01_02ExtensionMethods
{
    class ExtensionMethodsTester
    {
        static void Main(string[] args)
        {
            //test extension methods for StringBuilder
            StringBuilder sb = new StringBuilder();
            sb.Append("Once a type is defined and compiled into an assembly its definition is, more or less, final");

            //add substring extension method, from index to the end
            StringBuilder substringToEnd = sb.Substring(5);
            Console.WriteLine(substringToEnd.ToString());

            //the extension method from the exercise task
            StringBuilder substring = sb.Substring(5, 6);
            Console.WriteLine(substring.ToString());

            //test IEnumerable extension methods
            List<double> numbers = new List<double>();
            numbers.Add(6.0);
            numbers.Add(10.0);
            numbers.Add(199.5);
            numbers.Add(0.5);
            numbers.Add(7.0);
            numbers.Add(20.0);

            double minElem = numbers.Min();
            double maxElem = numbers.Max();
            double sum = numbers.Sum();
            double average = numbers.Average();
            double product = numbers.Product();

            Console.WriteLine("Min element: " + minElem + "\nMax element: " + maxElem);
            Console.WriteLine("Sum : " + sum);
            Console.WriteLine("Average : " + average);
            Console.WriteLine("Product : " + product);

        }
    }
}
