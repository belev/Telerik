using System;

class Print100FibonacciSequenceMembers
{
    static void Main()
    {
        ulong previousNumber = 0;
        ulong currentNumber = 1;

        Console.Write("{0}, {1}", previousNumber, currentNumber);

        for (int i = 2; i < 100; i++)
        {
            ulong nextNumber = previousNumber + currentNumber;

            Console.Write(", {0}", nextNumber);

            previousNumber = currentNumber;
            currentNumber = nextNumber;
        }
        Console.WriteLine();
    }
}

