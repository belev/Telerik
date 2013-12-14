using System;

class QuadraticEquationSolver
{
    static void Main()
    {
        Console.WriteLine("Please enter the three coeficients of the quadratic equation");

        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        if (a == 0.0)
        {
            double x = (-c) / b;
            Console.WriteLine("The equation is linear and its root is: {0}", x);
        }

        else
        {
            double discriminant = (b * b) - 4 * a * c;

            if (discriminant > 0.0)
            {
                double x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);

                Console.WriteLine("There are two real roots of the equation and they are: {0}, {1}", x1, x2);
            }
            else if (discriminant == 0.0)
            {
                double x = (-b) / (2 * a);

                Console.WriteLine("There is one double real root of the equation and it is: {0}", x);
            }
            else
            {
                Console.WriteLine("There are no real roots of the equation");
            }
        }
    }
}
