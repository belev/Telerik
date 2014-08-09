namespace _01.PriorityQueue
{
    using System;
    using System.Collections;

    public class Tester
    {
        private static void Print(IEnumerable collection)
        {
            foreach (var elem in collection)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("-------------------------");
        }

        static void Main()
        {
            // example structure as binary heap
            // -4444 parent root at the beginning with children -5 and 1
            // -5 with children 5 and 50, 1 with children 4 and 8
            // 5 with children 999 and 19
            //                                   -4444
            //                                -5        1
            //                             5      50    4  8
            //                         999   19                     

            PriorityQueue<int> queue = new PriorityQueue<int>();

            queue.Enqueue(5);
            queue.Enqueue(19);
            queue.Enqueue(-4444);
            queue.Enqueue(1);
            queue.Enqueue(50);
            queue.Enqueue(4);
            queue.Enqueue(8);
            queue.Enqueue(999);
            queue.Enqueue(-5);

            Print(queue);


            Console.WriteLine(queue.Dequeue());

            // all are for testing
            // Console.WriteLine();
            // Print(queue);

            Console.WriteLine(queue.Dequeue());

            // Console.WriteLine();
            // Print(queue);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine("----------------");

            // Console.WriteLine();
            // Print(queue);

            Console.WriteLine("Peek: " + queue.Peek());

            Console.WriteLine(queue.Count);

            queue.Clear();

            Console.WriteLine(queue.Count);
        }
    }
}
