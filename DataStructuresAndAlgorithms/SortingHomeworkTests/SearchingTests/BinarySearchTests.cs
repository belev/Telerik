namespace SortingHomeworkTests.SearchingTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingHomework;

    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void ExistingString()
        {
            var collection = new SortableCollection<string>(new string[] { "pesho", "gosho", "stamo" });

            Assert.IsTrue(collection.LinearSearch("gosho"));
        }

        [TestMethod]
        public void NonExistingString()
        {
            var collection = new SortableCollection<string>(new string[] { "pesho", "gosho", "stamo", "gogo", "pepo" });

            Assert.IsFalse(collection.LinearSearch("mariq"));
        }
    }
}
