namespace _03.BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, V>
    {
        private MultiDictionary<K1, V> byFirstKey;
        private MultiDictionary<K2, V> bySecondKey;
        private MultiDictionary<Tuple<K1, K2>, V> byBothKeys;
        public BiDictionary()
        {
            this.byFirstKey = new MultiDictionary<K1, V>(true);
            this.bySecondKey = new MultiDictionary<K2, V>(true);
            this.byBothKeys = new MultiDictionary<Tuple<K1, K2>, V>(true);
        }

        public int Count
        {
            get
            {
                return this.byBothKeys.KeyValuePairs.Count;
            }
        }

        public void Add(K1 key1, K2 key2, V value)
        {
            this.byFirstKey.Add(key1, value);
            this.bySecondKey.Add(key2, value);

            var bothKeysAsTuple = new Tuple<K1, K2>(key1, key2);

            this.byBothKeys.Add(bothKeysAsTuple, value);
        }

        public ICollection<V> FindByFirstKey(K1 key1)
        {
            return this.byFirstKey[key1].ToArray();
        }

        public ICollection<V> FindBySecondKey(K2 key2)
        {
            return this.bySecondKey[key2].ToArray();
        }

        public ICollection<V> FindByBothKeys(K1 key1, K2 key2)
        {
            var searchedKeysAsTuple = new Tuple<K1, K2>(key1, key2);

            return this.byBothKeys[searchedKeysAsTuple].ToArray();
        }
    }
}
