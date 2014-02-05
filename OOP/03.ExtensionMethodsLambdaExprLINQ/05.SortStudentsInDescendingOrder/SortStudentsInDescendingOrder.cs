using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SortStudentsInDescendingOrder
{
    //05.Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order. Rewrite the same with LINQ.

    class SortStudentsInDescendingOrder
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]
            {
                new Student("Gosho", "Petrov"),
                new Student("Ivan", "Georgiev"),
                new Student("Aleksandar", "Borisov"),
                new Student("Dobroslava", "Burgaska"),
                new Student("Dobroslava", "Dobromirov"),
                new Student("Jorjo", "Ganchev"), 
                new Student("Dobri", "Penchev"),
                new Student("Qvor", "Draganov")
            };

            var descendingOrderWithLambda = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);

            foreach (var student in descendingOrderWithLambda)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine();

            var descendingOrderWithLINQ =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            //same result with
            /*
             var descendingOrderWithLINQ =
                from student in students
                orderby student.LastName descending
                orderby student.FirstName descending
                select student;
             */

            foreach (var student in descendingOrderWithLINQ)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
