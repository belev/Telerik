using System;

class FindThirdBit
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int number = int.Parse(Console.ReadLine());

        bool isOne = ((number >> 3) & 1) == 1;

        if (isOne)
        {
            Console.WriteLine("The bit at third position is 1");
        }
        else
        {
            Console.WriteLine("The bit at third position is 0");
        }
    }
}

