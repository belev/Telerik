using System;

class PrintNotDivisibleBy3And7
{
    //Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i < n + 1; i++)
        {
            if (i % 21 != 0)
            {
                Console.Write(i);

                if (i != n)
                {
                    Console.Write(" ");
                }
            }
        }
        Console.WriteLine();
    }
}

