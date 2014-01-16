using System;
using System.Text;
class ReplaceConsecutiveLetters
{
    static void Main()
    {
        string text = Console.ReadLine();

        StringBuilder result = new StringBuilder();


        for (int i = 0; i < text.Length; i++)
        {
            char symbol = text[i];
            result.Append(symbol);

            while (i + 1 < text.Length && symbol == text[i + 1])
            {
                i++;
            }
        }
        Console.WriteLine(result.ToString());
    }
}

