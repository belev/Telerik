using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public string Lab { get; set; }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {
        }

        public LocalCourse(string courseName)
            : this(courseName, null, new List<string>(), null)
        {
        }

        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>(), null)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { ");
            result.Append(base.ToString());

            if (this.Lab != null)
            {
                result.AppendFormat("; Lab = {0}", this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}