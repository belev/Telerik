namespace _02.CalculateStatistics
{
    using System;

    public class CalculateStatistics
    {
        public static void Main(string[] args)
        {
        }

        public void PrintStatistics(double[] sequence)
        {
            Console.WriteLine(FindMaxNumber(sequence));
            Console.WriteLine(FindMinNumber(sequence));
            Console.WriteLine(FindAverage(sequence));
        }

        private double FindMinNumber(double[] sequence)
        {
            double minNumber = sequence[0];

            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] < minNumber)
                {
                    minNumber = sequence[i];
                }
            }

            return minNumber;
        }

        private double FindMaxNumber(double[] sequence)
        {
            double maxNumber = sequence[0];

            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] > maxNumber)
                {
                    maxNumber = sequence[i];
                }
            }

            return maxNumber;
        }

        private double FindAverage(double[] sequence)
        {
            double sum = 0.0;

            for (int i = 0; i < sequence.Length; i++)
            {
                sum += sequence[i];
            }

            double average = sum / sequence.Length;

            return average;
        }
    }
}