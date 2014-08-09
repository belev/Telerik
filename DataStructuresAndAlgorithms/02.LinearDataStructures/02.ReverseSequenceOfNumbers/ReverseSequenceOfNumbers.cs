namespace _02.ReverseSequenceOfNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseSequenceOfNumbers
    {
        static void Main()
        {
            Console.Write("Enter sequence count numbers: ");
            int n = int.Parse(Console.ReadLine());

            Stack<int> sequence = new Stack<int>();

            Console.WriteLine("Enter {0} numbers:", n);
            for (int i = 0; i < n; i++)
            {
                sequence.Push(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine("Reversed sequence: {0}", string.Join(", ", sequence));
            Console.WriteLine("Original sequence: {0}", string.Join(", ", sequence.Reverse()));
        }
    }
}
