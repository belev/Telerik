using System;

class PrintNumbersFrom1ToN
{
    static void Main()
    {
        Console.Write("Please enter to where do you want to print the numbers: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}

