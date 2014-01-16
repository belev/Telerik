using System;
class ReverseString
{
    static void Main()
    {
        string inputString = Console.ReadLine();

        char[] inputAsArray = inputString.ToCharArray();
        Array.Reverse(inputAsArray);

        string reversedString = new string(inputAsArray);
        Console.WriteLine(reversedString);
    }
}

