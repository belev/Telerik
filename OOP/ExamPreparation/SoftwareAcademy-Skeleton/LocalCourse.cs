namespace SoftwareAcademy
{
    using System;
    using System.IO;
    using System.Text;

    public class LocalCourse : Course, ICourse, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (value == string.Empty || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Local course lab cannot be null, empty or whitespace!");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.Append(string.Format("Lab={0}", this.Lab));

            // for checking answers
            // OutputTextOverwriter.OverwriteTextOutput(result);

            return result.ToString();
        }
    }
}
