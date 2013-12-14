using System;
using System.Numerics;

//Write a program that calculates N!/K! for given N and K (1<K<N).

class CalculateFactorialDivision
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());

        BigInteger result = 1;
        int subtraction = n - k;

        for (int i = 0; i < subtraction; i++)
        {
            result *= n--;
        }

        Console.WriteLine("N! / K! = {0}", result);
    }
}

