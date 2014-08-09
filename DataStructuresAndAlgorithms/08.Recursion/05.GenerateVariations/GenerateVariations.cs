namespace _05.GenerateVariations
{
    using System;

    public class GenerateVariations
    {
        private static void PrintGeneratedVariation(string[] strings, string[] currentVariation, int position)
        {
            if (position == currentVariation.Length)
            {
                Console.WriteLine(string.Join(" ", currentVariation));
                return;
            }

            for (int i = 0; i < strings.Length; i++)
            {
                currentVariation[position] = strings[i];
                PrintGeneratedVariation(strings, currentVariation, position + 1);
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

            PrintGeneratedVariation(strings, new string[k], 0);
        }
    }
}
