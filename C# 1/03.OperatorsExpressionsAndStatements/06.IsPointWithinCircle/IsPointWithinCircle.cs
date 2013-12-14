using System;

class IsPointWithinCircle
{
    const double circleRadius = 5;

    static void Main()
    {
        Console.Write("Please enter the X coordinate: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Please enter the Y coordinate: ");
        double y = double.Parse(Console.ReadLine());

        bool isWithin = ((x * x) + (y * y)) < (circleRadius * circleRadius);

        if (isWithin)
        {
            Console.WriteLine("The point is within the circle K(0, 5)");
        }
        else
        {
            Console.WriteLine("The point is outside the circle or it is on the contour");
        }
    }
}

