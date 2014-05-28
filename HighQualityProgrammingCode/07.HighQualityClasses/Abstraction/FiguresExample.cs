namespace Abstraction
{
    using System;

    internal class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            var circlePerimeter = circle.CalculatePerimeter();
            var circleSurface = circle.CalculateSurface();

            var circleInformationAsString = string.Format("I am a circle. My perimeter is {0:f2}. My surface is {1:f2}.", circlePerimeter, circleSurface);
            Console.WriteLine(circleInformationAsString);

            Rectangle rectangle = new Rectangle(2, 3);
            var rectanglePerimeter = rectangle.CalculatePerimeter();
            var rectangleSurface = rectangle.CalculateSurface();

            var rectangleInformationAsString = string.Format("I am a rectangle. My perimeter is {0:f2}. My surface is {1:f2}.",
                rectanglePerimeter, rectangleSurface);
            Console.WriteLine(rectangleInformationAsString);
        }
    }
}