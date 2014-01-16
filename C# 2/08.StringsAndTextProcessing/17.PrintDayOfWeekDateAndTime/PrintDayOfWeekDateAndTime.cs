using System;
using System.Globalization;
class PrintDayOfWeekDateAndTime
{
    static void Main()
    {
        string dateString = Console.ReadLine();

        DateTime date = DateTime.ParseExact(dateString, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        date = date.AddHours(6.5);

        Console.WriteLine("{0} {1}", date.ToString("dddd", new CultureInfo("bg-BG")), date.ToString());
    }
}

