using System;

class CompareFloatingPointWithPrecision
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());

        double secondNumber = double.Parse(Console.ReadLine());

        bool isEqual = Math.Abs(firstNumber - secondNumber) < 0.000001;

        Console.WriteLine("Are the numbers equal -> {0}", isEqual);
    }
}

