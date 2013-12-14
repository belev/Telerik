using System;

class CalculateTrapezoidArea
{
    static void Main()
    {
        Console.Write("Please enter side A of the trapezoid: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Please enter side B of the trapezoid: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Please enter the height of the trapezoid: ");
        double height = double.Parse(Console.ReadLine());

        double area = ((a + b) / 2) * height;

        Console.WriteLine("The trapezoid area is: {0}", area);
    }
}

