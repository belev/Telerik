using System;
//Write a program that finds the index of given element in a sorted array of integers
//by using the binary search algorithm (find it in Wikipedia).

class BinarySearch
{
    static void Main()
    {
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Enter the wanted element: ");
        int wantedElement = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);

        int left = 0;
        int right = array.Length;
        int middle = (left + right) / 2;

        int indexOfWantedElement = -1;

        bool isFound = false;

        while (left + 1 < right)
        {
            if (array[middle] > wantedElement)
            {
                right = middle;

                middle = (left + right) / 2;
            }
            else if (array[middle] < wantedElement)
            {
                left = middle;

                middle = (left + right) / 2;
            }
            else
            {
                isFound = true;
                indexOfWantedElement = middle;
                break;
            }
        }

        if (isFound)
        {
            Console.WriteLine("The wanted element - > {0} is on position {1} in the array", wantedElement, indexOfWantedElement);
        }
        else
        {
            Console.WriteLine("There is no such element is the array");
        }
    }
}

