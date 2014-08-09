namespace _01.SequenceSumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceSumAndAverage
    {
        static void Main()
        {
            List<int> sequence = new List<int>();

            Console.WriteLine("Enter sequence, for end of sequence press enter: ");

            int curNumber;
            while (int.TryParse(Console.ReadLine(), out curNumber) == true)
            {
                sequence.Add(curNumber);
            }

            long sum = sequence.Sum();
            double average = sequence.Average();

            Console.WriteLine("Sequence: {0}", string.Join(", ", sequence));
            Console.WriteLine("Sum: {0}", sum);
            Console.WriteLine("Average: {0}", average);
        }
    }
}
