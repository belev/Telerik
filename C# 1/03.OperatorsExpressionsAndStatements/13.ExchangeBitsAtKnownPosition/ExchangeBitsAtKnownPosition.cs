using System;

class ExchangeBitsAtKnownPosition
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        uint number = uint.Parse(Console.ReadLine());

        string numberAsBinary = Convert.ToString(number, 2).PadLeft(32, '0');

        Console.WriteLine(numberAsBinary);



        for (int i = 0; i < 3; i++)
        {
            int firstBitPosition = 3 + i;
            int secondBitPosition = 24 + i;

            int firstBitValue = (int) ((number >> firstBitPosition) & 1);
            int secondBitValue = (int) ((number >> secondBitPosition) & 1);

            if (firstBitValue == 1)
            {
                number |= (uint) (1 << secondBitPosition);
            }
            else
            {
                number &= (uint) (~(1 << secondBitPosition));
            }

            if (secondBitValue == 1)
            {
                number |= (uint) (1 << firstBitPosition);
            }
            else
            {
                number &= (uint) (~(1 << firstBitPosition));
            }
        }

        Console.WriteLine("Number with exchanged bits: {0}", number);
        Console.WriteLine("As binary : {0}", Convert.ToString(number, 2).PadLeft(32, '0'));
    }
}

