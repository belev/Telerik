namespace _01.CountOccurences
{
    using System;
    using System.Collections.Generic;

    public class CountOccurences
    {
        static void Main()
        {
            // var testArray = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            // testArray input
            // 9
            // 3
            // 4
            // 4
            // -2.5
            // 3
            // 3
            // 4
            // 3
            // -2.5

            Console.Write("Enter array length: ");
            int length = int.Parse(Console.ReadLine());

            var sequence = new double[length];
            var occurences = new Dictionary<double, int>();

            // count the occurences of all numbers when we initialize the array
            for (int i = 0; i < length; i++)
            {
                double curNumber = double.Parse(Console.ReadLine());
                sequence[i] = curNumber;

                // count occurences
                if (occurences.ContainsKey(curNumber))
                {
                    occurences[curNumber]++;
                }
                else
                {
                    occurences.Add(curNumber, 1);
                }
            }

            foreach (var pair in occurences)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
