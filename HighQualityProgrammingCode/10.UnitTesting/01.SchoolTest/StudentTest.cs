namespace _01.SchoolTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using _01.School;

    [TestClass]
    public class StudentTest
    {
        private Student student;
        private const string StudentName = "Pesho";
        private const int StudentId = 10001;

        [TestInitialize]
        public void InitializeStudent()
        {
            this.student = new Student(StudentName, StudentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentsConstructorNameNullTest()
        {
            string studentName = null;

            var student = new Student(studentName, 15000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentsConstructorNameEmptyTest()
        {
            var studentName = string.Empty;

            var student = new Student(studentName, 15000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentsConstructorSmallerIdTest()
        {
            var studentId = 5;

            var student = new Student("Pesho", studentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentsConstructorGreaterIdTest()
        {
            var studentId = 100000;

            var student = new Student("Pesho", studentId);
        }

        [TestMethod]
        public void GetterNameTest()
        {
            Assert.AreEqual(StudentName, this.student.Name);
        }

        [TestMethod]
        public void GetterIdTest()
        {
            Assert.AreEqual(StudentId, this.student.Id);
        }
    }
}
