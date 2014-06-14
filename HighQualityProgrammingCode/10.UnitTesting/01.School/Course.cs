namespace _01.School
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Course
    {
        public const int MaxStudentsCount = 29;

        private ICollection<Student> students;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
        }

        public Course(string name, ICollection<Student> students)
            : this(name)
        {
            this.Students = students;
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Students in course can not be null.");
                }

                if (value.Count >= MaxStudentsCount + 1)
                {
                    throw new ArgumentOutOfRangeException("Course can not have more than 30 students.");
                }

                this.students = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name can not be null or empty.");
                }

                this.name = value;
            }
        }

        public int StudentsCount()
        {
            return this.Students.Count;
        }

        public void AddStudent(Student student)
        {
            if (this.StudentsCount() >= MaxStudentsCount)
            {
                throw new ArgumentOutOfRangeException("Can not add new student to course because the course is full.");
            }

            if (this.IsStudentJoinedCourse(student))
            {
                throw new ArgumentException("Student can not join the same course twice.");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.IsStudentJoinedCourse(student))
            {
                throw new ArgumentException("There is no such student to remove from this course.");
            }

            var index = 0;
            foreach (var st in this.Students)
            {
                if (st.Id == student.Id && st.Name == student.Name)
                {
                    (this.students as List<Student>).RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        private bool IsStudentJoinedCourse(Student student)
        {
            foreach (var st in this.students)
            {
                if (st.Id == student.Id && st.Name == student.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
