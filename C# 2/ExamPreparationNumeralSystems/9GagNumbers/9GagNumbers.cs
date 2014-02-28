using System;
class NineGagNumbers
{
    static string GetDigitsFromNineGagRepresantation(string sequence)
    {
        string tmpSequence = "";
        string result = "";

        for (int i = 0; i < sequence.Length; i++)
        {
            tmpSequence += sequence[i];

            switch (tmpSequence)
            {
                case "-!":
                    result += 0;
                    tmpSequence = "";
                    break;
                case "**":
                    result += 1;
                    tmpSequence = "";
                    break;
                case "!!!":
                    result += 2;
                    tmpSequence = "";
                    break;
                case "&&":
                    result += 3;
                    tmpSequence = "";
                    break;
                case "&-":
                    result += 4;
                    tmpSequence = "";
                    break;
                case "!-":
                    result += 5;
                    tmpSequence = "";
                    break;
                case "*!!!":
                    result += 6;
                    tmpSequence = "";
                    break;
                case "&*!":
                    result += 7;
                    tmpSequence = "";
                    break;
                case "!!**!-":
                    result += 8;
                    tmpSequence = "";
                    break;
            }
        }

        return result;
    }


    static ulong convertFromNineBaseToDecimal(string numberAsString)
    {
        ulong exp = 1UL;
        ulong result = 0UL;

        for (int i = numberAsString.Length - 1; i >= 0; i--)
        {
            result += exp * ((ulong)(numberAsString[i] - '0'));
            exp *= 9;
        }

        return result;
    }

    static void Main()
    {
        string nineGagNumber = Console.ReadLine();

        string digitsFrom9Gag = GetDigitsFromNineGagRepresantation(nineGagNumber);

        ulong decimalNumber = convertFromNineBaseToDecimal(digitsFrom9Gag);

        Console.WriteLine(decimalNumber);
    }
}

