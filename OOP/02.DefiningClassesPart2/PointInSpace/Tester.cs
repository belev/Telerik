using System;
using System.Collections.Generic;
using System.Text;

namespace PointInSpace
{
    class Tester
    {
        static void Main()
        {
            const string fileName = "PathSaved.txt";

            Console.ForegroundColor = ConsoleColor.Cyan;
            //create instance of class point and test the override ToString method
            Point firstPoint = new Point(1.0, 2.0, 3.0);
            Console.WriteLine(firstPoint.ToString());

            //test if the default constructor works correctly
            Point secondPoint = Point.PointO;
            Console.WriteLine(secondPoint);

            // Math.Sqrt( (0 - 1) ^ 2 + ( 0 - 2 ) ^ 2 + ( 0 - 3 ) ^ 2 ) = Math.Sqrt(14)
            double distance = Distance.CalculateDistance(firstPoint, secondPoint);

            Console.ResetColor();
            //check if calculate distance works correctly
            Console.WriteLine(distance);
            Console.WriteLine(Math.Sqrt(14));


            //test Path class
            Path path = new Path();

            path.AddPoint(new Point(1.5, 1.19, 29d));
            path.AddPoint(new Point(7.4, 19.1, 17.14));
            path.AddPoint(firstPoint);

            //test the static method SavePath
            //using constant file name for easier testing
            PathStorage.SavePath(path, fileName);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();

            //print path after deleting the first point
            path.RemoveFirstPoint();
            path.Print();

            //test the static method LoadPath
            //using constant file name for easier testing
            Path pathBeforeRemovingPoint = PathStorage.LoadPath(fileName);
            Console.ResetColor();
            pathBeforeRemovingPoint.Print();

        }
    }
}
