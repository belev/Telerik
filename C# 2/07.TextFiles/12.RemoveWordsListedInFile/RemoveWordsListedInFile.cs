using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
class RemoveWordsListedInFile
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
        /*Test with:
         *  I know that you would be able
            to get through this by yourself,
            but why should you have to?
            I just wanted you to know that
            I am here for you always.
         Forbidden words: I that you
         */
        List<string> forbiddenWords = new List<string>();
        try
        {
            //get forbidden words
            using (StreamReader readerWords = new StreamReader(@"..\..\words.txt"))
            {
                string[] rawWords = readerWords.ReadLine().Split(' ');

                for (int i = 0; i < rawWords.Length; i++)
                {
                    forbiddenWords.Add(rawWords[i]);
                }
            }

            StreamReader reader = new StreamReader(@"..\..\text.txt");
            StringBuilder result = new StringBuilder();

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    //get words on line
                    List<string> wordsOnLine = GetWordsFromLine(line);

                    for (int i = 0; i < wordsOnLine.Count; i++)
                    {
                        //if the word on line is not one of the forbidden words appen it to the result
                        if (forbiddenWords.Contains(wordsOnLine[i]) == false)
                        {
                            result.Append(wordsOnLine[i]);

                            if (i != wordsOnLine.Count)
                            {
                                result.Append(" ");
                            }
                        }
                    }

                    line = reader.ReadLine();
                    result.AppendLine();
                }
            }

            StreamWriter writer = new StreamWriter(@"..\..\text.txt");

            using (writer)
            {
                writer.Write(result.ToString());
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

