using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
class CountWordsOccurancesInFile
{
    static List<string> GetWordsFromLine(string line)
    {
        List<string> words = new List<string>();
        StringBuilder word = new StringBuilder();

        foreach (char symbol in line)
        {
            if (symbol == ' ' && word.ToString() != String.Empty)
            {
                words.Add(word.ToString());
                word.Clear();
            }
            else
            {
                word.Append(symbol);
            }
        }

        if (word.ToString() != String.Empty)
        {
            words.Add(word.ToString());
        }

        return words;
    }
    static void Main()
    {
        try
        {
            Dictionary<string, int> wordsToSearchFor = new Dictionary<string, int>();
            using (StreamReader readerForWords = new StreamReader(@"..\..\words.txt"))
            {
                string[] rawWords = readerForWords.ReadLine().Split(' ');

                for (int i = 0; i < rawWords.Length; i++)
                {
                    wordsToSearchFor.Add(rawWords[i], 0);
                }
            }

            StreamReader reader = new StreamReader(@"..\..\test.txt");
            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    List<string> wordsOnLine = GetWordsFromLine(line);

                    for (int i = 0; i < wordsOnLine.Count; i++)
                    {
                        if (wordsToSearchFor.ContainsKey(wordsOnLine[i]))
                        {
                            wordsToSearchFor[wordsOnLine[i]]++;
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            var orderedByDescending = wordsToSearchFor.OrderByDescending(x => x.Value);

            StreamWriter writer = new StreamWriter(@"..\..\result.txt");
            using (writer)
            {
                foreach (var pair in orderedByDescending)
                {
                    writer.WriteLine(pair.Key + " " + pair.Value);
                }
            }
        }
        catch (OutOfMemoryException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

