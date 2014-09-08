namespace StudentSystem.Client
{
    using System;
    using System.Linq;
    using StudentSystem.Data;

    internal class EntryPoint
    {
        private static void Main()
        {
            var studentSystemContext = new StudentSystemContext();
            studentSystemContext.Database.Initialize(true);

            PrintStudents(studentSystemContext);

            PrintCourses(studentSystemContext);
        }

        private static void PrintStudents(StudentSystemContext studentSystemContext)
        {
            Console.WriteLine("Students: ");
            foreach (var students in studentSystemContext.Students.Include("Courses"))
            {
                Console.WriteLine(" - {0} -> present in {1} course(s).", students.Name, students.Courses.Count());
            }
        }

        private static void PrintCourses(StudentSystemContext studentSystemContext)
        {
            Console.WriteLine("\nCourses: ");
            foreach (var course in studentSystemContext.Courses.Include("Homeworks"))
            {
                Console.WriteLine(" - {0} -> has {1} homework(s).", course.Description, course.Homeworks.Count());
            }
        }
    }
}