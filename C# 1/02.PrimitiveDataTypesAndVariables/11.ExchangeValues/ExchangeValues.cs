using System;

class ExchangeValues
{
    static void Main()
    {
        byte firstNumber = 5;
        byte secondNumber = 10;

        //using the bitwise operator ^ to swap firstNumber value and secondNumber value

        firstNumber ^= secondNumber; // in binary -> first = first ^ second = 0101 ^ 1100 = 1001
        secondNumber ^= firstNumber; // in binary -> second = second ^ first = 1100 ^ 1001 = 0101
        firstNumber ^= secondNumber; // in binary -> first = first ^ second = 1001 ^ 0101 = 1100

        Console.WriteLine(Environment.TickCount * 0.001);
    }
}

