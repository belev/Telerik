using System;
using System.Collections.Generic;
class KaspichanNumbers
{
    static List<int> ConvertFromDecimalTo255base(ulong number)
    {
        List<int> result = new List<int>();

        if (number == 0)
        {
            result.Add(0);
            return result;
        }

        while (number > 0)
        {
            int tmp = (int) (number % 256);

            result.Add(tmp);
            number /= 256;
        }

        return result;
    }

    static string ConvertNumberToSymbol(int number)
    {
        string kaspichanNumber = "";

        if (number >= 0 && number <= 25)
        {
            kaspichanNumber += (char) (number + 'A');
        }

        else if (number >= 26 && number <= 255)
        {
            int digitForSecondSymbol = number / 26;
            kaspichanNumber += (char) (digitForSecondSymbol + 'a' - 1);

            number %= 26;

            kaspichanNumber += ConvertNumberToSymbol(number);
        }


        return kaspichanNumber;
    }

    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        string kaspichanNumber = "";

        List<int> result = ConvertFromDecimalTo255base(number);

        for (int i = result.Count - 1; i >= 0; i--)
        {
            kaspichanNumber += ConvertNumberToSymbol(result[i]);
        }

        Console.WriteLine(kaspichanNumber);
    }
}

