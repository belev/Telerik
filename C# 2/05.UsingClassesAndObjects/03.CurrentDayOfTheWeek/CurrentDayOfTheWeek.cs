using System;

class CurrentDayOfTheWeek
{
    static void Main()
    {
        DayOfWeek currentDay = DateTime.Today.DayOfWeek;

        Console.Write("Today is: ");
        Console.WriteLine(currentDay);
    }
}

