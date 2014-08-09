namespace _01.KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KnapsackProblem
    {
        static void Main()
        {
            const int maxWeight = 10;
            var items = new Item[] 
            {
                new Item("whiskey", 8, 13),
                new Item("vodka", 8, 12),
                new Item("beer", 3, 2),
                new Item("cheese", 4, 5),
                new Item("ham", 2, 3),
                new Item("nuts", 1, 4),
            };

            // second test

            //const int maxWeight = 5;
            //var items = new Item[]
            //{
            //    new Item("water", 3, 5),
            //    new Item("chicken", 2, 3),
            //    new Item("pork", 1, 4)
            //};

            int[,] values = new int[items.Length + 1, maxWeight + 1];
            int[,] keep = new int[items.Length + 1, maxWeight + 1];

            for (int curItemIndex = 1; curItemIndex < items.Length + 1; curItemIndex++)
            {
                var item = items[curItemIndex - 1];

                for (int curPossibleWeight = 1; curPossibleWeight < maxWeight + 1; curPossibleWeight++)
                {
                    if (item.Weight > curPossibleWeight)
                    {
                        values[curItemIndex, curPossibleWeight] = values[curItemIndex - 1, curPossibleWeight];
                        continue;
                    }

                    int curMaxPossibleCost = values[curItemIndex - 1, curPossibleWeight];

                    int weightLeft = curPossibleWeight - item.Weight;
                    int upperCellLeftWeightCost = values[curItemIndex - 1, weightLeft];

                    int maxPossibleCost = upperCellLeftWeightCost + item.Cost;

                    if (curMaxPossibleCost < maxPossibleCost)
                    {
                        values[curItemIndex, curPossibleWeight] = maxPossibleCost;
                        keep[curItemIndex, curPossibleWeight] = 1;
                    }
                    else
                    {
                        values[curItemIndex, curPossibleWeight] = curMaxPossibleCost;
                    }
                }
            }

            var keptItems = new List<Item>();

            int keptItemIndex = items.Length;
            int leftWeight = maxWeight;

            while (keptItemIndex > 0)
            {
                if (keep[keptItemIndex, leftWeight] == 1)
                {
                    var keptItem = items[keptItemIndex - 1];

                    keptItems.Add(keptItem);

                    leftWeight -= keptItem.Weight;
                }

                keptItemIndex--;
            }

            int costSum = keptItems.Sum(x => x.Cost);
            int weightSum = keptItems.Sum(x => x.Weight);

            Console.WriteLine("Optimal cost: {0}", costSum);
            Console.WriteLine("Optimal weight: {0}", weightSum);
            Console.WriteLine("All used items: ");

            foreach (var item in keptItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}