using System;
using System.Text;
class StringWithMaximumLength
{
    static void Main()
    {
        const int maxSymbols = 20;
        string input = Console.ReadLine();

        if (input.Length > maxSymbols)
        {
            Console.WriteLine("The input string length is bigger than the maximum number of symbols!");
        }
        else
        {
            Console.WriteLine(input.PadRight(maxSymbols, '*'));
        }
    }
}

