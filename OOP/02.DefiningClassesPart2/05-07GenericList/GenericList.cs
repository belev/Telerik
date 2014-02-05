using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _05_07GenericList
{
    //05.Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.


    /// <summary>
    /// The type T must be a type of IComparable, so that the initialization of the method FindElementIndex is possible
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericList<T>
        where T : IComparable
    {
        private T[] elements;
        private int count;
        private int capacity;

        public GenericList()
        {
            this.count = 0;
            this.capacity = 8;
            this.elements = new T[8];
        }

        public GenericList(int capacity)
        {
            this.count = 0;
            Resize(capacity);
        }

        public int Count
        {
            get { return this.count; }
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public void Add(T element)
        {
            if (this.count == this.capacity)
            {
                Resize(this.capacity * 2);
            }

            this.elements[this.count] = element;
            this.count++;
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < this.count)
                {
                    return this.elements[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < this.count)
                {
                    this.elements[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < this.count)
            {
                for (int i = index; i < this.count - 1; i++)
                {
                    this.elements[i] = this.elements[i + 1];
                }
                this.count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void InsertAt(int index, T element)
        {
            if (index >= 0 && index < this.count)
            {
                if (this.count == this.capacity)
                {
                    Resize(this.capacity * 2);
                }

                //set the element on position index to be equal to element
                T tmpElement = this.elements[index];
                this.elements[index] = element;


                for (int i = index + 1; i < this.count; i++)
                {
                    //swap the elements
                    //tmpElement is equal to elements[i]
                    Swap(ref this.elements[i], ref tmpElement);
                }

                //in the end tmpElement is the last element in this.elements
                //set it at position count
                this.elements[this.count] = tmpElement;

                //increase count
                this.count++;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Clear()
        {
            this.count = 0;
        }

        public int FindElementIndex(T element)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(element) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.count; i++)
            {
                result.Append(this.elements[i]);

                if (i != this.count - 1)
                {
                    result.Append(" ");
                }
            }

            return result.ToString();
        }

        //07.Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. You may need to add a generic constraints for the type T.

        public T Min()
        {
            if (this.count > 0)
            {
                T min = this.elements[0];

                for (int i = 1; i < this.count; i++)
                {
                    if (min.CompareTo(this.elements[i]) > 0)
                    {
                        min = this.elements[i];
                    }
                }

                return min;
            }
            else
            {
                throw new ArgumentException("Can't find minimal element! There aren't any elements in the GenericList!");
            }
        }

        public T Max()
        {
            if (this.count > 0)
            {
                T max = this.elements[0];

                for (int i = 1; i < this.count; i++)
                {
                    if (max.CompareTo(this.elements[i]) < 0)
                    {
                        max = this.elements[i];
                    }
                }

                return max;
            }
            else
            {
                throw new ArgumentException("Can't find maximal element! There aren't any elements in the GenericList!");
            }
        }

        private void Swap(ref T x, ref T y)
        {
            T tmp = x;
            x = y;
            y = tmp;
        }

        //06.Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.

        private void Resize(int newCapacity)
        {
            T[] tmpElements = new T[Capacity];
            //put all elements into tmpElements
            for (int i = 0; i < Count; i++)
            {
                tmpElements[i] = this.elements[i];
            }

            //create new array with 2 * capacity available elements
            this.elements = new T[newCapacity];

            //transfer all elements to the new bigger array
            for (int i = 0; i < Capacity; ++i)
            {
                this.elements[i] = tmpElements[i];
            }

            //change capacity
            this.capacity = newCapacity;
        }
    }
}
