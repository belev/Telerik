namespace _01.StudentsAndCourses
{
    using System;
    using System.IO;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class StudentsAndCourses
    {
        static OrderedMultiDictionary<string, Student> courses;

        private static void ReadStudentsAndCoursesInput()
        {
            // using OrderedMultiDictionary because courses names can repeat
            // in SortedDictionary this is not possible

            // for every course we add the students which attend this course
            // and they are sorted by last name and then by first name (look at the Student class)
            courses = new OrderedMultiDictionary<string, Student>(true);

            StreamReader reader = new StreamReader("students.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    var splitted = line.Split('|');

                    string studentFN = splitted[0].Trim();
                    string studentLN = splitted[1].Trim();
                    string courseName = splitted[2].Trim();

                    courses.Add(courseName, new Student(studentFN, studentLN));

                    line = reader.ReadLine();
                }
            }
        }

        private static void PrintCoursesAndStudentsIn()
        {
            foreach (var course in courses)
            {
                Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value));
            }
        }

        static void Main(string[] args)
        {
            ReadStudentsAndCoursesInput();

            PrintCoursesAndStudentsIn();
        }
    }
}
