using System;
using System.Linq;

public class SumOfSubsets
{

    static void Main()
    {
        int testsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < testsCount; i++)
        {
            var rawInput = Console.ReadLine().Split(' ');

            int n = int.Parse(rawInput[0]);
            int k = int.Parse(rawInput[1]);

            int[] numbers = new int[n];

            var rawNumbers = Console.ReadLine().Split(' ');

            for (int j = 0; j < rawNumbers.Length; j++)
            {
                numbers[j] = int.Parse(rawNumbers[j]);
            }

            Console.WriteLine(CalculateBinom(n - 1, k) * numbers.Sum());
        }
    }

    private static long CalculateBinom(int n, int k)
    {
        long nominator = 1;

        for (int i = (n - k + 1); i <= n; i++)
        {
            nominator *= i;
        }

        long denominator = 1;
        for (int i = 1; i <= k; i++)
        {
            denominator *= i;
        }

        return (nominator / denominator);
    }
}