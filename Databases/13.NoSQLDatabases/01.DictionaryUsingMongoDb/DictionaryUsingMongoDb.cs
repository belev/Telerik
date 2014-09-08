namespace _01.DictionaryUsingMongoDb
{
    using System;
    using System.Linq;
    using System.Threading;
    using MongoDB.Driver;
    using _01.DictionaryUsingMongoDb.SimpleFactory;
    using _01.DictionaryUsingMongoDb.Utils;

    internal class DictionaryUsingMongoDb
    {
        private const string FirstOptionName = "1";
        private const string SecondOptionName = "2";
        private const string ThirdOptionName = "3";

        private const string ConnectionStringUrl = "mongodb://localhost";
        private const string DatabaseName = "Dictionary";
        private const string WordsCollectionName = "Words";
        private const string ExitCommandToLower = "exit";

        static void Main()
        {
            var client = new MongoClient(ConnectionStringUrl);
            var server = client.GetServer();

            var database = server.GetDatabase(DatabaseName);
            var wordsCollection = database.GetCollection<Word>(WordsCollectionName);

            var commandCreator = new CommandCreator();

            ConsoleUtils.PrintHelloMessage();

            while (true)
            {
                ConsoleUtils.PrintMenuOptions();
                ConsoleUtils.PrintEnterMessageForInput();

                var userInput = Console.ReadLine();

                ProcessUserInputOption(userInput, commandCreator, wordsCollection);
            }
        }

        private static void ProcessUserInputOption(string userInput, CommandCreator commandCreator, MongoCollection<Word> wordsCollection)
        {
            if (userInput.ToLower() == ExitCommandToLower)
            {
                ConsoleUtils.PrintGoodbyeMessage();
                Environment.Exit(0);
            }

            if (UserClientInputUtils.IsUserInputCommandNumberValid(userInput))
            {
                var command = commandCreator.CreateCommand(userInput, wordsCollection);
                command.Execute();
            }
        }
    }
}