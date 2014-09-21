namespace _04.Guitar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Guitar
    {
        private static int[] varieties;
        private static int startPower;
        private static int maxPower;

        private static void Main()
        {
            ReadInput();

            Solve();
        }

        private static void ReadInput()
        {
            Console.ReadLine();

            varieties = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            startPower = int.Parse(Console.ReadLine());
            maxPower = int.Parse(Console.ReadLine());
        }

        private static void Solve()
        {
            var values = new SortedSet<long>[varieties.Length + 1];

            for (int i = 0; i < varieties.Length + 1; i++)
            {
                values[i] = new SortedSet<long>();
            }

            values[0].Add(startPower);

            bool hasSolution = true;

            for (int i = 1; i <= varieties.Length; i++)
            {
                var curVariety = varieties[i - 1];

                foreach (var previousValue in values[i - 1])
                {
                    if (previousValue - curVariety >= 0)
                    {
                        values[i].Add(previousValue - curVariety);
                    }

                    if (previousValue + curVariety <= maxPower)
                    {
                        values[i].Add(previousValue + curVariety);
                    }
                }

                if (values[i].Count == 0)
                {
                    hasSolution = false;
                    break;
                }
            }

            if (hasSolution)
            {
                Console.WriteLine(values[varieties.Length].Last());
            }
            else
            {
                Console.WriteLine(-1);
            }
        }
    }
}
