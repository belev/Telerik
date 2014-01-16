using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
class TranslateWord
{
    static void Main()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        StreamReader reader = new StreamReader(@"..\..\DictionaryInformation.txt");
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] splittedLine = line.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                string word = splittedLine[0];
                string explanation = splittedLine[1];

                dictionary.Add(word, explanation);

                line = reader.ReadLine();
            }
        }

        string inputWord = Console.ReadLine();

        if (dictionary.ContainsKey(inputWord))
        {
            Console.WriteLine("Explanation of the word: {0} -> {1}",inputWord, dictionary[inputWord]);
        }
        else
        {
            Console.WriteLine("There is no such word in the dictionary.");
        }
    }
}

