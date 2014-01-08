using System;
class FromBinaryToHex
{
    static char GetChar(int x)
    {
        if (x >= 10)
        {
            return (char) ('A' + x - 10);
        }
        else
        {
            return (char) (x + '0');
        }
    }

    static int GetInt(char x)
    {
        return (int) (x - '0');
    }

    static string ConvertBinaryToHex(string binaryNumber)
    {
        string result = "";
        int tmp = 0, exp = 1;
        for (int i = binaryNumber.Length - 1; i >= 0; )
        {
            tmp = 0;
            exp = 1;
            for (int j = 0; j < 4 && i >= 0; ++j, --i)
            {
                //take four bits from the binary representation
                //and add it to tmp (tmp max value is 15)
                tmp += GetInt(binaryNumber[i]) * exp;
                //exp *= 2, but with bitwise operation is faster,that is why i use it
                exp <<= 1;
            }
            //than get the symbol in hexadecimal and concatenate it with the result
            result = GetChar(tmp) + result;
        }

        return result;
    }

    static void Main(string[] args)
    {
        string binaryNumber = Console.ReadLine();
        string hexNumber = ConvertBinaryToHex(binaryNumber);

        Console.WriteLine(hexNumber);

        //other solution

        int decimalNum = Convert.ToInt32(binaryNumber, 2);
        string hex = decimalNum.ToString("X");
        Console.WriteLine(hex);
    }
}

