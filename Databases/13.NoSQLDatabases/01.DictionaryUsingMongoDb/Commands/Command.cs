namespace _01.DictionaryUsingMongoDb.Commands
{
    using System;
    using MongoDB.Driver;

    public abstract class Command : ICommand
    {
        private MongoCollection<Word> wordsCollection;

        protected Command(MongoCollection<Word> wordsCollection)
        {
            this.WordsCollection = wordsCollection;
        }

        public MongoCollection<Word> WordsCollection
        {
            get
            {
                return this.wordsCollection;
            }
            private set
            {
                this.wordsCollection = value;
            }
        }

        public abstract void Execute();
    }
}
