using System;
//Write a program that finds the most frequent number in an array. Example:
//{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} - > 4 (5 times)

class FindMostFrequentNumber
{
    static void Main()
    {
        Console.Write("Enter length of the array: ");
        int length = int.Parse(Console.ReadLine());

        int[] array = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        bool[] used = new bool[length];

        int counter = -1;
        int element = 0;

        for (int i = 0; i < length - 1; i++)
        {
            //if we have been on that element continue to the next one
            if (used[i])
            {
                continue;
            }

            int currentElement = array[i];
            used[i] = true;

            int tmpCounter = 1;
            for (int j = i + 1; j < length; j++)
            {
                //if we have been on that element continue
                if (used[j])
                {
                    continue;
                }

                if (currentElement == array[j])
                {
                    tmpCounter++;
                    used[j] = true;
                }
            }

            if (tmpCounter > counter)
            {
                counter = tmpCounter;
                element = currentElement;
            }
        }
        Console.WriteLine("The most frequent element is {0} and it occures {1} time", element, counter);
    }
}

