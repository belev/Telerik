using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02ExtensionMethods
{
    //02.Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

    public static class IEnumerableSumMinMaxProductAverage
    {
        public static T Min<T>(this IEnumerable<T> collection)
            where T: IComparable<T>
        {
            if (collection.Count() > 0)
            {
                T minElem = collection.First();

                foreach (T item in collection)
                {
                    if (minElem.CompareTo(item) == 1)
                    {
                        minElem = item;
                    }
                }

                return minElem;
            }
            else
            {
                return default(T);
            }
        }

        public static T Max<T>(this IEnumerable<T> collection)
            where T : IComparable<T>
        {
            if (collection.Count() > 0)
            {
                T maxElem = collection.First();

                foreach (T item in collection)
                {
                    if (maxElem.CompareTo(item) == -1)
                    {
                        maxElem = item;
                    }
                }

                return maxElem;
            }
            else
            {
                return default(T);
            }
        }
        public static T Sum<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() > 0)
            {
                dynamic sum = default(T);

                foreach (T item in collection)
                {
                    sum += (dynamic) item;
                }

                return sum;
            }
            else
            {
                return default(T);
            }
        }
        public static T Product<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() > 0)
            {
                dynamic product = 1;

                foreach (T item in collection)
                {
                    product *= (dynamic) item;
                }

                return product;
            }
            else
            {
                return default(T);
            }
        }
        public static T Average<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() > 0)
            {
                dynamic average = collection.Sum();

                average /= collection.Count();

                return average;
            }
            else
            {
                return default(T);
            }
        }
    }
}
