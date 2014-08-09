namespace _01.RecursiveNestedLoops
{
    using System;

    public class RecursiveNestedLoops
    {
        private static void PrintRecursiveNestedLoops(int[] currentLoop, int position)
        {
            if (position == currentLoop.Length)
            {
                Console.WriteLine(string.Join(" ", currentLoop));
                return;
            }

            for (currentLoop[position] = 1; currentLoop[position] <= currentLoop.Length; currentLoop[position]++)
            {
                PrintRecursiveNestedLoops(currentLoop, position + 1);
            }
        }

        static void Main()
        {
            Console.Write("Enter how many nested loops do you want to have: ");
            int length = int.Parse(Console.ReadLine());

            int[] currentLoop = new int[length];

            PrintRecursiveNestedLoops(currentLoop, 0);
        }
    }
}