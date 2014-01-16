using System;
using System.Globalization;
using System.Text.RegularExpressions;
class ExtractDate
{
    static void Main()
    {
        string input = Console.ReadLine();

        //2 digits from 0 - 9, followed by '.', followed be 2 digits from 0 - 9, followed by '.', and followed by 4 digits from 0 - 9
        MatchCollection dates = Regex.Matches(input, @"[0-9]{2}[.][0-9]{2}[.][0-9]{4}");

        foreach (Match dateMatch in dates)
        {
            string dateAsString = Convert.ToString(dateMatch);

            DateTime date = DateTime.ParseExact(dateAsString, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
        }
    }
}

