using System;
using System.Collections.Generic;
using System.Linq;
//You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

public class LengthComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return (x.Length.CompareTo(y.Length));
    }
}
class SortStringArrayByStringsLength
{
    static void Main()
    {
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());

        string[] array = new string[length];

        for (int i = 0; i < length; i++)
        {
            array[i] = Console.ReadLine();
        }

        //with IComparer
        LengthComparer comparer = new LengthComparer();

        Array.Sort(array, comparer);

        string result = string.Join(", ", array);

        Console.WriteLine(result);

        //another solution

        // Array.Sort(array, (x, y) => x.Length.CompareTo(y.Length));
        // string result = string.Join(", ", array);
        // Console.WriteLine(result);
    }
}

