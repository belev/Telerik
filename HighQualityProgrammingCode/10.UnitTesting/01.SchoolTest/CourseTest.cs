namespace _01.SchoolTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using _01.School;

    [TestClass]
    public class CourseTest
    {
        private string courseName = "HQC";
        private ICollection<Student> students;
        private Course course;

        [TestInitialize]
        public void InitializeStudent()
        {
            this.students = new List<Student>();

            for (int i = 1; i <= 6; i++)
            {
                string studentName = "test student " + i;
                int studentId = Student.MinIdValue + i;
                this.students.Add(new Student(studentName, studentId));
            }


            this.course = new Course(this.courseName, students);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseConstructorNameNullTest()
        {
            string courseName = null;

            var course = new Course(courseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseConstructorNameEmptyTest()
        {
            string courseName = string.Empty;

            var course = new Course(courseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseConstructorStudentsNullTest()
        {
            string courseName = "C#";
            ICollection<Student> courseStudents = null;

            var course = new Course(courseName, courseStudents);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CourseConstructorStudentsMaxCountTest()
        {
            string courseName = "C#";
            ICollection<Student> courseStudents = new List<Student>();

            for (int i = 0; i < Course.MaxStudentsCount + 1; i++)
            {
                string studentName = "test student " + i;
                int studentId = Student.MinIdValue + i;
                courseStudents.Add(new Student(studentName, studentId));
            }

            var course = new Course(courseName, courseStudents);
        }

        [TestMethod]
        public void CourseGetterNameTest()
        {
            var courseName = "HQC";

            var course = new Course(courseName);

            Assert.AreEqual(courseName, course.Name);
        }

        [TestMethod]
        public void CourseStudentsCountTest()
        {
            var courseName = "HQC";
            var studentsCount = 6;
            ICollection<Student> students = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                string studentName = "test student " + i;
                int studentId = Student.MinIdValue + i;
                students.Add(new Student(studentName, studentId));
            }


            var course = new Course(courseName, students);
            Assert.AreEqual(studentsCount, course.StudentsCount());
        }

        [TestMethod]
        public void CourseGetterStudentsTest()
        {
            var courseName = "HQC";
            ICollection<Student> students = new List<Student>();

            for (int i = 0; i < 5; i++)
            {
                string studentName = "test student " + i;
                int studentId = Student.MinIdValue + i;
                students.Add(new Student(studentName, studentId));
            }


            var course = new Course(courseName, students);
            var studentsEqualResult = this.AreStudentCollectionsEqual(students, course.Students);

            Assert.AreEqual(true, studentsEqualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExistingStudentAddTest()
        {
            var existingStudentName = "test student 1";
            var existingStudentId = Student.MinIdValue + 1;

            var student = new Student(existingStudentName, existingStudentId);

            this.course.AddStudent(student);
        }

        /// <summary>
        /// Before run test, we initialize 28 students in course
        /// so we can add one student but after the second one added there will be an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddMoreThanMaxAvailableStudentsInCourseTest()
        {
            for (int i = this.course.StudentsCount() + 1; i <= Course.MaxStudentsCount + 1; i++)
            {
                string studentName = "test student " + i;
                int studentId = Student.MinIdValue + i;
                this.course.AddStudent(new Student(studentName, studentId));
            }
        }

        [TestMethod]
        public void AddStudentToCourseTest()
        {
            // get the students in course before adding a student
            var studentsInCourse = this.course.Students;

            var studentName = "test student " + this.course.StudentsCount() + 1;
            var studentId = Student.MinIdValue + this.course.StudentsCount() + 1;

            var student = new Student(studentName, studentId);

            // add the student in the course and add it to the students in course before adding new student
            this.course.AddStudent(student);
            studentsInCourse.Add(student);

            var areStudentCollectionsEqual = this.AreStudentCollectionsEqual(studentsInCourse, this.course.Students);

            Assert.AreEqual(true, areStudentCollectionsEqual);
        }

        [TestMethod]
        public void RemoveStudentFromCourseTest()
        {
            var studentName = "test student " + 1;
            var studentId = Student.MinIdValue + 1;

            var student = new Student(studentName, studentId);

            var expectedStudentsCounts = this.course.StudentsCount() - 1;

            this.course.RemoveStudent(student);

            Assert.AreEqual(expectedStudentsCounts, this.course.StudentsCount());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingStudentFromCourseTest()
        {
            var studentName = "test student";
            var studentId = 15000;

            var student = new Student(studentName, studentId);

            this.course.RemoveStudent(student);
        }


        private bool AreStudentCollectionsEqual(ICollection<Student> expected, ICollection<Student> actual)
        {
            if (expected.Count != actual.Count)
            {
                return false;
            }

            foreach (var student in expected)
            {
                if (!actual.Contains(student))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
