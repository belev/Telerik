using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    //We are given a school. In the school there are classes of students. Each class has a set of teachers. Each teacher teaches a set of disciplines.
    //Students have name and unique class number. Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures and
    //number of exercises. Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).

    //Your task is to identify the classes (in terms of  OOP) and their attributes and operations, encapsulate their fields, define the class hierarchy and
    //create a class diagram with Visual Studio.

    class Test
    {
        static void Main()
        {
            Student goshkoStudent = new Student("Goshko", 5);
            goshkoStudent.AddComment("Goshko is a bad student.");

            Student peshoStudent = new Student("Pesho", 10);
            peshoStudent.AddComment("Pesho is a normal student.");

            Student ivanStudent = new Student("Ivan", 11);
            ivanStudent.AddComment("Ivan is a great student.");

            Discipline maths = new Discipline("Maths", 10, 10);
            Discipline physics = new Discipline("Physics", 5, 4);

            Teacher teacher = new Teacher("Borislav Petrov", new List<Discipline>() { maths, physics });
            teacher.AddComment("Borislav Petrov is a very good teacher.");
            teacher.AddComment("Wonderful teacher.");
            teacher.AddComment("Teaches only useful and interesting things.");

            //test comments methods
            teacher.ShowComments();
            Console.WriteLine();

            teacher.RemoveComment("Wonderful teacher.");
            //the comments after removed one comment
            teacher.ShowComments();

            //clear all comments and after that nothing happens
            teacher.ClearAllComments();
            teacher.ShowComments();

            Class newClass = new Class("123", new List<Teacher>() { teacher }, new List<Student>() { goshkoStudent, peshoStudent, ivanStudent });

            School school = new School(new List<Class>() { newClass });
        }
    }
}
