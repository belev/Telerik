using System;
using System.Collections.Generic;
using System.Text;
class Crossword
{
    static bool CheckVerticals()
    {
        for (int col = 0; col < crossword.Length; col++)
        {
            StringBuilder word = new StringBuilder();
            for (int row = 0; row < crossword.Length; row++)
            {
                word.Append(crossword[row][col]);
            }

            string wordAsString = word.ToString();

            if (Array.IndexOf(words, wordAsString) == -1)
            {
                return false;
            }
        }
        return true;
    }

    static string[] words;
    static string[] crossword;
    static void FindCrossword(int index)
    {
        if (index >= crossword.Length)
        {
            if (CheckVerticals())
            {
                for (int i = 0; i < crossword.Length; i++)
                {
                    Console.WriteLine(crossword[i]);
                }
                Environment.Exit(0);
            }
            return;
        }

        for (int i = 0; i < words.Length; i++)
        {
            crossword[index] = words[i];

            FindCrossword(index + 1);
            crossword[index] = null;
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        crossword = new string[n];
        words = new string[2 * n];

        for (int i = 0; i < 2 * n; i++)
        {
            words[i] = Console.ReadLine();
        }
        Array.Sort(words);

        FindCrossword(0);

        Console.WriteLine("NO SOLUTION!");
    }
}

