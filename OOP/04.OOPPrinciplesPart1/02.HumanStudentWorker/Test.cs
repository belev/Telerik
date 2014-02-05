using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.HumanStudentWorker
{
    class Test
    {
        static void InitializeStudents()
        {
            students = new List<Student>();

            students.Add(new Student("Gosho", "Petrov", 9));
            students.Add(new Student("Grigor", "Marinov", 12));
            students.Add(new Student("Pesho", "Petrov", 6));
            students.Add(new Student("Misho", "Dimov", 2));
            students.Add(new Student("Sasho", "Zlatev", 5));
            students.Add(new Student("Mariika", "Dimitrova", 1));
            students.Add(new Student("Frodo", "Mishev", 8));
            students.Add(new Student("Valio", "Mitev", 3));
            students.Add(new Student("Ivan", "Damqnov", 6));
            students.Add(new Student("Dimitrina", "Dimova", 7));
        }
        static void InitializeWorkers()
        {
            workers = new List<Worker>();

            workers.Add(new Worker("Georgi", "Petrov", 100, 5));
            workers.Add(new Worker("Grisho", "Marinov", 200, 5));
            workers.Add(new Worker("Petar", "Petrov", 300, 5));
            workers.Add(new Worker("Mihail", "Dimov", 250, 5));
            workers.Add(new Worker("Aleksandur", "Zlatev", 1000, 10));
            workers.Add(new Worker("Mariq", "Dimitrova", 5000, 10));
            workers.Add(new Worker("Vlado", "Mishev", 2000, 8));
            workers.Add(new Worker("Valio", "Mitev", 50, 2));
            workers.Add(new Worker("Ivan", "Damqnov", 500, 6));
            workers.Add(new Worker("Dimitrina", "Dimova", 1200, 12));
        }
        static void MergeStudentsAndWorkers()
        {

        }
        static List<Student> students;
        static List<Worker> workers;
        static void Main()
        {
            InitializeStudents();

            //var sortAscendingByGradeWithLambda = students.OrderBy(x => x.Grade);
            //foreach (Student student in sortAscendingByGradeWithLambda)
            //{
            //    Console.WriteLine(student.ToString());
            //}
            //Console.WriteLine();

            var sortAscendingByGradeWithLINQ =
                from student in students
                orderby student.Grade
                select student;

            foreach (Student student in sortAscendingByGradeWithLINQ)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine();

            InitializeWorkers();

            //with lambda expression
            var sortDescendingByMoneyPerHour = workers.OrderByDescending(x => x.MoneyPerHour());

            foreach (var worker in sortDescendingByMoneyPerHour)
            {
                Console.WriteLine(worker.ToString());
            }
            Console.WriteLine();
            //with LINQ
            //var sortDescendingByMoneyPerHourWithLinq =
            //    from worker in workers
            //    orderby worker.MoneyPerHour() descending
            //    select worker;

            //foreach (var worker in sortDescendingByMoneyPerHourWithLinq)
            //{
            //    Console.WriteLine(worker.ToString());
            //}

            List<Human> studentsAndWorkers = new List<Human>();
            studentsAndWorkers.AddRange(students);
            studentsAndWorkers.AddRange(workers);

            var allSortedByNameWithLINQ =
                from human in studentsAndWorkers
                orderby human.FirstName, human.LastName
                select human;

            foreach (var human in allSortedByNameWithLINQ)
            {
                Console.WriteLine(human);
            }
            Console.WriteLine();

            //sort with lambda

            //var allSortedByNameWithLambda = studentsAndWorkers.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            //foreach (var human in allSortedByNameWithLambda)
            //{
            //    Console.WriteLine(human);
            //}
        }
    }
}
