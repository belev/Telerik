namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Course : ICourse
    {
        private string name;
        private IList<string> topics;

        public Course(string name, ITeacher teacher = null)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Topics = new List<string>();
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
                    throw new ArgumentNullException("Course name cannot be null, empty or whitespace!");
                }

                this.name = value;
            }
        }

        public ITeacher Teacher { get; set; }

        private IList<string> Topics
        {
            get
            {
                return this.topics;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Topics value cannot be null!");
                }

                this.topics = value;
            }
        }

        public void AddTopic(string topic)
        {
            if (topic == string.Empty || string.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentNullException("Topic to add cannot be null, empty or whitespace!");
            }

            this.Topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            string courseType = this.GetType().Name;
            string courseName = this.Name;
            string topicsAsString = this.topics.Count != 0 ? string.Join(", ", this.Topics) : null;

            result.Append(string.Format("{0}: Name={1}; ", courseType, courseName));

            if (this.Teacher != null)
            {
                result.Append(string.Format("Teacher={0}; ", this.Teacher.Name));
            }

            if (topicsAsString != null)
            {
                result.Append(string.Format("Topics=[{0}]; ", topicsAsString));
            }

            return result.ToString();
        }
    }
}
