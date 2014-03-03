namespace SoftwareAcademy
{
    using System;
    using System.IO;
    using System.Text;

    class OffsiteCourse : Course, ICourse, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (value == string.Empty || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Offsite course's town cannot be null, empty or whitespace!");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.Append(string.Format("Town={0}", this.Town));

            // for checking answers
            // OutputTextOverwriter.OverwriteTextOutput(result);

            return result.ToString();
        }
    }
}
