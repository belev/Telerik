namespace _01.DictionaryUsingMongoDb.Commands
{
    using System;
    using System.Linq;
    using MongoDB.Driver;
    using _01.DictionaryUsingMongoDb.Utils;

    public class AddNewWordCommand : Command, ICommand
    {
        public AddNewWordCommand(MongoCollection<Word> wordsCollection)
            : base(wordsCollection)
        {

        }

        public override void Execute()
        {
            this.AddNewWord();
        }

        private void AddNewWord()
        {
            var word = UserClientInputUtils.GetUserInputForNewWord();
            var translation = UserClientInputUtils.GetUserInputForNewWordTranslations();

            Word newWord = new Word()
            {
                Name = word,
                Translation = translation
            };

            this.WordsCollection.Insert(newWord);
        }
    }
}