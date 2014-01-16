using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class CountWordsAppearences
{
    static void Main()
    {
        string text = Console.ReadLine();

        MatchCollection wordsAsMatches = Regex.Matches(text, @"\w+");
        Dictionary<string, int> wordsCount = new Dictionary<string,int>();

        foreach (var matchedWord in wordsAsMatches)
        {
            string word = matchedWord.ToString();

            if (!wordsCount.ContainsKey(word))
            {
                wordsCount.Add(word, 1);
            }
            else
            {
                wordsCount[word]++;
            }
        }

        foreach (var word in wordsCount)
        {
            Console.WriteLine("{0} -> {1}", word.Key, word.Value);
        }
    }
}

