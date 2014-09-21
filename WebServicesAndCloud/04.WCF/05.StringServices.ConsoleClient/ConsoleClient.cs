namespace _05.StringServices.ConsoleClient
{
    using System;
    using System.Linq;

    internal class ConsoleClient
    {
        private static void Main()
        {
            // Run the service and after that run the program
            var operations = new StringOperationsClient();
            var result = operations.GetSearchStringContainsCount("abc", "abc,abc,abc,dgrabc,abcaeg");

            Console.WriteLine(result);
        }
    }
}
