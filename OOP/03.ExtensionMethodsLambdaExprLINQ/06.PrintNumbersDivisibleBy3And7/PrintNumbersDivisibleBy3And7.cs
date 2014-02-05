using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PrintNumbersDivisibleBy3And7
{
    //06.Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

    class PrintNumbersDivisibleBy3And7
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 3, 15, 21, 19, 42, 7, 55, 29, 84, 99, 168 };

            var divisibleBy3And7WithLambda = numbers.Where(x => x % 21 == 0);

            foreach (var number in divisibleBy3And7WithLambda)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            var divisibleBy3And7WithLINQ =
                from number in numbers
                where number % 21 == 0
                select number;

            foreach (var number in divisibleBy3And7WithLINQ)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
