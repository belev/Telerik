namespace Methods
{
    using System;

    public class Methods
    {
        private static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("The inequality of the triangle is violated.");
            }

            double halfPerimeter = (a + b + c) / 2;

            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            return area;
        }

        private static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentException("Invalid entered digit. Digits are from 0 to 9.");
            }
        }

        private static int FindMaxNumber(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Numbers sequence can not be null.");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Numbers sequence can not be empty.");
            }

            int maxNumber = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }
            return maxNumber;
        }

        private static void PrintNumber(double value, int digits)
        {
            string format = "{0:F" + digits + "}";
            Console.WriteLine(format, value);
        }

        private static void PrintPercent(double value, int digits)
        {
            string format = "{0:P" + digits + "}";
            Console.WriteLine(format, value);
        }

        private static void PrintAligned(object value, int totalWidth)
        {
            string format = "{0," + totalWidth + "}";
            Console.WriteLine(format, value);
        }

        private static bool IsHorizontalLine(double y1, double y2)
        {
            return y1 == y2;
        }

        private static bool IsVerticalLine(double x1, double x2)
        {
            return x1 == x2;
        }

        private static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            PrintNumber(1.3, 2);
            PrintPercent(0.75, 0);
            PrintAligned(2.30, 8);

            double x1 = 3;
            double y1 = -1;

            double x2 = 3;
            double y2 = 2.5;

            bool isHorizontalLine = IsHorizontalLine(y1, y2);
            bool isVerticalLine = IsVerticalLine(x1, x2);

            Console.WriteLine(CalculateDistance(x1, y1, x2, y2));
            Console.WriteLine("Horizontal? " + isHorizontalLine);
            Console.WriteLine("Vertical? " + isVerticalLine);

            Student peter = new Student("Peter", "Ivanov", new PersonalInformation("17.03.1992"));

            Student stella = new Student("Stella", "Markova", new PersonalInformation("03.11.1993"));

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
