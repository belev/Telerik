using System;
using System.Numerics;

//Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

class CalculateSumOfNFibonacciMembers
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        ulong fib0 = 0;
        ulong fib1 = 1;

        BigInteger sum = 1;

        for (int i = 2; i < n; i++)
        {
            ulong fib2 = fib0 + fib1;
            fib0 = fib1;
            fib1 = fib2;

            sum += fib2;
        }

        Console.WriteLine("The sum of the first {0} members of the Fibonacci sequence is: {1}", n, sum);
    }
}

