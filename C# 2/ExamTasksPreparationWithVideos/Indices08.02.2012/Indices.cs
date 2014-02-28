using System;
using System.Text;

class Indices
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] rawNumbers = Console.ReadLine().Split(' ');

        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(rawNumbers[i]);
        }

        bool[] isUsed = new bool[n];

        int start = 0;
        bool hasCycle = false;

        StringBuilder result = new StringBuilder();

        while (true)
        {
            if (start < 0 || start >= n)
            {
                break;
            }

            if (isUsed[start] == true)
            {
                hasCycle = true;
                break;
            }

            result.Append(start);
            result.Append(" ");

            isUsed[start] = true;
            start = numbers[start];
        }

        if (hasCycle)
        {
            if (start > 0)
            {
                int index = result.ToString().IndexOf(start.ToString()) - 1;
                result.Replace(' ', '(', index, 1);
            }
            else
            {
                result.Insert(0, '(');
            }

            result.Insert(result.Length - 1, ')');

            Console.WriteLine(result.ToString().Trim());
        }
        else
        {
            Console.WriteLine(result.ToString().Trim());
        }
    }
}