using System;

class PrintAgeAfterTenYears
{
    static void Main()
    {
        Console.Write("Please enter when you were born: ");
        int yearOfBirth = int.Parse(Console.ReadLine());

        DateTime futureDate = DateTime.Now.AddYears(10);

        int ageAfterTenYears = futureDate.Year - yearOfBirth;

        Console.WriteLine("After ten years you will be {0} years old", ageAfterTenYears);
    }
}

