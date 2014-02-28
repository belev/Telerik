using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class AcademyTasks
{
    static void Main()
    {
        string[] pleasantnessRaw = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);
        int variety = int.Parse(Console.ReadLine());

        int[] pleasantness = new int[pleasantnessRaw.Length];

        for (int i = 0; i < pleasantnessRaw.Length; i++)
        {
            pleasantness[i] = int.Parse(pleasantnessRaw[i]);
        }

        int result = pleasantness.Length;

        for (int i = 0; i < pleasantness.Length - 1; i++)
        {
            for (int j = i + 1; j < pleasantness.Length; j++)
            {
                int difference = Math.Abs(pleasantness[i] - pleasantness[j]);

                if (difference >= variety)
                {
                    int solvedTasksCount = (i + 1) / 2 + 1; // from 0 to i
                    solvedTasksCount += (j - i + 1) / 2; // from i to j
                    result = Math.Min(result, solvedTasksCount);
                }
            }
        }
        Console.WriteLine(result);
    }
}