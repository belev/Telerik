using System;
class BinaryRepresentationOfInteger
{
    static void Main()
    {
        int decimalNumber = int.Parse(Console.ReadLine());

        Console.WriteLine(Convert.ToString(decimalNumber, 2).PadLeft(16, '0'));

        //other solution
        for (int i = 15; i >= 0; i--)
        {
            Console.Write((decimalNumber >> i) & 1);
        }
        Console.WriteLine();
    }
}

