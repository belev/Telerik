using System;
using System.Text.RegularExpressions;
class ExtractEmails
{
    static void Main()
    {
        string input = Console.ReadLine();
        //test
        //Please contact us by phone (+359 222 222 222) or by email at exa_mple@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.

        MatchCollection emails = Regex.Matches(input, @"[\w.]{2,20}@[\w]{2,20}[.]{1}[\w.]{2,6}");

        foreach (Match email in emails)
        {
            Console.WriteLine(email.Value);
        }
    }
}

