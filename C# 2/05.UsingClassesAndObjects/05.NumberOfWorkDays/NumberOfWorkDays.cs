using System;
using System.Collections.Generic;
class NumberOfWorkDays
{
    static readonly List<DateTime> holidays = new List<DateTime>()
        {
            new DateTime(2014, 1, 16),
            new DateTime(2014, 12, 24),
            new DateTime(2014, 1, 1)
        };


    static int CalculateWorkDays(DateTime today, DateTime date)
    {
        bool isHoliday = false;
        int numberOfWorkDays = 0;

        while (today.CompareTo(date) != 1)
        {
            isHoliday = false;

            foreach (DateTime holiday in holidays)
            {
                if (today.Equals(holiday))
                {
                    isHoliday = true;
                    break;
                }
            }


            if (!isHoliday && today.DayOfWeek != DayOfWeek.Saturday && today.DayOfWeek != DayOfWeek.Sunday)
            {
                numberOfWorkDays++;
            }

            today = today.AddDays(1);
        }

        return numberOfWorkDays;
    }

    static void Main(string[] args)
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());

        DateTime date = new DateTime(year, month, day);

        int numberOfWorkDays = CalculateWorkDays(DateTime.Today, date);
        Console.WriteLine(numberOfWorkDays);
    }
}

