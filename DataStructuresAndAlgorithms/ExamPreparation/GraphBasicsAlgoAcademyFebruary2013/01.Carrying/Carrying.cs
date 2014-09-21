namespace _01.Carrying
{
    using System;
    using System.Linq;

    internal class Carrying
    {
        private static int maxBagCapacity;
        private static int[] roomsCapacities;

        private static void Main()
        {
            ReadInput();

            Console.WriteLine(FindMaxRooms());
        }

        private static void ReadInput()
        {
            maxBagCapacity = int.Parse(Console.ReadLine());
            Console.ReadLine();
            roomsCapacities = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        private static int FindMaxRooms()
        {
            int currentCapacity = 0;
            for (int i = 0; i < roomsCapacities.Length; i++)
            {
                currentCapacity += roomsCapacities[i];

                if (currentCapacity > maxBagCapacity)
                {
                    return i;
                }
            }

            return currentCapacity == 0 ? 0 : roomsCapacities.Length;
        }
    }
}
