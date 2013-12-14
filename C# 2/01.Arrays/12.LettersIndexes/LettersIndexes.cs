using System;
//Write a program that creates an array containing all letters from the alphabet (A-Z).
//Read a word from the console and print the index of each of its letters in the array.

class LettersIndexes
{
    static void Main()
    {
        char[] englishAlphabetLetters = new char[26];

        for (int i = 0; i < 26; i++)
        {
            englishAlphabetLetters[i] = (char)('A' + i);
        }

        Console.Write("Enter your word: ");
        string word = Console.ReadLine().ToUpper();

        Console.WriteLine("The word is: {0} and it letters indexes are as follow: ", word);
        for (int i = 0; i < word.Length; i++)
        {
            //take the index of the letter. %65 because the first letter is A and it is with index 0
            int index = word[i] % 65;

            Console.Write(index);
            if (i != word.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
}

