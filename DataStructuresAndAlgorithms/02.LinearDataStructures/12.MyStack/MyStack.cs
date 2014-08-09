namespace _12.MyStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyStack<T> : IEnumerable<T>
        where T : IComparable
    {
        private const int DefaultCapacity = 4;

        private T[] elements;

        private int count;
        private int capacity;

        public MyStack(int capacity)
        {
            this.capacity = capacity;
            this.Count = 0;
            this.elements = new T[capacity];
        }

        public MyStack()
            : this(DefaultCapacity)
        {
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public void Push(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Resize(this.Capacity * 2);
            }

            this.elements[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("Cannot pop an element from empty stack!");
            }

            T lastElement = this.elements[this.Count - 1];
            this.Count--;

            return lastElement;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("Cannot peek an element from empty stack!");
            }

            T lastElement = this.elements[this.Count - 1];

            return lastElement;
        }

        public void Clear()
        {
            this.Count = 0;
            this.elements = new T[DefaultCapacity];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public T[] ToArray()
        {
            var arrayToReturn = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                arrayToReturn[i] = this.elements[this.Count - i - 1];
            }

            return arrayToReturn;
        }

        private void Resize(int newCapacity)
        {
            T[] tmpElements = new T[newCapacity];

            for (int i = 0; i < this.Count; i++)
            {
                tmpElements[i] = this.elements[i];
            }

            this.elements = new T[newCapacity];

            for (int i = 0; i < this.Count; i++)
            {
                this.elements[i] = tmpElements[i];
            }

            this.Capacity = newCapacity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var resultAsArray = this.ToArray();

            var resultAsString = string.Join(", ", resultAsArray);

            return resultAsString;
        }
    }
}
