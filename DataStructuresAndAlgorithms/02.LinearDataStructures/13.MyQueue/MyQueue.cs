namespace _13.MyQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using _11.MyLinkedList;

    public class MyQueue<T> : IEnumerable<T>
        where T : IComparable
    {
        // using MyLinkedList class from task 11
        private MyLinkedList<T> elements;

        public MyQueue()
        {
            this.elements = new MyLinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Enqueue(T element)
        {
            this.elements.AddLast(element);
        }

        /// <summary>
        /// No need to check if there are elements because if there arent any there will be an exception from MyLinkedList class
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            T firstElement = this.elements.FirstElement;

            this.elements.RemoveFirst();

            return firstElement;
        }

        public T Peek()
        {
            return this.elements.FirstElement;
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(", ", this.elements);
        }
    }
}
