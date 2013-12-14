using System;

class PrintCurrentDateAndTime
{
    static void Main()
    {
        DateTime currentDateAndTime = new DateTime();
        currentDateAndTime = DateTime.Now;

        Console.WriteLine(currentDateAndTime);
    }
}

