using System;
using System.Collections.Generic;

class DurankulakNumbers
{
    static void Main()
    {
        string inputDurankulakNumber = Console.ReadLine();

        List<string> durankulakDigits = new List<string>();

        for (char i = 'A'; i <= 'Z'; i++)
        {
            durankulakDigits.Add(i.ToString());
        }

        for (char i = 'a'; i <= 'f'; i++)
        {
            if (i != 'f')
            {
                for (char j = 'A'; j <= 'Z'; j++)
                {
                    string durankulakDigit = i + j.ToString();

                    durankulakDigits.Add(durankulakDigit);
                }
            }
            else
            {
                for (char j = 'A'; j <= 'L'; j++)
                {
                    string durankulakDigit = i + j.ToString();

                    durankulakDigits.Add(durankulakDigit);
                }
            }
        }

        ulong powOf168 = 1;
        ulong resultAsDecimal = 0;

        for (int i = inputDurankulakNumber.Length - 1; i >= 0; i--)
        {
            char currentChar = inputDurankulakNumber[i];
            char nextChar = '\0';

            if (i > 0)
            {
                nextChar = inputDurankulakNumber[i - 1];
            }


            if (nextChar >= 'a' && nextChar <= 'f')
            {
                i--;
                string digit = nextChar.ToString() + currentChar;

                int indexOfDigit = durankulakDigits.IndexOf(digit);

                resultAsDecimal += (ulong)indexOfDigit * powOf168;
                powOf168 *= 168;
            }

            else if (nextChar == '\0' || (nextChar >= 'A' && nextChar <= 'Z'))
            {
                string digit = currentChar.ToString();

                int indexOfDigit = durankulakDigits.IndexOf(digit);

                resultAsDecimal += (ulong) indexOfDigit * powOf168;
                powOf168 *= 168;
            }
        }

        Console.WriteLine(resultAsDecimal);
    }
}

