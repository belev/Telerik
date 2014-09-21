namespace _07.AcademyTasks
{
    using System;
    using System.Linq;

    internal class AcademyTasks
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var pleasentness = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int difference = int.Parse(Console.ReadLine());

            long result = pleasentness.Length;

            for (int i = 0; i < pleasentness.Length - 1; i++)
            {
                for (int j = i + 1; j < pleasentness.Length; j++)
                {
                    if (Math.Abs(pleasentness[i] - pleasentness[j]) < difference)
                    {
                        continue;
                    }

                    var tasksToI = (i + 3) / 2;
                    var tasksFromIToJ = (j - i + 1) / 2;
                    var allSolvedTasksCount = tasksToI + tasksFromIToJ;
                    result = Math.Min(result, allSolvedTasksCount);
                }
            }

            Console.WriteLine(result);
        }
    }
}
