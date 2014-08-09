namespace _05.MyHashSet
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using _04.HashTable;

    public class MyHashSet<T>
    {
        private HashTable<T, int> elements;

        public MyHashSet()
        {
            this.elements = new HashTable<T, int>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(T element)
        {
            if (this.Contains(element))
            {
                throw new ArgumentException("A key with this value already exist.");
            }

            this.elements.Add(element, -1);
        }

        public void Remove(T element)
        {
            this.elements.Remove(element);
        }

        // no use of method Find in hash set
        // instead of find we can use contains
        public bool Contains(T element)
        {
            return this.elements.ContainsKey(element);
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public IEnumerable<T> Elements()
        {
            return this.elements.Keys;
        }

        /// <summary>
        /// if we use union on one hash set it means that we want to change it
        /// i understand the task that way so the method Union didnt return value
        /// but changes the set which calls the method
        /// </summary>
        /// <param name="anotherSet"></param>
        public void Union(MyHashSet<T> anotherSet)
        {
            var anotherSetElements = anotherSet.Elements();

            foreach (var element in anotherSetElements)
            {
                if (!this.Contains(element))
                {
                    this.Add(element);
                }
            }
        }

        /// <summary>
        /// if we use intersect on one hash set it means that we want to change it
        /// i understand the task that way so the method Intersect didnt return value
        /// but changes the set which calls the method
        /// </summary>
        /// <param name="anotherSet"></param>
        public void Intersect(MyHashSet<T> anotherSet)
        {
            var anotherSetElements = anotherSet.Elements();

            foreach (var element in anotherSetElements)
            {
                if (this.Contains(element))
                {
                    this.elements.Remove(element);
                }
            }
        }
    }
}
