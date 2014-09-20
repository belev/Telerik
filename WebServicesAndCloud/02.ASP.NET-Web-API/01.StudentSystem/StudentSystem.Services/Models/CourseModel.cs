namespace StudentSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using StudentSystem.Models;
    using System.Linq.Expressions;

    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return c => new CourseModel
                {
                    CourseId = c.CourseId,
                    Name = c.Name,
                    Description = c.Description,
                    Students = c.Students
                                .Select(s => new StudentModel()
                                       {
                                           StudentId = s.StudentId,
                                           FirstName = s.FirstName,
                                           LastName = s.LastName,
                                           Level = s.Level
                                       })
                                .ToList(),
                    Homeworks = c.Homeworks
                                 .Select(h => new HomeworkModel()
                                        {
                                            FileUrl = h.FileUrl,
                                            TimeSent = h.TimeSent,
                                            CourseId = h.CourseId,
                                            StudentId = h.StudentId,
                                            HomeworkId = h.HomeworkId
                                        })
                                 .ToList()
                };
            }
        }

        public Guid CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<StudentModel> Students { get; set; }

        public virtual ICollection<HomeworkModel> Homeworks { get; set; }
    }
}