namespace _01.CreateNorthwindEntities
{
    using System;
    using System.Linq;
    using Northwind.Models;

    public class CreateNorthwindEntities
    {
        public static void Main()
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                var customerNames = northwindEntities.Customers.Select(c => new
                {
                    Name = c.ContactName
                });

                foreach (var customer in customerNames)
                {
                    Console.WriteLine(customer.Name);
                }
            }
        }
    }
}