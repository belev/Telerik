using System;
class FromBinaryToDecimal
{
    private static ulong ConvertToDecimal(string binaryNumber)
    {
        ulong resultInDecimal = 0UL;
        ulong powerOfTwo = 1UL;

        for (int i = binaryNumber.Length - 1; i >= 0; i--)
        {

            if (binaryNumber[i] == '1')
            {

                resultInDecimal += powerOfTwo;
            }

            powerOfTwo *= 2;
        }

        return resultInDecimal;
    }

    static void Main()
    {
        string binaryNumber = Console.ReadLine();

        int decimalNumber = Convert.ToInt32(binaryNumber, 2);

        Console.WriteLine(decimalNumber);

        //other solution

        ulong resultInDecimal = ConvertToDecimal(binaryNumber);

        Console.WriteLine(resultInDecimal);
    }

}

