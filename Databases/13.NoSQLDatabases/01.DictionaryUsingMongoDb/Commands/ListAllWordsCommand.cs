namespace _01.DictionaryUsingMongoDb.Commands
{
    using System;
    using System.Linq;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System.Text;
    using _01.DictionaryUsingMongoDb.Utils;

    public class ListAllWordsCommand : Command, ICommand
    {
        public ListAllWordsCommand(MongoCollection<Word> wordsCollection)
            : base(wordsCollection)
        {

        }

        public override void Execute()
        {
            this.ListAllWords();
        }

        private void ListAllWords()
        {
            var allWords = this.WordsCollection.AsQueryable().ToList();

            if (allWords.Any())
            {
                ConsoleUtils.PrintAllWords(allWords);
            }
            else
            {
                Console.WriteLine("There are no words in the dictionary. Add some to list them.\n");
            }
        }
    }
}