namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sorted = this.MergeSort(collection);

            collection.Clear();

            foreach (var elem in sorted)
            {
                collection.Add(elem);
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();
            IList<T> result = new List<T>();

            int middle = collection.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = middle; i < collection.Count; i++)
            {
                right.Add(collection[i]);
            }

            left = this.MergeSort(left);
            right = this.MergeSort(right);

            if (left[left.Count - 1].CompareTo(right[0]) < 0)
            {
                foreach (var elem in left)
                {
                    result.Add(elem);
                }

                foreach (var elem in right)
                {
                    result.Add(elem);
                }

                return result;
            }

            result = this.Merge(left, right);

            return result;
        }

        private IList<T> Merge(IList<T> leftPart, IList<T> rightPart)
        {
            IList<T> result = new List<T>(leftPart.Count + rightPart.Count);

            int leftIncrease = 0;
            int rightIncrease = 0;

            while (leftIncrease < leftPart.Count && rightIncrease < rightPart.Count)
            {
                if (leftPart[leftIncrease].CompareTo(rightPart[rightIncrease]) <= 0)
                {
                    result.Add(leftPart[leftIncrease]);
                    leftIncrease++;
                }
                else
                {
                    result.Add(rightPart[rightIncrease]);
                    rightIncrease++;
                }
            }

            if (leftIncrease < leftPart.Count)
            {
                for (int i = leftIncrease; i < leftPart.Count; i++)
                {
                    result.Add(leftPart[leftIncrease]);
                }
            }

            if (rightIncrease < rightPart.Count)
            {
                for (int i = rightIncrease; i < rightPart.Count; i++)
                {
                    result.Add(rightPart[rightIncrease]);
                }
            }

            return result;
        }
    }
}
