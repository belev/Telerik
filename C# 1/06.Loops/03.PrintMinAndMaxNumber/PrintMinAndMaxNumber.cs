using System;

//Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

class PrintMinAndMaxNumber
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        int minElement = int.MaxValue;
        int maxElement = int.MinValue;

        Console.Write("Please enter {0} numbers");
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());

            if (maxElement < number)
            {
                maxElement = number;
            }

            if (minElement > number)
            {
                minElement = number;
            }
        }

        Console.WriteLine("Minimal element: {0} and Maximal element: {1}", minElement, maxElement);
    }
}

