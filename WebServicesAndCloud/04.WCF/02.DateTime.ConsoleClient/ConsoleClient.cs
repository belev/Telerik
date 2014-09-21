namespace DateTime.ConsoleClient
{
    using _02.DateTime.ConsoleClient.Operations;
    using System;
    using System.Linq;

    internal class ConsoleClient
    {
        private static void Main()
        {
            var client = new DateTimeOperationsClient();
            Console.WriteLine(client.GetDayOfWeekAsString(DateTime.Now));
        }
    }
}