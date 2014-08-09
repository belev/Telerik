namespace _12.MyStack
{
    using System;

    public class Tester
    {
        static void Main()
        {
            MyStack<int> stack = new MyStack<int>();

            // push some elements to test if work correctly
            stack.Push(5);
            stack.Push(10);
            stack.Push(15);
            stack.Push(80);
            stack.Push(-95);

            // test foreach
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Capacity);
            Console.WriteLine();

            // test pop
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine();

            // test contains method
            Console.WriteLine(stack.Contains(-95));
            Console.WriteLine(stack.Contains(10));
            Console.WriteLine();

            // test if count and capacity work correctly after pop elements
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Capacity);

            // test toArray and toString
            var stackAsArray = stack.ToArray();
            Console.WriteLine(string.Join(", ", stackAsArray));
            Console.WriteLine(stack.ToString());
        }
    }
}
