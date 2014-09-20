namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        public Course()
        {
            this.CourseId = Guid.NewGuid();
            this.Students = new HashSet<Student>();
            this.Homeworks = new HashSet<Homework>();
        }

        public Guid CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
