using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class ReverseWordsInSentence
{
    static void Main()
    {
        string sentence = Console.ReadLine();

        char[] separators = new char[] { ' ', ',', '.', '!', '?' };
        string[] words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Array.Reverse(words);

        string[] rawSymbols = Regex.Split(sentence, "[A-Za-z0-9#+]");

        List<string> symbolsToAdd = new List<string>();
        for (int i = 0; i < rawSymbols.Length; i++)
        {
            if (String.IsNullOrEmpty(rawSymbols[i]) == false)
            {
                symbolsToAdd.Add(rawSymbols[i]);
            }
        }

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < symbolsToAdd.Count; i++)
        {
            if (i < words.Length)
            {
                result.Append(words[i]);
            }

            result.Append(symbolsToAdd[i]);
        }

        Console.WriteLine(result.ToString());
    }
}

