namespace _02.SimpleMathOperations
{
    using System;
    using System.Diagnostics;

    public class SimpleMathOperationsTester
    {
        static Stopwatch watch;
        static void Main(string[] args)
        {
            watch = new Stopwatch();

            PrintIncrementPerformanceTests();
            Console.WriteLine();
            PrintAdditionPerformanceTests();
            Console.WriteLine();
            PrintSubtractionPerformanceTests();
            Console.WriteLine();
            PrintDivisionPerformanceTests();
            Console.WriteLine();
            PrintMultiplicationPerformanceTests();
        }

        public static void PrintIncrementPerformanceTests()
        {
            watch.Start();
            IncrementTester.Increment(0, 1000000);
            watch.Stop();
            Console.Write("Increment by int: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            IncrementTester.Increment(0.0, 1000000.0);
            watch.Stop();
            Console.Write("Increment by double: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            IncrementTester.Increment(0F, 1000000F);
            watch.Stop();
            Console.Write("Increment by float: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            IncrementTester.Increment(0M, 1000000M);
            watch.Stop();
            Console.Write("Increment by decimal: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            IncrementTester.Increment(0L, 1000000L);
            watch.Stop();
            Console.Write("Increment by long: ");
            Console.WriteLine(watch.Elapsed);
        }

        public static void PrintAdditionPerformanceTests()
        {
            watch.Start();
            AdditionTester.Add(0, 1000000, 2);
            watch.Stop();
            Console.Write("Addition by int: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            AdditionTester.Add(0.0, 1000000.0, 2.0);
            watch.Stop();
            Console.Write("Addition by double: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            AdditionTester.Add(0F, 1000000F, 2F);
            watch.Stop();
            Console.Write("Addition by float: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            AdditionTester.Add(0M, 1000000M, 2M);
            watch.Stop();
            Console.Write("Addition by decimal: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            AdditionTester.Add(0L, 1000000L, 2L);
            watch.Stop();
            Console.Write("Addition by long: ");
            Console.WriteLine(watch.Elapsed);
        }

        public static void PrintSubtractionPerformanceTests()
        {
            watch.Start();
            SubtractionTester.Subtract(0, 1000000, 2);
            watch.Stop();
            Console.Write("Subtraction by int: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            SubtractionTester.Subtract(0.0, 1000000.0, 2.0);
            watch.Stop();
            Console.Write("Subtraction by double: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            SubtractionTester.Subtract(0F, 1000000F, 2F);
            watch.Stop();
            Console.Write("Subtraction by float: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            SubtractionTester.Subtract(0M, 1000000M, 2M);
            watch.Stop();
            Console.Write("Subtraction by decimal: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            SubtractionTester.Subtract(0L, 1000000L, 2L);
            watch.Stop();
            Console.Write("Subtraction by long: ");
            Console.WriteLine(watch.Elapsed);
        }

        public static void PrintDivisionPerformanceTests()
        {
            watch.Start();
            DivisionTester.Divide(0, 1000000, 2);
            watch.Stop();
            Console.Write("Division by int: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            DivisionTester.Divide(0.0, 1000000.0, 2.0);
            watch.Stop();
            Console.Write("Division by double: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            DivisionTester.Divide(0F, 1000000F, 2F);
            watch.Stop();
            Console.Write("Division by float: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            DivisionTester.Divide(0M, 1000000M, 2M);
            watch.Stop();
            Console.Write("Division by decimal: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            DivisionTester.Divide(0L, 1000000L, 2L);
            watch.Stop();
            Console.Write("Division by long: ");
            Console.WriteLine(watch.Elapsed);
        }

        public static void PrintMultiplicationPerformanceTests()
        {
            watch.Start();
            MultiplicationTester.Multiply(0, 1000000, 1);
            watch.Stop();
            Console.Write("Multiplication by int: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            MultiplicationTester.Multiply(0.0, 1000000.0, 1.0);
            watch.Stop();
            Console.Write("Multiplication by double: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            MultiplicationTester.Multiply(0F, 1000000F, 1F);
            watch.Stop();
            Console.Write("Multiplication by float: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            MultiplicationTester.Multiply(0M, 1000000M, 1M);
            watch.Stop();
            Console.Write("Multiplication by decimal: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            MultiplicationTester.Multiply(0L, 1000000L, 1L);
            watch.Stop();
            Console.Write("Multiplication by long: ");
            Console.WriteLine(watch.Elapsed);
        }
    }
}
