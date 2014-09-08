namespace _01.DictionaryUsingMongoDb.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ConsoleUtils
    {
        public static void PrintHelloMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hello, friend! Welcome to MongoDB dictionary.");
            Console.ResetColor();
        }

        public static void PrintMenuOptions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Please choose on of the following options bellow.");
            Console.WriteLine("1. Add new word and translataion.");
            Console.WriteLine("2. List all words and their translataions.");
            Console.WriteLine("3. Find translation of given word.");
            Console.WriteLine("For exit write: exit\n");
            
            Console.ResetColor();
        }

        public static void PrintGoodbyeMessage()
        {
            Console.WriteLine("Goodbye. : )");
        }

        public static void PrintAllWords(IEnumerable<Word> allWords)
        {
            var result = new StringBuilder();

                foreach (var word in allWords)
                {
                    var currentWordResult = string.Format("Word: {0} -> {1}", word.Name, word.Translation);

                    result.AppendLine(currentWordResult);
                }

                Console.WriteLine(result.ToString());
        }

        public static void PrintEnterMessageForInput()
        {
            Console.Write("Please enter your choice: ");
        }
    }
}