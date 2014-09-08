namespace _02.DictionaryUsingRedisDb
{
    public class Word
    {
        private string name;
        private string translation;

        public Word(byte[] name, byte[] translation)
        {
            this.Name = name.ConvertByteArrToString();
            this.Translation = translation.ConvertByteArrToString();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                this.name = value;
            }
        }

        public string Translation
        {
            get
            {
                return translation;
            }
            private set
            {
                this.translation = value;
            }
        }
    }
}
