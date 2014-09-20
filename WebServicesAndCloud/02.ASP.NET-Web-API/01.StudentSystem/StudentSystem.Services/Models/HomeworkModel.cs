namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using StudentSystem.Models;
    using System.Linq.Expressions;

    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return h => new HomeworkModel
                {
                    HomeworkId = h.HomeworkId,
                    FileUrl = h.FileUrl,
                    TimeSent = h.TimeSent,
                    CourseId = h.CourseId,
                    StudentId = h.StudentId
                };
            }
        }

        public int HomeworkId { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}