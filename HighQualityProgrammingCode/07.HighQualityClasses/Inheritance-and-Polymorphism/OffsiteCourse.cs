using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        public string Town { get; set; }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {
        }

        public OffsiteCourse(string courseName)
            : this(courseName, null, null, null)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>(), null)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { ");
            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.AppendFormat("; Town = {0}", this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
