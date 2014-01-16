using System;
using System.Text.RegularExpressions;
class ExtractPalindromes
{
    private static bool IsPalindrome(string word)
    {
        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
    static void Main()
    {
        string text = Console.ReadLine();

        MatchCollection words = Regex.Matches(text, @"\w+");

        foreach (Match wordMatch in words)
        {
            string word = wordMatch.ToString();

            if (IsPalindrome(word))
            {
                Console.WriteLine(word);
            }
        }
    }
}

