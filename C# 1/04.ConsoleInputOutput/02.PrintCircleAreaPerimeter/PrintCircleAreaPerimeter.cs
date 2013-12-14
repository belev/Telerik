using System;

class PrintCircleAreaPerimeter
{
    static void Main()
    {
        Console.Write("Please enter the radius of the circle: ");
        double radius = double.Parse(Console.ReadLine());

        double area = Math.PI * radius * radius;
        double perimeter = 2 * Math.PI * radius;

        Console.WriteLine("The area of the circle is: {0} \nThe perimeter of the circle is: {1}", area, perimeter);
    }
}

