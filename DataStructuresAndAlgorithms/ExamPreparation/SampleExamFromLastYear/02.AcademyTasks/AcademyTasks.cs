namespace _02.AcademyTasks
{
    using System;
    using System.Linq;

    internal class AcademyTasks
    {
        private static int minimumResult = int.MaxValue;

        private static void Main()
        {
            var pleasentnessNumbers = Console.ReadLine()
                                             .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(x => int.Parse(x))
                                             .ToArray();

            var varietyNumber = int.Parse(Console.ReadLine());

            FindMinimumSolvedProblems(varietyNumber, pleasentnessNumbers, 0);

            Console.WriteLine(minimumResult == int.MaxValue ? pleasentnessNumbers.Length : minimumResult);
        }

        private static void FindMinimumSolvedProblems(int variety, int[] pleasentnessNumbers, int startIndex)
        {
            var resultIndex = 0;

            var currentVarieties = new MinMaxPair[pleasentnessNumbers.Length];
            currentVarieties[startIndex] = new MinMaxPair()
            {
                MinElement = pleasentnessNumbers[startIndex],
                MaxElement = pleasentnessNumbers[startIndex]
            };

            for (int i = startIndex; i < pleasentnessNumbers.Length - 2; i++)
            {
                var nextElement = pleasentnessNumbers[i + 1];
                var nextNextElement = pleasentnessNumbers[i + 2];

                var nextPair = GetNextPair(currentVarieties[i], nextElement);
                var nextNextPair = GetNextPair(currentVarieties[i], nextNextElement);

                if (nextPair.Variety > nextNextPair.Variety)
                {
                    currentVarieties[i + 1] = nextPair;
                    resultIndex = i + 1;
                }
                else
                {
                    currentVarieties[i + 1] = nextNextPair;
                    resultIndex = i + 2;
                }

                if (currentVarieties[i + 1].Variety >= variety)
                {
                    minimumResult = Math.Min(minimumResult, ((resultIndex + 3) / 2));
                    break;
                }
            }
        }

        private static MinMaxPair GetNextPair(MinMaxPair pair, int element)
        {
            pair.MinElement = Math.Min(pair.MinElement, element);
            pair.MaxElement = Math.Max(pair.MaxElement, element);

            return new MinMaxPair()
            {
                MinElement = pair.MinElement,
                MaxElement = pair.MaxElement
            };
        }
    }

    struct MinMaxPair
    {
        public int MinElement { get; set; }

        public int MaxElement { get; set; }

        public int Variety
        {
            get
            {
                return this.MaxElement - this.MinElement;
            }
        }
    }
}