using System;
using System.Numerics;

//Write a program to calculate the Nth Catalan number by given N.

class CalculateCatalanNumber
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        BigInteger NthCatalanNumber = 1;

        if (n >= 1)
        {
            BigInteger numerator = 1;
            BigInteger denominator = 1;

            for (int i = 1; i < n + 1; i++)
            {
                numerator *= 2 * i * (2 * i - 1); //calculate (2N)!
                denominator *= i * (i + 1); //calculate N! * (N + 1)!
            }

            NthCatalanNumber = numerator / denominator;
            Console.WriteLine("The {0} Catalan number is: {1}", n, NthCatalanNumber);
        }
        else
        {
            Console.WriteLine(1);
        }
    }
}

