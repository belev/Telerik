namespace _04.HashTable
{
    using System;

    class Tester
    {
        static void Main(string[] args)
        {
            HashTable<int, int> table = new HashTable<int, int>(12);

            // add more than 75% of the capacity to test if resize work correctly
            table.Add(5, 15);
            table.Add(0, 29);
            table.Add(5, -5);
            table.Add(1, 9);
            table.Add(5, 1);
            table.Add(10, 0);
            table.Add(55, 100);
            table.Add(3, 222);
            table.Add(13, 25);
            table.Add(7, 8);
            table.Add(11, 6);
            table.Add(13, 134);
            table.Add(2, 555);
            table.Add(4, 11);
            table.Add(66, -999);

            Console.WriteLine("Count: {0}", table.Count);
            Console.WriteLine("All elements count: {0}", table.AllElementsCount);

            int value = table.Find(0);
            Console.WriteLine(value);

            table.Remove(5);
            value = table.Find(5);
            Console.WriteLine(value);

            table.Remove(2);

            Console.WriteLine("Count: {0}", table.Count);
            Console.WriteLine("All elements count: {0}", table.AllElementsCount);

            var keys = table.Keys;
            Console.WriteLine("Keys: {0}", string.Join(", ", keys));

            Console.WriteLine("Indexer test: {0}", table[4]);
        }
    }
}
