using System;

class ExtractBitValue
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Please enter bit position: ");
        int position = int.Parse(Console.ReadLine());

        int bitValue = (number >> position) & 1;

        Console.WriteLine("The bit value at position {0} in the number {1} is -> {2}", position, number, bitValue);
    }
}

