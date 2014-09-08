namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Models;
    using StudentSystem.Data.Migrations;

    public class StudentSystemContext : DbContext
    {
        const string StudentSystemDatabaseName = "StudentSystem";

        public StudentSystemContext()
            : base(StudentSystemDatabaseName)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Material> Materials { get; set; }
    }
}
