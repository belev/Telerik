using System;

class CalculateRectangleArea
{
    static void Main()
    {
        Console.Write("Please enter width of the rectangle: ");
        double rectangleWidth = double.Parse(Console.ReadLine());

        Console.Write("Please enter height of the rectangle: ");
        double rectangleHeight =double.Parse(Console.ReadLine());

        double rectangleArea = rectangleHeight * rectangleWidth;

        Console.WriteLine("The area of the rectangle with width {0} and height {1} is: {2}",rectangleWidth, rectangleHeight, rectangleArea);

    }
}

