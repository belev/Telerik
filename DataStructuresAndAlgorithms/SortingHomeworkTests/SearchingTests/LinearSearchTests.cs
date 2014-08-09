namespace SortingHomeworkTests.SearchingTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingHomework;

    [TestClass]
    public class LinearSearchTests
    {
        [TestMethod]
        public void ExistingNumber()
        {
            var collection = new SortableCollection<int>(new int[] { 5, 19, 99 });

            Assert.IsTrue(collection.LinearSearch(99));
        }

        [TestMethod]
        public void NonExistingNumber()
        {
            var collection = new SortableCollection<int>(new int[] { 5, 19, 99, -555 });

            Assert.IsFalse(collection.LinearSearch(333));
        }
    }
}
