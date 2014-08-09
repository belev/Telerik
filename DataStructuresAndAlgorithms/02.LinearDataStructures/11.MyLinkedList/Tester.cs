namespace _11.MyLinkedList
{
    using System;
    using System.Collections.Generic;

    class Tester
    {
        static void Main(string[] args)
        {
            MyLinkedList<string> list = new MyLinkedList<string>();

            list.AddLast("pesho");
            list.AddLast("gosho");
            list.AddLast("anna");
            list.Add(1, "mariq");
            list.AddFirst("ala bala");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            list.Remove("anna");
            list.RemoveFirst();
            list.RemoveLast();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            list.Clear();

            Console.WriteLine(list.Count);
        }
    }
}
