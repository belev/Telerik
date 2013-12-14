using System;

//Write a program that reads two arrays from the console and compares them element by element.

class CompareArraysElementByElement
{
    static void Main()
    {
        Console.Write("Enter the length of the first array: ");
        int firstArrayLength = int.Parse(Console.ReadLine());
        int[] firstArray = new int[firstArrayLength];

        for (int i = 0; i < firstArrayLength; i++)
        {
            Console.Write("firstArray[{0}] = ", i);
            firstArray[i] = int.Parse(Console.ReadLine());   
        }

        Console.Write("Enter the length of the second array: ");
        int secondArrayLength = int.Parse(Console.ReadLine());

        int[] secondArray = new int[secondArrayLength];

        for (int i = 0; i < secondArrayLength; i++)
        {
            Console.Write("secondArray[{0}] = ", i);
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        bool areWithEqualLength = firstArrayLength == secondArrayLength;
        bool areEqual = true;

        if (areWithEqualLength)
        {
            for (int i = 0; i < firstArrayLength; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    areEqual = false;
                    break;
                }
            }

            if (areEqual)
            {
                Console.WriteLine("The two arrays are equal");
            }
            else
            {
                Console.WriteLine("They are not equal");
            }
        }
        else
        {
            Console.WriteLine("Cant compare the arrays element by element because they have different sizes");
        }
    }
}

