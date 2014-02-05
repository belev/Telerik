using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StudentProject
{
    ////09.Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber.
    //Create a List<Student> with sample students. Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
    class Tester
    {
        /// <summary>
        /// 09.Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
        /// </summary>
        static void FindStudentsFromSecondGroupWithLinq()
        {
            var studentsFromSecondGroupWithLinq =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            foreach (var student in studentsFromSecondGroupWithLinq)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 10.Implement the previous using the same query expressed with extension methods.
        /// </summary>
        static void FindStudentsFromSecondGroupWithLambda()
        {
            var studentsFromSecondGroupWithLambda = students.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);

            foreach (var student in studentsFromSecondGroupWithLambda)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 11.Extract all students that have email in abv.bg. Use string methods and LINQ.
        /// </summary>
        static void FindStudentsWithEmailInAbv()
        {
            var studentWithEmailInAbv =
                from student in students
                where student.Email.EndsWith("abv.bg")
                select student;

            foreach (var student in studentWithEmailInAbv)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 12.Extract all students with phones in Sofia. Use LINQ.
        /// </summary>
        static void FindStudentsWithSofiaPhoneNumber()
        {
            var studentsWithSofiaPhoneNumbers =
                from student in students
                where student.Tel.StartsWith("02")
                select student;

            foreach (var student in studentsWithSofiaPhoneNumbers)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 13.Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
        /// </summary>
        static void FindStudentsWithAtLeastOneExcellentMark()
        {
            var studentsWithExcellentMark =
                from student in students
                where student.ContainMark(6)
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.GetMarks() };

            foreach (var student in studentsWithExcellentMark)
            {
                Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);
            }
        }

        /// <summary>
        /// 14.Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.
        /// </summary>
        static void FindStudentsWithExactlyTwoMarks()
        {
            var studentsWithExactlyTwoMarks =
                from student in students
                where student.MarksCount == 2
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.GetMarks() };

            foreach (var student in studentsWithExactlyTwoMarks)
            {
                Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 15.Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
        /// substring from element on position 4 (not position 5) because the indeces start from 0
        /// </summary>
        static void FindStudentMarksEnrolledIn2006()
        {
            var studentsEnrolledIn2006 =
                from student in students
                where student.FN.Substring(4, 2) == "06"
                select new { FullName = student.FirstName + " " + student.LastName, FN = student.FN, Marks = student.GetMarks() };

            foreach (var student in studentsEnrolledIn2006)
            {
                Console.WriteLine("{0} - FN: {1} -> {2}", student.FullName, student.FN, student.Marks);
            }
        }

        static List<Student> students;
        static void Main()
        {
            students = new List<Student>()
            {
                new Student("Grigor", "Petrov", "316106", "02876455", "grigor@abv.bg", new List<int> {3, 4}, 2),
                new Student("Petar", "Marinov", "316206", "02899123", "petar@gmail.com", new List<int> {6, 5, 6, 6}, 2),
                new Student("Dobri", "Gospodinov", "324806", "73654789", "dobri@abv.bg", new List<int> {6, 5, 6}, 4),
                new Student("Anna", "Dimova", "395103", "52999999", "anna@gmail.com", new List<int> {6, 6}, 2),
                new Student("Penka", "Stoicheva", "318206", "0899111111", "penka@abv.bg", new List<int>{2, 2, 3, 3}, 5)

            };

            FindStudentsFromSecondGroupWithLinq();

            FindStudentsFromSecondGroupWithLambda();

            FindStudentsWithEmailInAbv();

            FindStudentsWithSofiaPhoneNumber();

            FindStudentsWithAtLeastOneExcellentMark();

            FindStudentsWithExactlyTwoMarks();

            FindStudentMarksEnrolledIn2006();
        }
    }
}
