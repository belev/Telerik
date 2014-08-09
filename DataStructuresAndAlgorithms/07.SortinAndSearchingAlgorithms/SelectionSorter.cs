namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int minElemIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[minElemIndex].CompareTo(collection[j]) > 0)
                    {
                        minElemIndex = j;
                    }
                }

                if (minElemIndex != i)
                {
                    T tmp = collection[i];
                    collection[i] = collection[minElemIndex];
                    collection[minElemIndex] = tmp;
                }
            }
        }
    }
}
