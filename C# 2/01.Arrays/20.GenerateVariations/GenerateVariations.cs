using System;
//Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].
//Example: N = 3, K = 2 --> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

class GenerateVariations
{
    static int[] variation;
    static int variationPosition;

    static void PrintVariations(int numberOfUnusedElements, int total, int n)
    {
        //when there is no unused element, print the variation and we hit the bottom of the recursion
        if (numberOfUnusedElements == 0)
        {
            string variationOutput = string.Join(", ", variation);
            Console.WriteLine(variationOutput);
        }

        if (numberOfUnusedElements > 0)
        {

            for (int i = 1; i <= n; i++)
            {
                //varition[vavariationPosition] = i and then increase variation position
                //because we have got element on the previous position
                variation[variationPosition++] = i;
                //recursive call to the method with decreased numberOfUnusedElements because we have already
                //used one in the line above
                //we do this recursive call while we hit the bottom of the recursion
                PrintVariations(numberOfUnusedElements - 1, total, n);

                //when we have hitted the bottom of the recursion it mean variationPosition = k + 1
                //because we increase it every time, so we decrease its value with 1
                variationPosition--;
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());

        variation = new int[k];

        PrintVariations(k, k, n);
    }
}

