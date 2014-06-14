namespace _03.MathFunctionsOperations
{
    using System;
    using System.Diagnostics;

    public class MathFunctionsOperationsTester
    {
        static Stopwatch watch;
        static void Main(string[] args)
        {
            watch = new Stopwatch();

            PrintLogPerformanceTests();
            Console.WriteLine();
            PrintSqrtPerformanceTests();
            Console.WriteLine();
            PrintSinPerformanceTests();
        }

        private static void PrintLogPerformanceTests()
        {
            watch.Start();
            LogTester.Log(1000M, 1500000);
            watch.Stop();
            Console.Write("Log decimal performance: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            LogTester.Log(1000.0, 1500000);
            watch.Stop();
            Console.Write("Log double performance: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            LogTester.Log(1000F, 1500000);
            watch.Stop();
            Console.Write("Log float performance: ");
            Console.WriteLine(watch.Elapsed);
        }

        private static void PrintSqrtPerformanceTests()
        {
            watch.Start();
            SqrtTester.Sqrt(1000M, 1500000);
            watch.Stop();
            Console.Write("Sqrt decimal performance: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            SqrtTester.Sqrt(1000.0, 1500000);
            watch.Stop();
            Console.Write("Sqrt double performance: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            SqrtTester.Sqrt(1000F, 1500000);
            watch.Stop();
            Console.Write("Sqrt float performance: ");
            Console.WriteLine(watch.Elapsed);
        }

        private static void PrintSinPerformanceTests()
        {
            watch.Start();
            SinTester.Sin(1000M, 1500000);
            watch.Stop();
            Console.Write("Sin decimal performance: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            SinTester.Sin(1000.0, 1500000);
            watch.Stop();
            Console.Write("Sin double performance: ");
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            SinTester.Sin(1000F, 1500000);
            watch.Stop();
            Console.Write("Sin float performance: ");
            Console.WriteLine(watch.Elapsed);
        }
    }
}
