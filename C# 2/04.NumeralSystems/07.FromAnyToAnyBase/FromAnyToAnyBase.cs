using System;
class FromAnyToAnyBase
{
    static int GetInt(char symbol)
    {
        int digit = 0;

        if (symbol >= 'A')
        {
            digit = symbol - 'A' + 10;
        }
        else
        {
            digit = symbol - '0';
        }

        return digit;
    }

    static char GetChar(int number)
    {
        if (number >= 0 && number < 10)
        {
            return (char) (number + '0');
        }
        else
        {
            return (char) (number + 'A' - 10);
        }
    }

    static int ConvertFromSBaseToDecimal(string sBaseNumber, int s)
    {
        int result = 0;
        int exp = 1;

        for (int i = sBaseNumber.Length - 1; i >= 0; i--)
        {
            int digit = GetInt(sBaseNumber[i]);

            result += exp * digit;

            exp *= s;
        }

        return result;
    }

    static string ConvertFromDecimalToDBase(int number, int d)
    {
        string result = "";

        while (number > 0)
        {
            result = GetChar(number % d) + result;
            number /= d;
        }

        return result;
    }

    static void Main()
    {
        Console.Write("Please enter which numeral system will you use: ");
        int s = int.Parse(Console.ReadLine());

        Console.Write("Please enter to which numeral system do you want to convert the number: ");
        int d = int.Parse(Console.ReadLine());

        Console.Write("Enter your number in {0} base: ", s);
        string sBaseNumberAsString = Console.ReadLine();

        int decimalNum = ConvertFromSBaseToDecimal(sBaseNumberAsString, s);

        if (d != 10)
        {
            string numberInDBaseSystem = ConvertFromDecimalToDBase(decimalNum, d);
            Console.Write("The converted number from {0} base to {1} base is: ", s, d);
            Console.WriteLine(numberInDBaseSystem);
        }
        else
        {
            Console.Write("Your number from {0} to decimal is: ", s);
            Console.WriteLine(decimalNum);
        }
    }
}

