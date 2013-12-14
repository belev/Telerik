using System;

class CountNumbersDivisibleBy5InRange
{
    static void Main()
    {
        Console.Write("Please enter first number: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Please enter second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        //if firstNumber is bigger exchange their value so that firstNumber will be smaller
        if (firstNumber > secondNumber)
        {
            firstNumber ^= secondNumber;
            secondNumber ^= firstNumber;
            firstNumber ^= secondNumber;
        }

        int counter = 0;

        for (int i = firstNumber; i <= secondNumber; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
            }
        }

        Console.WriteLine("From {0} to {1}, there are {2} numbers that are divisible by 5.", firstNumber, secondNumber, counter);
    }
}
