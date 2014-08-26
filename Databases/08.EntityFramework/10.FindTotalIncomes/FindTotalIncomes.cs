namespace _10.FindTotalIncomes
{
    using System;
    using System.Linq;
    using Northwind.Models;

    public class FindTotalIncomes
    {
        public static void Main()
        {
            var supplierName = "Exotic Liquids";
            var startDate = new DateTime(1996, 1, 1);
            var endDate = new DateTime(2000, 12, 31);

            using (var northwindEntities = new NorthwindEntities())
            {
                var totalIncomes = northwindEntities.usp_FindTotalIncomesOfSupplier(supplierName, startDate, endDate).Single();

                Console.WriteLine("Total incomes: {0:C}", totalIncomes);
            }
        }
    }
}