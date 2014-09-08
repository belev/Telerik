namespace _01.DictionaryUsingMongoDb
{
    using MongoDB.Bson;

    public class Word
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Translation { get; set; }
    }
}