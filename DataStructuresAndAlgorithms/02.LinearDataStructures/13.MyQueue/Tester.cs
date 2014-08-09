namespace _13.MyQueue
{
    using System;
    using System.Collections.Generic;

    class Tester
    {
        static void Main(string[] args)
        {
            MyQueue<int> queue = new MyQueue<int>();

            queue.Enqueue(5);
            queue.Enqueue(15);
            queue.Enqueue(-9999);
            queue.Enqueue(11);
            queue.Enqueue(135);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Count);
            Console.WriteLine();

            Console.WriteLine(queue.ToString());
            Console.WriteLine();

            foreach (var elem in queue)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine();

            queue.Clear();

            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Dequeue());
        }
    }
}
