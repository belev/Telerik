using System;
using System.Collections.Generic;

//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

class QuickSortAlgorithm
{
    private static void QuickSort(List<string> list, int left, int right)
    {
        int i = left;
        int j = right;

        int pivot = (left + right) / 2;

        string pivotString = list[pivot];

        while (i <= j)
        {
            //increase i because the current element (on the left) in the list is before the pivot
            while (list[i].CompareTo(pivotString) < 0)
            {
                i++;
            }

            //decrease j because the the current element (on the right) in the list is after the pivot
            while (pivotString.CompareTo(list[j]) < 0)
            {
                j--;
            }

            if (i <= j)
            {
                string tempStr = list[i];
                list[i] = list[j];
                list[j] = tempStr;

                //because we swap on the left side is one more element smaller than the pivot so we increase i
                //and we decrease j because of the same fact
                i++;
                j--;
            }
        }

        if (j > left)
        {
            QuickSort(list, left, j);
        }
        if (i < right)
        {
            QuickSort(list, i, right);
        }
    }

    static void Main()
    {
        Console.Write("Enter number of strings: ");
        int numberOfStrings = int.Parse(Console.ReadLine());

        List<string> listOfStrings = new List<string>();

        for (int i = 0; i < numberOfStrings; i++)
        {
            Console.Write("listOfStrings[{0}] = ", i);
            string line = Console.ReadLine();

            listOfStrings.Add(line);
        }

        QuickSort(listOfStrings, 0, numberOfStrings - 1);

        string sortedStrings = string.Join(", ", listOfStrings);
        Console.WriteLine(sortedStrings);
    }
}

