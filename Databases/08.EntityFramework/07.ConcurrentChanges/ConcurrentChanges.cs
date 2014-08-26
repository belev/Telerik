namespace _07.ConcurrentChanges
{
    using System;
    using System.Linq;
    using Northwind.Models;

    public class ConcurrentChanges
    {
        public static void Main()
        {
            using (var firstDbContext = new NorthwindEntities())
            {
                var firstEmployeeFromFirstDbContext = firstDbContext.Employees.First();
                Console.WriteLine("First user see: {0}", firstEmployeeFromFirstDbContext.FirstName);
                firstEmployeeFromFirstDbContext.FirstName = "First";
                Console.WriteLine("First user changes the name with new value: {0}\n", firstEmployeeFromFirstDbContext.FirstName);

                firstDbContext.SaveChanges();

                using (var secondDbContext = new NorthwindEntities())
                {
                    var firstEmployeeFromSecondDbContext = secondDbContext.Employees.First();

                    Console.WriteLine("Second user see: {0}", firstEmployeeFromSecondDbContext.FirstName);
                    firstEmployeeFromSecondDbContext.FirstName = "Second";
                    Console.WriteLine("Second user changes the name with new value: {0}\n", firstEmployeeFromSecondDbContext.FirstName);

                    secondDbContext.SaveChanges();
                }

                Console.WriteLine("After all changes:");
                Console.WriteLine("First user see: {0}\n", firstEmployeeFromFirstDbContext.FirstName);
            }

            using (var northwindEntities = new NorthwindEntities())
            {
                Console.WriteLine("Actual result: {0}", northwindEntities.Employees.First().FirstName);
            }
        }
    }
}