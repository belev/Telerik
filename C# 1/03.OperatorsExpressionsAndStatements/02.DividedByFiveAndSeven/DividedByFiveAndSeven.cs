using System;

class DividedByFiveAndSeven
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int number = int.Parse(Console.ReadLine());

        bool isDividedByFiveAndSeven = (number % 35) == 0;

        if (isDividedByFiveAndSeven)
        {
            Console.WriteLine("The number can be divided without remainder by 5 and 7 in the same time");
        }
        else
        {
            Console.WriteLine("The number can not be divided without remainder by 5 and 7 in the same time");
        }
    }
}

