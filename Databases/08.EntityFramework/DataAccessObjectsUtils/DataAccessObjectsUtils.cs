namespace DataAccessObjectsUtils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Northwind.Models;

    public class DataAccessObjectsUtils
    {
        public static int InsertCustomer(
            string customerID,
            string companyName,
            string contactName = null,
            string city = null,
            string contactTitle = null,
            string address = null,
            string region = null,
            string postalCode = null,
            string country = null,
            string phone = null,
            string fax = null)
        {
            var newCustomer = new Customer
            {
                CustomerID = customerID,
                CompanyName = companyName,
                City = city,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax,
            };

            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Add(newCustomer);
                int affectedRows = dbContext.SaveChanges();

                return affectedRows;
            }
        }

        public static int ModifyCustomerCompanyName(string customerId, string newCompanyName)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var customer = dbContext.Customers.Find(customerId);
                customer.CompanyName = newCompanyName;
                int affectedRows = dbContext.SaveChanges();

                return affectedRows;
            }
        }

        public static int DeleteCustomer(string customerId)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var customer = dbContext.Customers.Find(customerId);
                dbContext.Customers.Remove(customer);
                int affectedRows = dbContext.SaveChanges();

                return affectedRows;
            }
        }

        // 03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        public static IEnumerable<IGrouping<string, Customer>> FindCustomersByOrderYearAndCountry(int orderYear, string country)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var targetedCustomers = dbContext.Orders
                                                 .Where(o => o.OrderDate.Value.Year == orderYear && o.ShipCountry == country)
                                                 .Select(o => o.Customer)
                                                 .GroupBy(c => c.ContactName)
                                                 .ToList();

                return targetedCustomers;
            }
        }

        // 04. Implement previous by using native SQL query and executing it through the DbContext.
        public static IEnumerable<string> FindCustomersByOrderYearAndCountryWithSqlQuery(int orderYear, string country)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var sqlQuery = @"SELECT c.ContactName
                                 FROM Customers c JOIN Orders o
                                 	ON c.CustomerID = o.CustomerID
                                 WHERE YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1}
                                 GROUP BY c.ContactName";

                var targetedCustomers = dbContext.Database.SqlQuery<string>(sqlQuery, new object[]
                {
                    orderYear,
                    country
                }).ToList();

                return targetedCustomers;
            }
        }

        // 05. Write a method that finds all the sales by specified region and period (start / end dates).
        public static IEnumerable<Order> FindSpecifiedSalesByRegionAndPeriod(string region, DateTime? startDate, DateTime? endDate)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var searchedSales = dbContext.Orders
                                             .Where(o => o.ShipRegion == region &&
                                                         o.OrderDate >= startDate &&
                                                         o.OrderDate <= endDate)
                                             .Select(o => o)
                                             .ToList();

                return searchedSales;
            }
        }
    }
}