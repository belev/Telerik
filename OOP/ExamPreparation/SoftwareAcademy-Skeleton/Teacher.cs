namespace SoftwareAcademy
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    public class Teacher : ITeacher
    {
        private string name;
        private IList<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.Courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == string.Empty || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Teacher's name cannot be null, empty or whitespace!");
                }

                this.name = value;
            }
        }

        public IList<ICourse> Courses 
        {
            get
            {
                return this.courses;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Teacher's courses cannot be null!");
                }

                this.courses = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            if (courses == null)
            {
                throw new ArgumentNullException("Course to be added cannot be null!");
            }

            this.Courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            string teacherType = this.GetType().Name;
            var coursesNames = this.Courses.Count == 0 ? null : string.Join(", ", this.Courses.Select(c => c.Name));

            result.Append(string.Format("{0}: Name={1}", teacherType, this.Name));

            if (coursesNames != null)
            {
                result.Append(string.Format("; Courses=[{0}]", coursesNames));
            }

            // for checking answers
            // OutputTextOverwriter.OverwriteTextOutput(result);

            return result.ToString();
        }
    }
}
