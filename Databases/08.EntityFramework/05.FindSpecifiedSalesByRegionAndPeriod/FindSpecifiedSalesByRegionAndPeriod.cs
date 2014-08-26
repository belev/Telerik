namespace _05.FindSpecifiedSalesByRegionAndPeriod
{
    using System;
    using System.Linq;
    using DataAccessObjectsUtils;


    public class FindSpecifiedSalesByRegionAndPeriod
    {
        public static void Main()
        {
            var shipRegion = "RJ";
            var startDate = new DateTime(1996, 1, 1);
            var endDate = new DateTime(1996, 12, 30);

            var searchedSales = DataAccessObjectsUtils.FindSpecifiedSalesByRegionAndPeriod(shipRegion, startDate, endDate);

            foreach (var sale in searchedSales)
            {
                Console.WriteLine("Ship name: {0}, address: {1}, country: {2}", sale.ShipName, sale.ShipAddress, sale.ShipCountry);
            }
        }
    }
}