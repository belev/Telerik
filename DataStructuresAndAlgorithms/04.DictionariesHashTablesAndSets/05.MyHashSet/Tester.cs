namespace _05.MyHashSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tester
    {
        static void Main(string[] args)
        {
            var set = new MyHashSet<int>();

            set.Add(5);
            set.Add(19);
            set.Add(1513513);
            set.Add(4464);
            Console.WriteLine("Count: {0}", set.Count);


            var anotherSet = new MyHashSet<int>();

            anotherSet.Add(-5);
            anotherSet.Add(19);
            anotherSet.Add(1513513);
            anotherSet.Add(-111);

            set.Union(anotherSet);
            Console.WriteLine("Elements after union: {0}", string.Join(", ", set.Elements()));

            // count gives back as a result 5 because 5 and -5 have got equal hash codes
            Console.WriteLine("Count: {0}", set.Count);

            set.Intersect(anotherSet);
            Console.WriteLine("Elements after intersect: {0}", string.Join(", ", set.Elements()));

            Console.WriteLine("Contains value: {0} -> {1}", 4464, set.Contains(4464));
            Console.WriteLine("Contains value: {0} -> {1}", 4, set.Contains(4));
            Console.WriteLine("Count: {0}", set.Count);

            anotherSet.Clear();
            Console.WriteLine("Another set elements: {0}", string.Join(", ", anotherSet.Elements()));
            // if we add one value more than once exception is thrown because it is not valid in hash set
            // set.Add(5);
        }
    }
}
