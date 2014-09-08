namespace _01.DictionaryUsingMongoDb.Commands
{
    using System;
    using System.Linq;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using _01.DictionaryUsingMongoDb.Utils;

    public class FindGivenWordTranslationCommand : Command, ICommand
    {
        public FindGivenWordTranslationCommand(MongoCollection<Word> wordsCollection)
            : base(wordsCollection)
        {
        }

        public override void Execute()
        {
            this.FindGivenWordTranslation();
        }

        private void FindGivenWordTranslation()
        {
            var searchedWordName = UserClientInputUtils.GetUserInputSearchedWordName();

            var searchedWord = this.WordsCollection.AsQueryable()
                                   .Where(w => w.Name == searchedWordName)
                                   .FirstOrDefault();

            if (searchedWord != null)
            {
                Console.WriteLine("The word's {0} translation is : {1}", searchedWord.Name, searchedWord.Translation);
            }
            else
            {
                Console.WriteLine("There is no such word in the database. You can try and enter a new word.");
            }
        }
    }
}