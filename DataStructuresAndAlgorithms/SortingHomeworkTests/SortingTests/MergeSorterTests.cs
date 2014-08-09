namespace SortingHomeworkTests.SortingTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingHomework;

    [TestClass]
    public class MergeSorterTests
    {
        [TestMethod]
        public void NegativeNumbersMergeSort()
        {
            var collection = new SortableCollection<int>(new[] { -5, -16, -1, -29 });
            collection.Sort(new MergeSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i].CompareTo(collection.Items[i + 1]) <= 0);
            }
        }

        [TestMethod]
        public void ReversedNumbersMergeSort()
        {
            var collection = new SortableCollection<int>(new[] { 9, 7, 5, 3 });
            collection.Sort(new MergeSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i].CompareTo(collection.Items[i + 1]) <= 0);
            }
        }

        [TestMethod]
        public void SortedNumbersMergeSort()
        {
            var collection = new SortableCollection<int>(new[] { 1, 2, 3, 4, 5 });
            collection.Sort(new MergeSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i].CompareTo(collection.Items[i + 1]) <= 0);
            }
        }
    }
}
