using System;

class ModifyBitInNumber
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Please enter bit value: ");
        int bitValue = int.Parse(Console.ReadLine());

        Console.Write("Please enter position: ");
        int position = int.Parse(Console.ReadLine());

        if (bitValue == 1)
        {
            number |= (1 << position);
        }
        else
        {
            number = (~(1 << position) & number);
        }

       Console.WriteLine("The number you entered after modifying is {0}", number);
    }
}

