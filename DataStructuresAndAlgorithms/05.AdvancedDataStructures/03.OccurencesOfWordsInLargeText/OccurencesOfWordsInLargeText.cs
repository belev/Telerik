namespace _03.OccurencesOfWordsInLargeText
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    public class OccurencesOfWordsInLargeText
    {
        static void Main()
        {
            var watch = new Stopwatch();

            // reading and building the trie is slow around 30 - 35 seconds so wait a little bit
            // searching is really fast
            watch.Start();
            Trie textAsTrie = new Trie();

            StreamReader reader = new StreamReader("text.txt");

            using (reader)
            {
                string allText = reader.ReadToEnd();

                textAsTrie.BuildTrie(allText);
            }

            // there are 25 different words coppied a lot of times, all words in words.txt is 1000
            StreamReader words = new StreamReader("words.txt");
            var allWordsToSearch = new List<string>();

            using (words)
            {
                string word = words.ReadLine();

                while (words.ReadLine() != null)
                {
                    allWordsToSearch.Add(word);
                    word = words.ReadLine();
                }
            }

            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            watch.Reset();

            watch.Start();
            StreamWriter writer = new StreamWriter("WordsOccurences.txt");

            foreach (var word in allWordsToSearch)
            {
                int wordOccurencesCount = textAsTrie.GetWordOccurences(word);

                writer.WriteLine(string.Format("{0} -> {1} times", word, wordOccurencesCount));
            }

            int peaceOccCount = textAsTrie.GetWordOccurences("Peace");

            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            Console.WriteLine(peaceOccCount);
        }
    }
}