using System;

//* Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
//N = 10 -> N! = 3628800 -> 2
//N = 20 -> N! = 2432902008176640000 -> 4
class TrailingZerosOfFactorial
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        int numberOfZeros = 0;
        for (int currentNumberInFactorial = 5; currentNumberInFactorial <= n; currentNumberInFactorial++)
        {
            int tmp = currentNumberInFactorial;

            while (tmp % 5 == 0)
            {
                numberOfZeros++;
                tmp /= 5;
            }
        }

        Console.WriteLine("The number of trailing zeros in {0}! are: {1}", n, numberOfZeros);
    }
}

