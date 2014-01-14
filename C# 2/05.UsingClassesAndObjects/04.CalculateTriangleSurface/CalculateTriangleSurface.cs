using System;

class CalculateTriangleSurface
{
    static double SurfaceByThreeSides(double a, double b, double c)
    {
        if (a > (b + c) || b > (a + c) || c > (a + b))
        {
            return -1;
        }

        else
        {
            double halfPerimeter = (a + b + c) / 2.0;
            double surface = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return surface;
        }
    }

    static double SurfaceByAltitudeAndSide(double a, double ha)
    {
        double surface = (a * ha) / 2.0;

        return surface;
    }

    static double SurfaceByTwoSidesAndAnAngle(double a, double b, double alpha)
    {
        double radians = DegreesToRadians(alpha);

        double surface = (a * b * Math.Sin(radians)) / 2.0;

        return surface;
    }

    static double DegreesToRadians(double alpha)
    {
        double radians = (alpha * Math.PI) / 180.0;

        return radians;
    }

    static void Main()
    {
        Console.WriteLine(SurfaceByThreeSides(3.0, 4.0, 5.0));

        Console.WriteLine(SurfaceByAltitudeAndSide(5.0, 4.0));

        Console.WriteLine(SurfaceByTwoSidesAndAnAngle(1.0, 3.0, 30));
    }
}

