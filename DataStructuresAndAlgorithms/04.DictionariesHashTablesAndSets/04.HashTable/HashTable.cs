namespace _04.HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int InitialCapacity = 16;

        private const double GrowthFactor = 0.75;

        private LinkedList<KeyValuePair<K, T>>[] data;

        /// <summary>
        /// use uint instead of int so that negative numbers cannot be given as a capacity
        /// </summary>
        /// <param name="capacity"></param>
        public HashTable(uint capacity)
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[capacity];
            this.Count = 0;
            this.AllElementsCount = 0;
            this.Length = (int) capacity;
        }

        public HashTable()
            : this(InitialCapacity)
        {
        }

        /// <summary>
        /// count the number of occupied cells in data
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///  count all elements in data
        /// </summary>
        public int AllElementsCount { get; private set; }

        public int Length { get; private set; }

        public List<K> Keys
        {
            get
            {
                var listOfKeys = new HashSet<K>();

                for (int i = 0; i < this.Length; i++)
                {
                    if (this.data[i] == null)
                    {
                        continue;
                    }

                    foreach (var pair in this.data[i])
                    {
                        listOfKeys.Add(pair.Key);
                    }
                }
                return listOfKeys.ToList();
            }
        }

        public void Add(K key, T value)
        {
            var pairToAdd = new KeyValuePair<K, T>(key, value);

            int index = this.GetIndex(key);

            if (this.data[index] != null)
            {
                // check if there is a linkedList at this position
                // and only when its count is equal to 0
                // then increase the occupied elements in data
                if (this.data[index].Count == 0)
                {
                    this.Count++;
                }
            }
            else
            {
                // if there is no linkedList at this position
                // create a new one, increase occupied elements in data
                this.data[index] = new LinkedList<KeyValuePair<K, T>>();

                this.Count++;
            }

            // the chech for resize is here because if there are exactly this.data.Length * GrowthFactor occupied cells
            // and if we do the check in the beginning of the method
            // than our hash table wont resize, but it should have because there is a chance after adding the element
            // that this.Count can be greater than this.data.Length * GrowthFactor
            // so the check for count is done after we find out if we add new element, and it is added on a non occupied cell
            if (this.Count > this.Length * GrowthFactor)
            {
                this.Resize(2 * this.Length);
            }

            this.data[index].AddLast(pairToAdd);

            this.AllElementsCount++;
        }

        /// <summary>
        /// on given key the method finds the first element (if it exist)
        /// on the position which satisfies the given index
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Find(K key)
        {
            int index = this.GetIndex(key);

            // if there is no linkedList(no elements on that position)
            // throw an exception and no else after the if statement because if the exception is thrown we wont
            // execute the foreach loop either way
            if (this.data[index] == null)
            {
                throw new ArgumentException("There is no such element with this key.");
            }

            foreach (var pair in this.data[index])
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }

            // If we havent return value, it means that there is no such element and again throw an exception
            throw new ArgumentException("There is no such element with this key.");
        }

        /// <summary>
        /// on given key the method removes the first element (if it exist)
        /// on the position which satisfies the given index</summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            int index = this.GetIndex(key);

            // if there is no linkedList(no elements on that position)
            // throw an exception and no else after the if statement because if the exception is thrown we wont
            // execute the foreach loop either way
            if (this.data[index] == null)
            {
                throw new ArgumentException("There is no such element with this key.");
            }

            foreach (var pair in this.data[index])
            {
                if (pair.Key.Equals(key))
                {
                    this.data[index].Remove(pair);
                    this.AllElementsCount--;

                    // if there are no elements at this index
                    // decrease count, because it is not an occupied cell anymore
                    // and there are no elements in it
                    if (this.data[index].Count == 0)
                    {
                        this.Count--;
                    }
                    return;
                }
            }

            throw new ArgumentException("There is no such element with this key.");
        }

        public bool ContainsKey(K key)
        {
            int index = this.GetIndex(key);

            if (this.data[index] == null)
            {
                return false;
            }

            return this.data[index].Where(p => p.Key.Equals(key)).Count() != 0;
        }

        public void Clear()
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[this.Length];
            this.Count = 0;
            this.AllElementsCount = 0;
        }

        public T this[K key]
        {
            get
            {
                T valueToReturn = this.Find(key);

                return valueToReturn;
            }
            set
            {
                this.Add(key, value);
            }
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this.data[i] == null)
                {
                    continue;
                }

                foreach (var pair in this.data[i])
                {
                    yield return pair;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize(int newCapacity)
        {
            var dataCopy = new LinkedList<KeyValuePair<K, T>>[newCapacity];

            int oldCapacity = this.data.Length;

            for (int i = 0; i < oldCapacity; i++)
            {
                dataCopy[i] = this.data[i];
            }

            this.data = new LinkedList<KeyValuePair<K, T>>[newCapacity];
            this.Length = newCapacity;

            for (int i = 0; i < oldCapacity; i++)
            {
                this.data[i] = dataCopy[i];
            }
        }

        private int GetIndex(K key)
        {
            int index = Math.Abs(key.GetHashCode()) % this.data.Length;
            return index;
        }
    }
}
