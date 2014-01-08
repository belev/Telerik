using System;
class FromHexToDecimal
{
    static ulong ConvertToDecimal(string hexNumber)
    {
        ulong exp = 1;
        ulong result = 0;

        for (int i = hexNumber.Length - 1; i >= 0; i--)
        {
            if(hexNumber[i] >= 'A' && hexNumber[i] <= 'F')
            {
                result += exp * (ulong)(hexNumber[i] - 'A' + 10);
            }
            else
            {
                result += exp * (ulong)(hexNumber[i] - '0');
            }

            exp *= 16;
        }

        return result;
    }

    static void Main()
    {
        string hexNumber = Console.ReadLine();

        int decimalNumber = Convert.ToInt32(hexNumber, 16);

        Console.WriteLine(decimalNumber);

        //other solution
        ulong result = ConvertToDecimal(hexNumber);
        Console.WriteLine(result);
    }
}

