using System;
using System.Text;


class QuadraticEquation
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Enter three numbers to solve the following equation" + " " + "ax" + '\u00B2' + " + bx + c :");
        Console.WriteLine("Enter a:");
        string a = Console.ReadLine();
        Console.WriteLine("Enter b:");
        string b = Console.ReadLine();
        Console.WriteLine("Enter c:");
        string c = Console.ReadLine();

        int firstValue = int.Parse(a);
        int secondValue = int.Parse(b);
        int thirdValue = int.Parse(c);
        double Descriminant = (secondValue * secondValue - 4 * firstValue * thirdValue);
        int DescriminantEqualToZero = ((-secondValue / 2 * firstValue));
        double RealRootOne = ((-secondValue + Math.Sqrt(Descriminant)) / (2 * firstValue));
        double RealRootTwo = ((-secondValue - Math.Sqrt(Descriminant)) / (2 * firstValue));

        if (firstValue == 0)
        {
            Console.WriteLine("When a=0, the equation is no longer quadratic");
        }

        else
        {
            if (Descriminant < 0)
            {
                Console.WriteLine("The equations does not have real roots");
            }

            if (Descriminant == 0)
            {
                Console.WriteLine("The equation has only one real root : {0}", DescriminantEqualToZero);
            }
            if (Descriminant > 0)
            {
                Console.WriteLine("The equation has two real roots : {0} and {1}", RealRootOne, RealRootTwo);
            }

        }
    }

}