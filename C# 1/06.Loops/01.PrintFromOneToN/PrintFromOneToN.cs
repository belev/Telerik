using System;

class PrintFromOneToN
{
    //Write a program that prints all the numbers from 1 to N.

    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i < n + 1; i++)
        {
            Console.Write(i);

            if (i != n)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}

