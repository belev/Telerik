namespace _02.ExtractElementsWithOddOcurrence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtractElementsWithOddOcurrence
    {
        static void Main()
        {
            // test input
            // 6
            // C#
            // SQL
            // PHP
            // PHP
            // SQL
            // SQL

            Console.Write("Enter sequence length: ");
            int length = int.Parse(Console.ReadLine());

            var sequence = new List<string>();
            var occurences = new Dictionary<string, int>();

            for (int i = 0; i < length; i++)
            {
                string strToAdd = Console.ReadLine();

                sequence.Add(strToAdd);

                // fill dictionary
                if (occurences.ContainsKey(strToAdd))
                {
                    occurences[strToAdd]++;
                }
                else
                {
                    occurences.Add(strToAdd, 1);
                }
            }

            // get those elements which value % 2 == 1 (which occur odd number of time) and select the element itself (it key)
            var elementsWithOddOccurence = occurences.Where(str => str.Value % 2 == 1).Select(p => p.Key);

            Console.WriteLine("With odd occurence: {0}", string.Join(", ", elementsWithOddOccurence));
        }
    }
}
