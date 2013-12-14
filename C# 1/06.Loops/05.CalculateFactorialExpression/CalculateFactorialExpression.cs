using System;
using System.Numerics;

//Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

class CalculateFactorialExpression
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());

        BigInteger result = 1;

        // K! / (K - N)! = K * (K - 1) * ... (K - N + 1)

        for (int i = 1; i < n + 1; i++)
        {
            //result *= i equal to N!
            //result *= k and k-- is equal to K * (K - 1) * ... (K - N + 1)

            //so our final result is: result *= i * k , which is equal to N! * K * (K - 1) * ... (K - N + 1)
            result *= i * k;
            k--;
        }

        Console.WriteLine("N! * K! / (K - N)! = {0}", result);
    }
}

