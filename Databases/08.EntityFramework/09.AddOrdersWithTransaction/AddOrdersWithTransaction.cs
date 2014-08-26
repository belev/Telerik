namespace _09.AddOrdersWithTransaction
{
    using System;
    using System.Linq;
    using Northwind.Models;

    public class AddOrdersWithTransaction
    {
        public static void Main()
        {
            Console.WriteLine("({0} affected row(s))\n", TestWithTransaction());

            Console.WriteLine("({0} affected row(s))", TestWithSaveChanges());
        }

        private static int TestWithTransaction()
        {
            var affectedRows = 0;
            var customerId = "RATTC";
            var employeeId = 5;

            var invalidEmployeeId = 5000;

            using (var dbContext = new NorthwindEntities())
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        // To test with invalid data and see what happens, change employeeId with invalidEmployeeId
                        // then the transaction will rollback and there will be no added orders
                        var firstOrder = new Order()
                        {
                            CustomerID = customerId,
                            EmployeeID = employeeId
                        };

                        dbContext.Orders.Add(firstOrder);

                        var secondOrder = new Order()
                        {
                            CustomerID = customerId,
                            EmployeeID = employeeId
                        };

                        dbContext.Orders.Add(secondOrder);

                        affectedRows = dbContext.SaveChanges();

                        transaction.Commit();

                        Console.WriteLine("- Finish successfully => Commit transaction");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        Console.WriteLine("- Exception: Finish Unsuccessfully => Rollback transaction");
                    }
                }
            }

            return affectedRows;
        }

        /// <summary>
        /// Entity framework by default works with transactions, so it is not neccessary to explicity use transaction
        /// You can use only save changes and if an error occurs the entity framework will rollback and nothing will happen to the database
        /// </summary>
        /// <returns>The number of affected rows</returns>
        private static int TestWithSaveChanges()
        {
            var affectedRows = 0;
            var customerId = "RATTC";
            var employeeId = 6;

            var invalidEmployeeId = 5000;

            using (var dbContext = new NorthwindEntities())
            {
                try
                {
                    // To test with invalid data and see what happens, change employeeId with invalidEmployeeId
                    // then the transaction will rollback and there will be no added orders
                    var firstOrder = new Order()
                    {
                        CustomerID = customerId,
                        EmployeeID = employeeId
                    };

                    dbContext.Orders.Add(firstOrder);

                    var secondOrder = new Order()
                    {
                        CustomerID = customerId,
                        EmployeeID = employeeId
                    };

                    dbContext.Orders.Add(secondOrder);

                    affectedRows = dbContext.SaveChanges();

                    Console.WriteLine("- Finish successfully => Commit transaction");
                }
                catch (Exception)
                {
                    Console.WriteLine("- Exception: Finish Unsuccessfully => Rollback transaction");
                }
            }

            return affectedRows;
        }
    }
}