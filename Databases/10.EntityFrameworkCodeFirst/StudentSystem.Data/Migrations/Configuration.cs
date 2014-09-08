namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
        }

        private void SeedCourses(StudentSystemContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course()
            {
                Description = "C# Part 1",
                Homeworks = new List<Homework>()
                {
                    new Homework()
                    {
                        Content = "Introduction to Programming with C-Sharp",
                        Materials = new List<Material>()
                        {
                            new Material()
                            {
                                Type = MaterialType.Presentation,
                                DownloadUrl = "http://telerikacademy.com/"
                            },
                            new Material()
                            {
                                Type = MaterialType.SourceCode,
                                DownloadUrl = "http://telerikacademy.com/"
                            }
                        }
                    }
                }
            });

            context.Courses.Add(new Course()
            {
                Description = "HTML",
                Homeworks = new List<Homework>()
                {
                    new Homework()
                    {
                        Content = "Introduction to html",
                        Materials = new List<Material>()
                        {
                            new Material()
                            {
                                Type = MaterialType.Presentation,
                                DownloadUrl = "http://telerikacademy.com/"
                            }
                        }
                    }
                }
            });

            context.Courses.Add(new Course()
            {
                Description = "JavaScript",
                Homeworks = new List<Homework>()
                {
                    new Homework()
                    {
                        Content = "Introduction to java script",
                        Materials = new List<Material>()
                        {
                            new Material()
                            {
                                Type = MaterialType.Presentation,
                                DownloadUrl = "http://telerikacademy.com/"
                            }
                        }
                    }
                }
            });

            context.Courses.Add(new Course()
            {
                Description = "C# OOP"
            });

            context.Courses.Add(new Course()
            {
                Description = "PHP Web-Development"
            });

            context.Courses.Add(new Course()
            {
                Description = "HTML5 / CSS3 Fundamentals"
            });

            context.SaveChanges();
        }

        private void SeedStudents(StudentSystemContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Students', RESEED, 100000)");

            context.Students.Add(new Student()
            {
                Name = "Pesho Kirkovich",
                Courses = context.Courses.Take(1).ToList()
            });

            context.Students.Add(new Student()
            {
                Name = "Gosho Spirovich",
                Courses = context.Courses.Take(2).ToList()
            });

            context.Students.Add(new Student()
           {
               Name = "Mimi Mimova",
               Courses = context.Courses.Take(3).ToList()
           });

            context.SaveChanges();
        }
    }

}
