using System;

class ExchangeKNumberOfBits
{
    static void Main()
    {
        Console.Write("Please enter non negative integer number: ");
        uint number = uint.Parse(Console.ReadLine());

        Console.WriteLine("The binary representation of the number is:");
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));

        Console.Write("Please position for bit to start: ");
        int p = int.Parse(Console.ReadLine());

        Console.Write("Please enter position to start exchange with: ");
        int q = int.Parse(Console.ReadLine());

        Console.Write("Please enter the number of bits you want to exchange: ");
        int numberOfBitsToChange = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfBitsToChange; i++)
        {
            int firstBitPosition = p + i;
            int secondBitPosition = q + i;

            int firstBitValue = (int)((number >> firstBitPosition) & 1);
            int secondBitValue = (int) ((number >> secondBitPosition) & 1);

            if (firstBitValue == 1)
            {
                number |= (uint)(1 << secondBitPosition);
            }
            else
            {
                number &= (uint)(~(1 << secondBitPosition));
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

        string numberAfterExchangeAsBinary = Convert.ToString(number, 2).PadLeft(32, '0');

        Console.WriteLine("The exchanged number is {0}", number);
        Console.WriteLine("In binary it is: {0}", numberAfterExchangeAsBinary);

    }
}

