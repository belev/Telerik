namespace _01.Tribonachi
{
    using System;
    using System.Linq;

    internal class Tribonachi
    {
        private static long[] sequence;
        private static int elementPosition;

        private static void Main()
        {
            ReadInput();
            Console.WriteLine(FindElementAtPosition(elementPosition));
        }

        private static void ReadInput()
        {
            var parsedInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            elementPosition = parsedInput[3];

            sequence = new long[elementPosition];
            sequence[0] = parsedInput[0];
            sequence[1] = parsedInput[1];
            sequence[2] = parsedInput[2];
        }

        private static long FindElementAtPosition(int elementPosition)
        {
            for (int i = 3; i < elementPosition; i++)
            {
                sequence[i] = sequence[i - 1] + sequence[i - 2] + sequence[i - 3];
            }

            return sequence[elementPosition - 1];
        }
    }
}
