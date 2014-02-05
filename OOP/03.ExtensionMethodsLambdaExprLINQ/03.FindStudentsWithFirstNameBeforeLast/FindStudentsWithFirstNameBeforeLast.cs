using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FindStudentsWithFirstNameBeforeLast
{
    //03.Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.

    class FindStudentsWithFirstNameBeforeLast
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            students.Add(new Student("Gosho", "Petrov"));
            students.Add(new Student("Ivan", "Georgiev"));
            students.Add(new Student("Aleksandar", "Borisov"));
            students.Add(new Student("Dobroslava", "Burgaska"));
            students.Add(new Student("Dobromir", "Dobromirov"));

            var result =
                from student in students
                where student.FirstName.CompareTo(student.LastName) == -1
                select student;

            foreach (var student in result)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
