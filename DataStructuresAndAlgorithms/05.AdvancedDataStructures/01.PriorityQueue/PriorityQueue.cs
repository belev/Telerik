namespace _01.PriorityQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// min heap implementation
    /// starts from smallest elements and go to larger and larger
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private List<T> elements;

        public PriorityQueue()
        {
            this.elements = new List<T>();
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
            this.elements.Add(element);

            // shift-up
            int lastElementAddedIndex = this.Count - 1;

            if (this.GetParentIndex(lastElementAddedIndex) > 0)
            {
                this.SiftUp(lastElementAddedIndex);
            }
        }

        public T Dequeue()
        {
            const int ParentStartIndex = 0;

            if (this.Count == 0)
            {
                throw new ArgumentException("Cannot dequeue an element from an empty priority queue!");
            }

            T result = this.elements[0];

            this.elements[0] = this.elements[this.Count - 1];
            this.elements.RemoveAt(this.Count - 1);

            this.SiftDown(ParentStartIndex);

            return result;
        }

        public T Peek()
        {
            return this.elements[0];
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var elem in this.elements)
            {
                yield return elem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void SiftUp(int checkIndex)
        {
            int parentIndex = this.GetParentIndex(checkIndex);
            while (true)
            {
                if (this.elements[checkIndex].CompareTo(this.elements[parentIndex]) < 0)
                {
                    T tmp = this.elements[parentIndex];
                    this.elements[parentIndex] = this.elements[checkIndex];
                    this.elements[checkIndex] = tmp;
                }

                if (!this.HasParent(parentIndex))
                {
                    break;
                }

                checkIndex = parentIndex;
                parentIndex = this.GetParentIndex(parentIndex);
            }
        }

        private void SiftDown(int parentIndex)
        {
            int leftChildIndex = this.GetLeftChildIndex(parentIndex);
            int rightChildIndex = this.GetRightChildIndex(parentIndex);

            while (true)
            {
                if (leftChildIndex > this.Count - 1)
                {
                    return;
                }

                int childIndex = leftChildIndex;

                if (rightChildIndex < this.Count && this.elements[leftChildIndex].CompareTo(this.elements[rightChildIndex]) > 0)
                {
                    childIndex = rightChildIndex;
                }

                if (this.elements[parentIndex].CompareTo(this.elements[childIndex]) < 0)
                {
                    return;
                }

                T tmp = this.elements[parentIndex];
                this.elements[parentIndex] = this.elements[childIndex];
                this.elements[childIndex] = tmp;

                leftChildIndex = this.GetLeftChildIndex(childIndex);
                rightChildIndex = this.GetRightChildIndex(childIndex);
                parentIndex = childIndex;
            }
        }

        private bool HasParent(int childIndex)
        {
            return childIndex > 0;
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) >> 1;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return (parentIndex << 1) + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return (parentIndex << 1) + 2;
        }
    }
}
