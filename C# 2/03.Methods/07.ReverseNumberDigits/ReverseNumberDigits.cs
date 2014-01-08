using System;
//Write a method that reverses the digits of given decimal number. Example: 256 -> 652

class ReverseNumberDigits
{
    private static string Reverse(string numberAsString)
    {
        string reversed = "";

        for (int i = numberAsString.Length - 1; i >= 0; i--)
        {
            reversed += numberAsString[i];
        }
        return reversed;
    }
    static void Main()
    {
        Console.Write("Enter number: ");
        string numberAsString = Console.ReadLine();

        string number = "";
        if (numberAsString[0] == '-')
        {
           number = numberAsString.Remove(0, 1);
           number += '-';
        }
        else
        {
            number = numberAsString;
        }

        string reversedNumber = Reverse(number);

        Console.WriteLine("Number: {0}, Reversed number: {1}", numberAsString, reversedNumber);
    }
}

