namespace _02.DictionaryUsingRedisDb
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using ServiceStack.Redis;

    public class WordsDictionary : IEnumerable<Word>
    {
        private RedisClient client;
        private string dictionaryName;

        public WordsDictionary(RedisClient client, string dictionaryName)
        {
            this.client = client;
            this.dictionaryName = dictionaryName;
        }

        public void Add(string wordName, string translation)
        {
            this.client.HSet(this.dictionaryName, wordName.ConvertStringToByteArr(), translation.ConvertStringToByteArr());
        }

        public void Remove(string wordName)
        {
            if (ContainsWord(wordName))
            {
                this.client.HDel(this.dictionaryName, wordName.ConvertStringToByteArr());
            }
            else
            {
                throw new ArgumentException("The key does not exist.");
            }
        }

        public bool ContainsWord(string wordName)
        {
            long containsValue = this.client.HExists(this.dictionaryName, wordName.ConvertStringToByteArr());

            return containsValue == 1;
        }

        public int Count 
        {
            get
            {
                return this.client.HGetAll(this.dictionaryName).Length;
            }
        }

        public string this[string wordName]
        {
            get
            {
                byte[] valueToReturn = this.client.HGet(this.dictionaryName, wordName.ConvertStringToByteArr());

                return valueToReturn.ConvertByteArrToString();
            }
            set
            {
                this.client.HSet(this.dictionaryName, wordName.ConvertStringToByteArr(), value.ConvertStringToByteArr());
            }
        }

        public IEnumerator<Word> GetEnumerator()
        {
            byte[][] allValues = this.client.HGetAll(this.dictionaryName);

            for (int i = 0; i < allValues.Length; i += 2)
            {
                if (i >= allValues.Length)
                {
                    break;
                }
                yield return new Word(allValues[i], allValues[i + 1]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
