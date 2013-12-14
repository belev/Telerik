using System;

//Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N
class CalculateSequenceSum
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter x: ");
        int x = int.Parse(Console.ReadLine());

        double sumOfSequence = 1.0;

        ulong xPow = 1;
        ulong factorial = 1;
        

        for (int i = 1; i <= n; i++)
        {
            xPow *= (ulong)x;
            factorial *= (ulong)i;

            sumOfSequence += (double)factorial / xPow;
        }

        Console.WriteLine("The sum of the sequence is: {0}", sumOfSequence);
    }
}

