using System;
using System.Linq;

public class BinaryPasswords
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        int asterisksCount = input.Where(c => c == '*').Count();

        ulong possibleBinaryPasswordsCount = 1;

        for (int i = 0; i < asterisksCount; i++)
        {
            possibleBinaryPasswordsCount *= 2;
        }

        Console.WriteLine(possibleBinaryPasswordsCount);
    }
}
