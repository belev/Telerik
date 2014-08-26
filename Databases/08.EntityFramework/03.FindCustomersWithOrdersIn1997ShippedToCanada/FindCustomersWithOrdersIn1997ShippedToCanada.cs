namespace _03.FindCustomersWithOrdersIn1997ShippedToCanada
{
    using System;
    using System.Linq;
    using DataAccessObjectsUtils;

    public class FindCustomersWithOrdersIn1997ShippedToCanada
    {
        public static void Main()
        {
            var orderYear = 1997;
            var country = "Canada";

            var searchedCustomers = DataAccessObjectsUtils.FindCustomersByOrderYearAndCountry(orderYear, country);

            foreach (var customer in searchedCustomers)
            {
                Console.WriteLine(customer.Key);
            }
        }
    }
}
