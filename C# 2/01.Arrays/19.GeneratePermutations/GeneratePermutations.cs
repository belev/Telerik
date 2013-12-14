using System;

class GeneratePermutations
{
    //we use ref to change the values which we give to the method
    private static void Swap(ref int a, ref int b)
    {
        int tmp = a;
        a = b;
        b = tmp;
    }
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = i + 1;

            //print the first permutation
            Console.Write(array[i]);

            if (i != n - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();

        int indexOfLastSmallerElement = 0;

        while (true)
        {
            bool hasIndex = false;

            //find the index of the last element which is smaller than next element
            for (int i = 0; i < n - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    hasIndex = true;
                    indexOfLastSmallerElement = i;
                }
            }

            //when we could not find indexOfLastSmallerElement, it means that this was the last permutation printed on the console
            //and we break the loop
            if (hasIndex == false)
            {
                break;
            }

            //find the last element which is greater than array[indexOfLastSmallerElement]
            int maximalIndexOfLargerElement = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[indexOfLastSmallerElement] < array[i])
                {
                    maximalIndexOfLargerElement = i;
                }
            }

            //swap their values
            Swap(ref array[indexOfLastSmallerElement], ref array[maximalIndexOfLargerElement]);

            //revers the permutation after the element with index = indexOfLastSmallerElement
            //to get the next permutation in increasing order
            Array.Reverse(array, indexOfLastSmallerElement + 1, n - 1 - indexOfLastSmallerElement);

            string permutationOutput = string.Join(", ", array);
            Console.WriteLine(permutationOutput);
        }
    }
}

