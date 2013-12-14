using System;

//Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).

class FindGreatestCommonDivisor
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        int greatestCommonDivisor = 1;

        //swap vallues if second > first
        if (secondNumber > firstNumber)
        {
            firstNumber ^= secondNumber;
            secondNumber ^= firstNumber;
            firstNumber ^= secondNumber;
        }

        //Euclidean algorithm
        while (secondNumber != 0)
        {
            int tmp = secondNumber;
            secondNumber = firstNumber % secondNumber;
            firstNumber = tmp;
        }

        Console.WriteLine("The greatest common divisor is: {0}", firstNumber);
    }
}

