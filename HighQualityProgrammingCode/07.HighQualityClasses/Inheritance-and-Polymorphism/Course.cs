namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        private string courseName;
        private string teacherName;
        private IList<string> students;

        protected Course(string courseName, string teacherName, IList<string> students)
        {
            this.CourseName = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        protected Course(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course name can not be null or empty.");
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }
            set
            {
                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return new List<string>(this.students);
            }
            set
            {
                if (value != null)
                {
                    this.students = new List<string>();

                    foreach (string student in value)
                    {
                        this.students.Add(student);
                    }
                }
                else
                {
                    this.students = value;
                }
            }
        }

        public void AddStudent(string student)
        {
            if (this.students == null)
            {
                this.students = new List<string>();
            }

            this.students.Add(student);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Name = {0}", this.CourseName);

            if (this.TeacherName != null)
            {
                result.AppendFormat("; Teacher = {0}", this.TeacherName);
            }

            result.AppendFormat("; Students = {0}", this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.students == null || this.students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.students) + " }";
            }
        }
    }
}