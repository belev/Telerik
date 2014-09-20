namespace StudentSystem.Services.Models
{
    using StudentSystem.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return s => new StudentModel
                {
                    StudentId = s.StudentId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Level = s.Level
                };
            }
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
    }
}