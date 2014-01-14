using System;

class IsItLeapYear
{
    static void Main()
    {
        Console.Write("Please enter an year: ");
        int year = int.Parse(Console.ReadLine());

        bool isLeapYear = DateTime.IsLeapYear(year);
        Console.WriteLine("Is the year a leap year -> {0}", isLeapYear);
    }
}

