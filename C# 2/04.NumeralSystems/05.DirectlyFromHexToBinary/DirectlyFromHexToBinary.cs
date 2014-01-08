using System;
class DirectlyFromHexToBinary
{
    static int GetByte(char symbol)
    {
        if (symbol >= 'A')
        {
            return symbol - 'A' + 10;
        }
        else
        {
            return symbol - '0';
        }
    }

    static string ConvertToBinary(string hexNumber)
    {
        string result = "";

        for (int i = hexNumber.Length - 1; i >= 0; i--)
        {
            //one symbol from hexadecimal number is 4 symbols in binary so we take 1 byte
            int bit = GetByte(hexNumber[i]);

            //and our loop is with four steps
            for (int j = 0; j < 4; j++)
            {
                result = (bit & 1) + result;
                bit >>= 1;
            }
        }

       result = result.TrimStart('0');
        return result;
    }


    static void Main()
    {
        string hexNumber = Console.ReadLine();

        string binaryRepresantation = Convert.ToString(Convert.ToInt32(hexNumber, 16), 2);

        Console.WriteLine(binaryRepresantation);

        //other solution
        string binaryResult = ConvertToBinary(hexNumber);
        Console.WriteLine(binaryResult);
    }
}

