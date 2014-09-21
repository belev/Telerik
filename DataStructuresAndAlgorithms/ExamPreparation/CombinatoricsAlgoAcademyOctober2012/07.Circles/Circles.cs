
namespace Circles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Circles
    {
        private static string colors;
        private static int resultCount;
        private static HashSet<string> forbiddenPermutations;

        private static void Main()
        {
            ReadInput();
            GetPermutations(0, colors.ToCharArray());

            Console.WriteLine(resultCount);
        }

        private static void ReadInput()
        {
            colors = Console.ReadLine();
            resultCount = 0;
            forbiddenPermutations = new HashSet<string>();
        }

        private static void GetPermutations(int index, char[] permutation)
        {
            if (index >= permutation.Length - 1)
            {
                var permutationAsString = new string(permutation);
                if (!forbiddenPermutations.Contains(permutationAsString))
                {
                    resultCount++;

                    GetAllForbiddenPermutations(permutation);
                    var reversedPermutation = permutation.Reverse().ToArray();
                    GetAllForbiddenPermutations(reversedPermutation);
                }

                return;
            }

            GetPermutations(index + 1, permutation);

            for (int i = index + 1; i < permutation.Length; i++)
            {
                if (permutation[index] != permutation[i])
                {
                    Swap(ref permutation[index], ref permutation[i]);
                    GetPermutations(index + 1, permutation);
                    Swap(ref permutation[index], ref permutation[i]);
                }
            }
        }

        private static void GetAllForbiddenPermutations(char[] permutation)
        {
            forbiddenPermutations.Add(new string(permutation));
            var permutationLength = permutation.Length;

            char[] forbiddenPermutation = new char[permutationLength];
            for (int i = 1; i < permutationLength; i++)
            {
                for (int j = 0; j < permutationLength; j++)
                {
                    forbiddenPermutation[j] = permutation[(j + i) % permutationLength];
                }

                forbiddenPermutations.Add(new string(forbiddenPermutation));
            }
        }

        private static void Swap(ref char first, ref char second)
        {
            char old = first;
            first = second;
            second = old;
        }
    }
}