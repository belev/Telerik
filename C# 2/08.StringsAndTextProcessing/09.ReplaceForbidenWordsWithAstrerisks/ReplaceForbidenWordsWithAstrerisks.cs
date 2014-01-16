using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class ReplaceForbidenWordsWithAstrerisks
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string[] rawForbiddenWords = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

        //string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        //string[] rawForbiddenWords = "PHP, CLR, Microsoft".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

        List<string> forbiddenWords = new List<string>();
        for (int i = 0; i < rawForbiddenWords.Length; i++)
        {
            forbiddenWords.Add(rawForbiddenWords[i]);
        }

        StringBuilder result = new StringBuilder(text);

        for (int i = 0; i < forbiddenWords.Count; i++)
        {
            //for each of the word use regular expression to replace the word with asterisks
            string tmpResult = Regex.Replace(result.ToString(), @"\b" + forbiddenWords[i] + @"\b", new string('*', forbiddenWords[i].Length));

            //clear the current result and then append the tmpResult
            result.Clear();
            result.Append(tmpResult);
        }
        Console.WriteLine(result.ToString());
    }
}
