namespace _10.MinOperationsSequence
{
    using System;
    using System.Collections.Generic;

    public class MinOperationsSequence
    {
        static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter m: ");
            int m = int.Parse(Console.ReadLine());

            SortedSet<int> operationsNumbers = new SortedSet<int>();
            operationsNumbers.Add(m);

            while (n != m)
            {
                if (2 * n <= m)
                {
                    if (m % 2 == 1)
                    {
                        // thats how we balance the partition of m and 2
                        // either way we will add only even numbers

                        // if there is remainder of m / 2
                        // decrease m and add it to operationsNumbers
                        operationsNumbers.Add(--m);
                    }

                    m /= 2;
                    operationsNumbers.Add(m);
                }
                else if (n + 2 <= m)
                {
                    m -= 2;
                    operationsNumbers.Add(m);
                }
                else if (n + 1 <= m)
                {
                    // decrease m and add it to operationsNumbers
                    operationsNumbers.Add(--m);
                }
            }

            Console.WriteLine(string.Join(", ", operationsNumbers));
        }
    }
}