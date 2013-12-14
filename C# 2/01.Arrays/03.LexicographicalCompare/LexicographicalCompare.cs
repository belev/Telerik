using System;
//Write a program that compares two char arrays lexicographically (letter by letter).

class LexicographicalCompare
{
    static void Main()
    {
        Console.Write("Enter first char sequence: ");
        string firstInput = Console.ReadLine();

        Console.Write("Enter second char sequence: ");
        string secondInput = Console.ReadLine();

        char[] firstCharArray = firstInput.ToCharArray();
        char[] secondCharArray = secondInput.ToCharArray();

        int minimalLength = Math.Min(firstCharArray.Length, secondCharArray.Length);
        bool areEqual = true;

        for (int i = 0; i < minimalLength; i++)
        {
            // check if there is different element
            if (firstCharArray[i] != secondCharArray[i])
            {
                areEqual = false;

                if (firstCharArray[i] < secondCharArray[i])
                {
                    Console.WriteLine("The first array is lexicographically before the second one");
                    break;
                }
                else
                {
                    Console.WriteLine("The first array is lexicographically after the second one");
                }
            }
        }

        if (areEqual && firstCharArray.Length == secondCharArray.Length)
        {
            Console.WriteLine("The arrays are equal");
        }
        else if (areEqual && firstCharArray.Length > secondCharArray.Length)
        {
            Console.WriteLine("The second array is lexicographically before the first");
        }
        else if (areEqual && firstCharArray.Length < secondCharArray.Length)
        {
            Console.WriteLine("The first array is lexicographically before the second");
        }
    }
}

