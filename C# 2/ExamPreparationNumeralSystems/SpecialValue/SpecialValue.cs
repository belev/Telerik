using System;
using System.Collections.Generic;

class SpecialValue
{
    private static void SplitInputToJaggedArray(ref int[][] numbersAsJaggedArray, int i)
    {
        string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        numbersAsJaggedArray[i] = new int[input.Length];

        for (int j = 0; j < input.Length; j++)
        {
            int number = int.Parse(input[j]);

            numbersAsJaggedArray[i][j] = number;
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[][] numbersAsJaggedArray = new int[n][];

        for (int i = 0; i < n; i++)
        {
            SplitInputToJaggedArray(ref numbersAsJaggedArray, i);
        }

        int maxSpecialValue = -1;

        for (int i = 0; i < numbersAsJaggedArray[0].Length; i++)
        {
            bool[][] isVisited = new bool[n][];

            for (int j = 0; j < n; j++)
            {
                isVisited[j] = new bool[numbersAsJaggedArray[j].Length];
            }

            int tmpSpecialValue = 0;
            int currentCol = i;
            int currentRow = 0;

            while (true)
            {
                if (isVisited[currentRow][currentCol])
                {
                    break;
                }

                isVisited[currentRow][currentCol] = true;



                if (numbersAsJaggedArray[currentRow][currentCol] >= 0)
                {
                    currentCol = numbersAsJaggedArray[currentRow][currentCol];

                    if (currentRow < n - 1)
                    {
                        ++currentRow;
                    }

                    else
                    {
                        currentRow = 0;
                    }

                    ++tmpSpecialValue;

                    if (currentCol > numbersAsJaggedArray[currentRow].Length)
                    {
                        break;
                    }
                }

                else
                {
                    ++tmpSpecialValue;
                    tmpSpecialValue -= numbersAsJaggedArray[currentRow][currentCol];
                    break;
                }

                if (isVisited[currentRow][currentCol])
                {
                    tmpSpecialValue = -1;
                    break;
                }
            }

            if (tmpSpecialValue > maxSpecialValue)
            {
                maxSpecialValue = tmpSpecialValue;
            }
        }

        Console.WriteLine(maxSpecialValue);
    }
}
