using System;

class DeterminePBitPosition
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Please enter on which position to determine the bit: ");
        int position = int.Parse(Console.ReadLine());

        bool isOne = ((number >> position) & 1) == 1;

        Console.WriteLine("Is the bit 1 -> {0}", isOne);
    }
}

