using System;
using System.Collections.Generic;

class TwoIsBetterThanOne
{
    private static bool IsPalindrome(ulong number)
    {
        string numAsString = number.ToString();

        bool isPalindrome = true;

        for (int i = 0; i < numAsString.Length / 2; i++)
        {
            if (numAsString[i] != numAsString[numAsString.Length - i - 1])
            {
                isPalindrome = false;
                break;
            }
        }

        return isPalindrome;
    }

    static int FindLuckyNumbers(ulong lowerBound, ulong upperBound)
    {
        ulong max = upperBound;
        int left = 0;
        var numbers = new List<ulong> { 3, 5 };

        int count = 0;
        while (left < numbers.Count)
        {
            int right = numbers.Count;
            for (int i = left; i < right; i++)
            {
                if (numbers[i] < max)
                {
                    numbers.Add((numbers[i] * 10) + 3);
                    numbers.Add((numbers[i] * 10) + 5);
                }
            }
            left = right;
        }

        foreach (var num in numbers)
        {
            if (num >= lowerBound && num <= upperBound && IsPalindrome(num))
            {
                count++;
            }
        }

        return count;
    }

    private static int FindAnswerSecondTask(int[] numbers, int percent)
    {
        Array.Sort(numbers);
        for (int i = 0; i < numbers.Length; i++)
        {
            int countSmaller = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[i] >= numbers[j])
                {
                    countSmaller++;
                }
            }

            if (countSmaller >= (numbers.Length * (percent / 100.0)))
            {
                return numbers[i];
            }
        }

        return numbers[numbers.Length - 1];
    }

    static void Main()
    {
        string[] rawNums = Console.ReadLine().Split(' ');

        ulong a = ulong.Parse(rawNums[0]);
        ulong b = ulong.Parse(rawNums[1]);

        int counter = FindLuckyNumbers(a, b);

        
        //second task
        rawNums = Console.ReadLine().Split(',');
        int p = int.Parse(Console.ReadLine());

        int[] numbers = new int[rawNums.Length];

        for (int i = 0; i < rawNums.Length; i++)
        {
            numbers[i] = int.Parse(rawNums[i]);
        }

        int result = FindAnswerSecondTask(numbers, p);

        Console.WriteLine(counter);
        Console.WriteLine(result);
    }
}