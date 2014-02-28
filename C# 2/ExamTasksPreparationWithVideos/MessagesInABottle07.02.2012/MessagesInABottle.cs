using System;
using System.Collections.Generic;
using System.Text;
class MessagesInABottle
{
    private static void GenerateMessages(string leftCode, string current)
    {
        if (leftCode.Length == 0)
        {
            result.Add(current);
        }
        else
        {
            for (int i = 0; i < digits.Count; i++)
            {
                if (leftCode.StartsWith(digits[i]))
                {
                    GenerateMessages(leftCode.Substring(digits[i].Length), current + letters[i]);
                }
            }
        }
    }

    public static List<string> digits;
    public static List<char> letters;

    public static List<string> result;
    static void Main()
    {
        string code = Console.ReadLine();
        string cipher = Console.ReadLine();

        GetCipherRepresentation(cipher);

        result = new List<string>();

        GenerateMessages(code, "");

        result.Sort();

        Console.WriteLine(result.Count);
        for (int i = 0; i < result.Count; i++)
        {
            Console.WriteLine(result[i]);
        }
    }

    private static void GetCipherRepresentation(string cipher)
    {
        cipher += "Z";

        digits = new List<string>();
        letters = new List<char>();

        StringBuilder currentDigits = new StringBuilder();
        char letter = '\0';

        for (int i = 0; i < cipher.Length; i++)
        {
            char curChar = cipher[i];

            if (char.IsLetter(curChar))
            {
                if (letter != '\0')
                {
                    letters.Add(letter);
                    digits.Add(currentDigits.ToString());

                    currentDigits.Clear();
                }
                letter = curChar;
            }
            else
            {
                currentDigits.Append(curChar);
            }

        }
    }
}

