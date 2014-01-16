using System;
using System.Collections.Generic;
using System.Linq;
class CountLettersOccurances
{
    static void Main()
    {
        string text = Console.ReadLine();

        Dictionary<char, int> letters = new Dictionary<char, int>();

        foreach (char symbol in text)
        {
            if (char.IsLetter(symbol))
            {
                if (!letters.ContainsKey(symbol))
                {
                    letters.Add(symbol, 1);
                }
                else
                {
                    letters[symbol]++;
                }
            }
        }
        //order the letters by number of appearences
        var orderedLetters = letters.OrderByDescending(x => x.Value);

        //print the letter and how many times it appears in the text
        foreach (var pair in orderedLetters)
        {
            Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
        }
    }
}

