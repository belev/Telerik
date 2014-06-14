namespace _01.SchoolTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using _01.School;

    [TestClass]
    public class SchoolTest
    {
        private IList<Course> courses;
        private School school;

        [TestInitialize]
        public void InitializeSchool()
        {
            this.courses = new List<Course>();
            this.courses.Add(new Course("HQC"));
            this.courses.Add(new Course("DSA"));
            this.courses.Add(new Course("JS UI&DOM"));

            this.school = new School(this.courses);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExistingCourseTest()
        {
            var course = new Course("HQC");

            this.school.AddCourse(course);
        }

        [TestMethod]
        public void AddCourseTest()
        {
            var course = new Course("JS Fundamentals");

            this.courses.Add(course);

            this.school.AddCourse(course);

            var areEqualResult = this.AreCoursesCollectionsEqual(this.courses, this.school.Courses);

            Assert.AreEqual(true, areEqualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingCourseTest()
        {
            var course = new Course("C#");

            this.school.RemoveCourse(course);
        }

        [TestMethod]
        public void RemoveExistingCourseTest()
        {
            var course = this.courses[0];

            this.courses.RemoveAt(0);
            this.school.RemoveCourse(course);

            var resultAfterRemove = AreCoursesCollectionsEqual(this.courses, this.school.Courses);

            Assert.AreEqual(true, resultAfterRemove);
        }

        private bool AreCoursesCollectionsEqual(IList<Course> expected, IList<Course> actual)
        {
            if (expected.Count != actual.Count)
            {
                return false;
            }

            foreach (var course in expected)
            {
                if (!actual.Contains(course))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
