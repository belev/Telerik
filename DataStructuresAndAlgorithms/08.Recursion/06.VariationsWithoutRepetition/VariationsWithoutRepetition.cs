namespace _06.VariationsWithoutRepetition
{
    using System;

    public class VariationsWithoutRepetition
    {
        private static void PrintGeneratedVariation(string[] strings, string[] currentVariation, int indexInCurVariation, int indexInStrings)
        {
            if (indexInCurVariation == currentVariation.Length)
            {
                Console.WriteLine(string.Join(" ", currentVariation));
                return;
            }

            for (int i = indexInStrings; i < strings.Length; i++)
            {
                currentVariation[indexInCurVariation] = strings[i];
                PrintGeneratedVariation(strings, currentVariation, indexInCurVariation + 1, i + 1);
            }
        }

        static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter k: ");
            int k = int.Parse(Console.ReadLine());

            string[] strings = new string[n];
            for (int i = 0; i < n; i++)
            {
                strings[i] = Console.ReadLine();
            }

            PrintGeneratedVariation(strings, new string[k], 0, 0);
        }
    }
}
