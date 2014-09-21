namespace _01.Frames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Frames
    {
        private static int n;
        private static SortedDictionary<string, int> possiblePermutations;
        private static List<string> possiblePermutationsKeys;
        private static HashSet<string> result;

        static void Main()
        {
            ReadInput();

            Solve(0, new string[n]);

            Console.WriteLine(result.Count);
            foreach (var permutation in result)
            {
                Console.WriteLine(permutation);
            }
        }

        private static void ReadInput()
        {
            possiblePermutations = new SortedDictionary<string, int>();
            possiblePermutationsKeys = new List<string>();
            result = new HashSet<string>();

            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                AddLine(line);


                if (IsReversedLineDifferent(line))
                {
                    var reversedLine = ReverseLine(line);
                    AddLine(reversedLine);
                }
            }

            possiblePermutationsKeys.Sort();
        }

        private static void AddLine(string line)
        {
            if (possiblePermutations.ContainsKey(line))
            {
                possiblePermutations[line]++;
            }
            else
            {
                possiblePermutations.Add(line, 1);
                possiblePermutationsKeys.Add(line);
            }
        }

        private static bool IsReversedLineDifferent(string line)
        {
            var reversedLine = ReverseLine(line);
            return (reversedLine != line);
        }

        private static string ReverseLine(string line)
        {
            char[] charArray = line.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        private static void Solve(int index, string[] permutation)
        {
            if (index == n)
            {
                result.Add(string.Join(" | ", permutation));
                return;
            }

            for (int i = 0; i < possiblePermutationsKeys.Count; i++)
            {
                var key = possiblePermutationsKeys[i];
                var reversedKey = ReverseLine(key);

                if (possiblePermutations[key] > 0)
                {
                    permutation[index] = "(" + key[0] + ", " + key[2] + ")";
                    possiblePermutations[key]--;

                    if (reversedKey != key)
                    {
                        possiblePermutations[reversedKey]--;
                    }

                    Solve(index + 1, permutation);
                    possiblePermutations[key]++;

                    if (reversedKey != key)
                    {
                        possiblePermutations[reversedKey]++;
                    }
                }
            }
        }
    }
}