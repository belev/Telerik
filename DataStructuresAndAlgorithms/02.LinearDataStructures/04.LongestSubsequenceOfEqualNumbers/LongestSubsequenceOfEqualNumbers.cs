namespace _04.LongestSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestSubsequenceOfEqualNumbers
    {
        static List<int> InitializeSequence()
        {
            Console.Write("Enter length of sequence: ");
            int n = int.Parse(Console.ReadLine());

            List<int> sequence = new List<int>();

            for (int i = 0; i < n; i++)
            {
                sequence.Add(int.Parse(Console.ReadLine()));
            }

            return sequence;
        }

        static List<int> FindLongestSubsequenceOfEqualNumbers(List<int> sequence)
        {
            List<int> longestSubsequence = new List<int>();

            int maxLength = 0;
            int bestStartIndex = 0;

            int curLength = 1;
            int curStartIndex = 0;
            int curNumber = sequence[0];

            for (int i = 1; i < sequence.Count; i++)
            {
                if (curNumber == sequence[i])
                {
                    curLength++;
                }
                else
                {
                    if (maxLength < curLength)
                    {
                        maxLength = curLength;
                        bestStartIndex = curStartIndex;
                    }

                    curLength = 1;
                    curNumber = sequence[i];
                    curStartIndex = i;
                }
            }

            if (maxLength < curLength)
            {
                maxLength = curLength;
                bestStartIndex = curStartIndex;
            }

            for (int i = bestStartIndex; i < bestStartIndex + maxLength; i++)
            {
                longestSubsequence.Add(sequence[i]);
            }

            return longestSubsequence;
        }

        static void Test()
        {
            // longest subsequence is in the end
            List<int> testSequence1 = new List<int>() { 1, 1, 1, 2, 2, 2, 2, 5, 6, 7, 9, 9, 9, 9, 9 };

            // if there is two subsequences with equal length the first is returned
            List<int> testSequence2 = new List<int>() { 1, 1, 1, 2, 2, 2, 2, 5, 6, 7, 9, 9, 9, 9 };

            // longest subsequence is in the beginning
            List<int> testSequence3 = new List<int>() { 1, 1, 1, 1, 1, 2, 2, 2, 2, 5, 6, 7, 9 };

            // longest subsequence is in the middle
            List<int> testSequence4 = new List<int>() { 1, 1, 1, 2, 2, 5, 5, 5, 5, 5, 5, 6, 7, 9, 9, 9, 9, 9 };

            var result1 = FindLongestSubsequenceOfEqualNumbers(testSequence1);
            var result2 = FindLongestSubsequenceOfEqualNumbers(testSequence2);
            var result3 = FindLongestSubsequenceOfEqualNumbers(testSequence3);
            var result4 = FindLongestSubsequenceOfEqualNumbers(testSequence4);

            Console.WriteLine("Test sequence 1: {0}", string.Join(", ", testSequence1));
            Console.WriteLine("Test 1 longest subsequence : {0}", string.Join(", ", result1));
            Console.WriteLine();

            Console.WriteLine("Test sequence 2: {0}", string.Join(", ", testSequence2));
            Console.WriteLine("Test 2 longest subsequence : {0}", string.Join(", ", result2));
            Console.WriteLine();

            Console.WriteLine("Test sequence 3: {0}", string.Join(", ", testSequence3));
            Console.WriteLine("Test 3 longest subsequence : {0}", string.Join(", ", result3));
            Console.WriteLine();

            Console.WriteLine("Test sequence 4: {0}", string.Join(", ", testSequence4));
            Console.WriteLine("Test 4 longest subsequence : {0}", string.Join(", ", result4));
        }

        static void Main()
        {
            List<int> sequence = InitializeSequence();

            List<int> longestEqualSubsequence = FindLongestSubsequenceOfEqualNumbers(sequence);

            Console.WriteLine("Original sequence: {0}", string.Join(", ", sequence));
            Console.WriteLine("Longest equal subsequence: {0}", string.Join(", ", longestEqualSubsequence));

            // Test();
        }
    }
}
