using System;

class IsWithinCircleAndOutsideRectangle
{
    const double circleRadius = 3.0;
    const double circleCenterX = 1.0;
    const double circleCenterY = 1.0;

    static void Main()
    {
        Console.Write("Please enter the X coordinate of the point: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Please enter the Y coordinate of the point: ");
        double y = double.Parse(Console.ReadLine());

        bool isWithinCircle = (((x - circleCenterX) * (x - circleCenterX) + (y - circleCenterY) * (y - circleCenterY)) <= circleRadius * circleRadius);

        bool isOutsideRectangle = (x > 5.0 || x < -1.0 || y > 1.0 || y < -1.0);

        if (isWithinCircle && isOutsideRectangle)
        {
            Console.WriteLine("The point is within the circle and outside the rectangle");
        }
        else
        {
            Console.WriteLine("The point is not (within the circle and outside the rectangle)");
        }

    }
}

