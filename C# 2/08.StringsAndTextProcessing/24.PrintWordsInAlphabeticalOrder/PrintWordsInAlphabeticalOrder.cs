using System;
using System.Collections.Generic;
using System.Linq;
class PrintWordsInAlphabeticalOrder
{
    static void Main()
    {
        string inputWords = Console.ReadLine();

        string[] splittedWords = inputWords.Split(' ');

        List<string> words = new List<string>();

        for (int i = 0; i < splittedWords.Length; i++)
        {
            words.Add(splittedWords[i]);
        }

        words.Sort();

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}

