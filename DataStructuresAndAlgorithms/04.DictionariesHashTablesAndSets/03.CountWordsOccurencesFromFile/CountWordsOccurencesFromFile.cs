namespace _03.CountWordsOccurencesFromFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CountWordsOccurencesFromFile
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("words.txt");

            using (reader)
            {
                // get the text to lower case as said in the task
                string allText = reader.ReadToEnd().ToLower();

                var splittedText = allText.Split(new char[] {' ', ',', '!', '?', '-', '.', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);

                var wordsOccurences = new Dictionary<string, int>();

                // fill the dictionary with word and its number of occurences
                foreach (var word in splittedText)
                {
                    if (wordsOccurences.ContainsKey(word))
                    {
                        wordsOccurences[word]++;
                    }
                    else
                    {
                        wordsOccurences.Add(word, 1);
                    }
                }

                // sort words by number of occurences
                var sortedWordsByOccurences = wordsOccurences.OrderBy(w => w.Value);

                foreach (var pair in sortedWordsByOccurences)
                {
                    Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
                }
            }
        }
    }
}
