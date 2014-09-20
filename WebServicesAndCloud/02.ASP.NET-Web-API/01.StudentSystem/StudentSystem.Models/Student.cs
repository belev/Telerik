namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
            this.AdditionalInformation = new StudentInfo();
        }

        public int StudentId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Level { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public StudentInfo AdditionalInformation { get; set; }
    }
}
