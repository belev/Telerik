namespace _01.DictionaryUsingMongoDb.Utils
{
    using System;
    using System.Linq;

    public class UserClientInputUtils
    {
        public static string GetUserInputSearchedWordName()
        {
            Console.Write("Please enter which word's translation do you search: ");
            var searchedWordTranslationName = Console.ReadLine();
            return searchedWordTranslationName;
        }

        public static string GetUserInputForNewWord()
        {
            Console.Write("Please enter the new word: ");
            var word = Console.ReadLine();
            return word;
        }

        public static string GetUserInputForNewWordTranslations()
        {
            Console.Write("Please enter the word translation: ");
            var translation = Console.ReadLine();
            return translation;
        }

        public static bool IsUserInputCommandNumberValid(string userInput)
        {
            return (userInput == "1" || userInput == "2" || userInput == "3");
        }
    }
}
