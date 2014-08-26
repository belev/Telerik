namespace _04.FindCustomersByOrderYearAndCountryWithSqlQuery
{
    using System;
    using System.Linq;
    using DataAccessObjectsUtils;

    public class FindCustomersByOrderYearAndCountryWithSqlQuery
    {
        public static void Main()
        {
            var orderYear = 1997;
            var country = "Canada";

            var searchedCustomers = DataAccessObjectsUtils.FindCustomersByOrderYearAndCountryWithSqlQuery(orderYear, country);

            foreach (var customerName in searchedCustomers)
            {
                Console.WriteLine(customerName);
            }
        }
    }
}
