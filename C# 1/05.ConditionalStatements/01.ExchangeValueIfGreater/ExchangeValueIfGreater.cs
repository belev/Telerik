using System;

class ExchangeValueIfGreater
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Please enter other number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        if (firstNumber > secondNumber)
        {
            firstNumber ^= secondNumber;
            secondNumber ^= firstNumber;
            firstNumber ^= secondNumber;
        }
    }
}

