using System;
class FromDecimalToHexademical
{
    static string ConvertToHex(int decimalNumber)
    {
        string result = "";

        while (decimalNumber > 0)
        {
            result = GetSymbol(decimalNumber % 16) + result;

            decimalNumber /= 16;
        }

        return result;
    }

    static char GetSymbol(int number)
    {
        char symbol;

        if (number >= 0 && number <= 9)
        {
            symbol = (char) (number + '0');
        }

        else
        {
            symbol = (char) ('A' + number - 10);
        }

        return symbol;
    }

    static void Main()
    {
        string decimalAsString = Console.ReadLine();
        int decimalNumber = int.Parse(decimalAsString);

        string hexadecimal = decimalNumber.ToString("X");

        Console.WriteLine(hexadecimal);

        //other solution with methods
        string hexNumber = ConvertToHex(decimalNumber);
        Console.WriteLine(hexNumber);
    }
}

