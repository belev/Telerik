using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Class : Comment
    {
        private string classID;
        private List<Teacher> teachers;
        private List<Student> students;
        public Class(string classID, List<Teacher> teachers, List<Student> students)
        {
            this.ClassID = classID;
            this.teachers = teachers;
            this.students = students;
        }
        public string ClassID
        {
            get
            {
                return this.classID;
            }
            private set
            {
                if (value != string.Empty)
                {
                    this.classID = value;
                }
                else
                {
                    throw new ArgumentException("Invalid class text identifier input!");
                }
            }
        }
        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
            private set
            {
                this.teachers = value;
            }
        }
        public List<Student> Students
        {
            get
            {
                return this.students;
            }
            private set
            {
                this.students = value;
            }
        }
        public void AddStudent(Student student)
        {
            bool isInThisClass = this.students.Count(x => x.NumberInClass == student.NumberInClass) == 0;

            if (!isInThisClass)
            {
                this.students.Add(student);
            }
            else
            {
                Console.WriteLine("There is a student in class with this class number.");
            }
        }
        public void AddTeacher(Teacher teacher)
        {
            bool isInThisClass = this.teachers.Count(x => x.Name == teacher.Name) == 0;

            if (!isInThisClass)
            {
                this.teachers.Add(teacher);
            }
            else
            {
                Console.WriteLine("This teacher teaches this class.");
            }
        }
        public void RemoveStudent(Student student)
        {
            this.students.RemoveAll(x => x.NumberInClass == student.NumberInClass);
        }
        public void RemoveTeacher(Teacher teacher)
        {
            this.teachers.RemoveAll(x => x.Name == teacher.Name);
        }
    }
}
