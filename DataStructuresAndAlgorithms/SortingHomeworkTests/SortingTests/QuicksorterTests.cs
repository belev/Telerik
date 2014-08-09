namespace SortingHomeworkTests.SortingTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingHomework;

    [TestClass]
    public class QuicksorterTests
    {
        [TestMethod]
        public void NegativeNumbersQuickSort()
        {
            var collection = new SortableCollection<int>(new[] { -5, -16, -1, -29 });
            collection.Sort(new Quicksorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i].CompareTo(collection.Items[i + 1]) <= 0);
            }
        }

        [TestMethod]
        public void ReversedNumbersQuickSort()
        {
            var collection = new SortableCollection<int>(new[] { 9, 7, 5, 3 });
            collection.Sort(new Quicksorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i].CompareTo(collection.Items[i + 1]) <= 0);
            }
        }

        [TestMethod]
        public void SortedNumbersQuickSort()
        {
            var collection = new SortableCollection<int>(new[] { 1, 2, 3, 4, 5 });
            collection.Sort(new Quicksorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i].CompareTo(collection.Items[i + 1]) <= 0);
            }
        }
    }
}
