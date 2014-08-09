namespace _11.MyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyLinkedList<T> : IEnumerable<T>
        where T : IComparable
    {
        private ListItem<T> firstElement;

        public MyLinkedList()
        {
            this.firstElement = null;
            this.Count = 0;
        }

        public T FirstElement
        {
            get
            {
                return this.firstElement.Value;
            }
        }

        public int Count { get; private set; }

        public void Add(int index, T value)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException(string.Format("Index out of range! Index: {0}", index));
            }

            ListItem<T> curElem = this.firstElement;

            if (curElem == null || index == 0)
            {
                this.firstElement = new ListItem<T>(value, curElem);
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    curElem = curElem.NextItem;
                }

                curElem.NextItem = new ListItem<T>(value, curElem.NextItem);
            }

            this.Count++;
        }

        public void AddFirst(T value)
        {
            this.Add(0, value);
        }

        public void AddLast(T value)
        {
            this.Add(this.Count, value);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(string.Format("Index out of range! Index: {0}", index));
            }

            ListItem<T> curElem = this.firstElement;

            if (index == 0)
            {
                this.firstElement = curElem.NextItem;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    curElem = curElem.NextItem;
                }

                curElem.NextItem = curElem.NextItem.NextItem;
            }

            this.Count--;
        }

        public void RemoveFirst()
        {
            this.RemoveAt(0);
        }

        public void RemoveLast()
        {
            this.RemoveAt(this.Count - 1);
        }

        public void Remove(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value to remove cannot be null!");
            }

            if (this.Count == 0)
            {
                throw new ArgumentException("Cannot remove element from empty list!");
            }

            ListItem<T> curElem = this.firstElement;

            if (curElem.Value.CompareTo(value) == 0)
            {
                this.firstElement = curElem.NextItem;
            }
            else
            {
                while (curElem.NextItem != null)
                {
                    if (curElem.NextItem.Value.CompareTo(value) == 0)
                    {
                        curElem.NextItem = curElem.NextItem.NextItem;
                        break;
                    }

                    curElem = curElem.NextItem;
                }
            }
            this.Count--;
        }

        public void Clear()
        {
            this.firstElement = null;
            this.Count = 0;
        }


        public IEnumerator<T> GetEnumerator()
        {
            ListItem<T> curElem = this.firstElement;
            yield return curElem.Value;

            while (curElem.NextItem != null)
            {
                curElem = curElem.NextItem;

                yield return curElem.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
