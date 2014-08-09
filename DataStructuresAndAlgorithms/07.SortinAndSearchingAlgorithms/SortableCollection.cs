namespace SortingHomework
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (item.CompareTo(this.Items[i]) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            if (this.BinarySearchRecursive(item, 0, this.Items.Count) == -1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Fisher–Yates shuffle
        /// </summary>
        public void Shuffle()
        {
            var rndGenerator = new Random();

            for (int i = 0; i < this.Items.Count; i++)
            {
                int j = rndGenerator.Next(i, this.Items.Count);

                T tmp = this.Items[j];
                this.Items[j] = this.Items[i];
                this.Items[i] = tmp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private int BinarySearchRecursive(T item, int minIndex, int maxIndex)
        {
            if (maxIndex < minIndex)
            {
                return -1;
            }

            int midIndex = (minIndex + maxIndex) / 2;

            if (this.Items[midIndex].CompareTo(item) > 0)
            {
                return this.BinarySearchRecursive(item, minIndex, midIndex - 1);
            }
            else if (this.Items[midIndex].CompareTo(item) < 0)
            {
                return this.BinarySearchRecursive(item, midIndex + 1, maxIndex);
            }
            else
            {
                return midIndex;
            }
        }
    }
}
