using System;
//Write a method that returns the last digit of given integer as an English word. Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".

class LastDigitAsEnglishWord
{
    private static string GetLastDigitName(int number)
    {
        int lastDigit = number % 10;

        switch (lastDigit)
        {
            case 0:
                return "zero";
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
        }

        return "Not a digit";
    }
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        string lastDigitName = GetLastDigitName(number);

        Console.WriteLine("The last digit of the number as English word is: {0}", lastDigitName);
    }
}

