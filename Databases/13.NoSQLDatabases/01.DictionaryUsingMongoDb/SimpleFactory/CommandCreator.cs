namespace _01.DictionaryUsingMongoDb.SimpleFactory
{
    using System;
    using System.Linq;
    using MongoDB.Driver;
    using _01.DictionaryUsingMongoDb.Commands;

    public class CommandCreator
    {
        public const string AddNewWordCommand = "1";
        public const string ListAllWordsCommand = "2";
        public const string FindGivenWordTranslationCommand = "3";

        public ICommand CreateCommand(string userInput, MongoCollection<Word> wordsCollection)
        {
            if (userInput == AddNewWordCommand)
            {
                return new AddNewWordCommand(wordsCollection);
            }
            else if (userInput == FindGivenWordTranslationCommand)
            {
                return new FindGivenWordTranslationCommand(wordsCollection);
            }
            else if (userInput == ListAllWordsCommand)
            {
                return new ListAllWordsCommand(wordsCollection);
            }
            else
            {
                throw new ArgumentException("Invalid command name!");
            }
        }
    }
}