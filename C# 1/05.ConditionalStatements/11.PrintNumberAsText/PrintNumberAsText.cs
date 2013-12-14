using System;

class PrintNumberAsText
{
    public static string[] units = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    public static string[] tensFromTenToTwenty = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

    public static string[] tens = { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };

    static void Main()
    {
        int number;

        do
        {
            Console.Write("Please enter number: ");
            number = int.Parse(Console.ReadLine());

        } while (number < 0 || number >= 1000);

        string numberAsText = "";

        int firstDigit = number / 100;
        int secondDigit = (number / 10) % 10;
        int thirdDigit = number % 10;

        if (number >= 100)
        {
            numberAsText += units[firstDigit] + " hundred ";

            if (secondDigit > 1)
            {
                if (thirdDigit != 0)
                {
                    numberAsText += tens[secondDigit - 2] + " " + units[thirdDigit];
                }
                else
                {
                    numberAsText += tens[secondDigit - 2];
                }
            }
            else if (secondDigit == 1)
            {
                numberAsText += "and " + tensFromTenToTwenty[thirdDigit];
            }
            else
            {
                if (thirdDigit != 0)
                {
                    numberAsText += "and " + units[thirdDigit];
                }
            }
        }
        else
        {
            if (secondDigit > 1)
            {
                if (thirdDigit != 0)
                {
                    numberAsText += tens[secondDigit - 2] + " " + units[thirdDigit];
                }
                else
                {
                    numberAsText += tens[secondDigit - 2];
                }
            }
            else if (secondDigit == 1)
            {
                numberAsText += tensFromTenToTwenty[thirdDigit];
            }
            else
            {
                numberAsText += units[thirdDigit];
            }
        }

        Console.WriteLine(numberAsText);
    }
}

