namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int left, int right)
        {
            int i = left;
            int j = right;

            int pivotIndex = (left + right) / 2;

            T pivot = collection[pivotIndex];

            while (i <= j)
            {
                // if the elements before the pivot are smaller than the pivot than increase the left index
                while (collection[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                // if the elements after the pivot are greater than the pivot than decrease the right index
                while (collection[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                // if there is element before the pivot which is greater and element after the pivot which is smaller than the pivot
                // exchange them
                if (i <= j)
                {
                    T tmp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (j > left)
            {
                this.QuickSort(collection, left, j);
            }

            if (i < right)
            {
                this.QuickSort(collection, i, right);
            }
        }
    }
}
