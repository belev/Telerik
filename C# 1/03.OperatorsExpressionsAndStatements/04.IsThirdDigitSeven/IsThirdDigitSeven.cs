using System;

class IsThirdDigitSeven
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int number = int.Parse(Console.ReadLine());

        bool isThirdDigitSeven = ((number / 100) % 10) == 7;

        if (isThirdDigitSeven)
        {
            Console.WriteLine("The third digit from right to left is seven");
        }
        else
        {
            Console.WriteLine("The third digit from right to left is not seven");
        }
    }
}

