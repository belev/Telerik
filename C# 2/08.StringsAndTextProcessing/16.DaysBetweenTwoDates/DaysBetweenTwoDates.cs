using System;
class DaysBetweenTwoDates
{
    static DateTime GetDateFromString(string date)
    {
        string[] rawDateInfo = date.Split('.');

        int year = int.Parse(rawDateInfo[2]);
        int month = int.Parse(rawDateInfo[1]);
        int day = int.Parse(rawDateInfo[0]);

        return new DateTime(year, month, day);
    }
    static void Main()
    {
        Console.Write("Enter first date: ");
        string firstDateAsString = Console.ReadLine();
        Console.WriteLine("Enter second date: ");
        string secondDateAsString = Console.ReadLine();

        DateTime firstDate = GetDateFromString(firstDateAsString);
        DateTime secondDate = GetDateFromString(secondDateAsString);

        int numberOfDays = Math.Abs((int)firstDate.Subtract(secondDate).TotalDays);
        Console.WriteLine(numberOfDays);
    }
}

