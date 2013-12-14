using System;
//Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N].
//Example: N = 5, K = 2 --> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

class GenerateCombinations
{
    static int combinationPosition;
    static int[] combination;

    private static void PrintCombinations(int lastElement, int numberOfUnusedElements, int numberOfElementsInCombination, int n)
    {
        //bottom of the recursion
        if (numberOfUnusedElements == 0)
        {
            string combinationOutput = string.Join(", ", combination);

            Console.WriteLine(combinationOutput);
        }

        if (numberOfUnusedElements > 0)
        {
            for (int i = 1; i <= n; i++)
            {
                //to get combination, but not a variation we check if the last element is smaller than i
                //the same logic as the variation generation with the difference that we have one variable for the last element
                if (i > lastElement)
                {
                    combination[combinationPosition++] = i;

                    PrintCombinations(i, numberOfUnusedElements - 1, numberOfElementsInCombination, n);

                    combinationPosition--;
                }
            }
        }
    }
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());

        combination = new int[k];

        PrintCombinations(0, k, k, n);
    }
}

