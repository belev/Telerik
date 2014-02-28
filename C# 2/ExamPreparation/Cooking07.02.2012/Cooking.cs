using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;

class Cooking
{
    private static Dictionary<string, decimal> unitsToCups = new Dictionary<string, decimal>();
    private static Dictionary<string, decimal> unitsFromCups = new Dictionary<string, decimal>();

    //to convert from one unit to cups
    private static void FillUnitsToCups()
    {
        unitsToCups.Add("cups", 1m);
        unitsToCups.Add("pints", 2m);
        unitsToCups.Add("pts", 2m);
        unitsToCups.Add("quarts", 4m);
        unitsToCups.Add("qts", 4m);
        unitsToCups.Add("gallons", 16m);
        unitsToCups.Add("gals", 16m);
        unitsToCups.Add("teaspoons", 1 / 48m);
        unitsToCups.Add("tsps", 1 / 48m);
        unitsToCups.Add("tablespoons", 1 / 16m);
        unitsToCups.Add("tbsps", 1 / 16m);
        unitsToCups.Add("liters", 25m / 6m);
        unitsToCups.Add("ls", 25m / 6m);
        unitsToCups.Add("milliliters", 1m / 240m);
        unitsToCups.Add("mls", 1m / 240m);
        unitsToCups.Add("fluid ounces", 1m / 8m);
        unitsToCups.Add("fl ozs", 1m / 8m);
    }
    private static void FillUnitsFromCups()
    {
        unitsFromCups.Add("cups", 1m);
        unitsFromCups.Add("pints", 1m / 2m);
        unitsFromCups.Add("pts", 1m / 2m);
        unitsFromCups.Add("quarts", 1m / 4m);
        unitsFromCups.Add("qts", 1m / 4m);
        unitsFromCups.Add("gallons", 1m / 16m);
        unitsFromCups.Add("gals", 1m / 16m);
        unitsFromCups.Add("teaspoons", 48m);
        unitsFromCups.Add("tsps", 48m);
        unitsFromCups.Add("tablespoons", 16m);
        unitsFromCups.Add("tbsps", 16m);
        unitsFromCups.Add("liters", 6m / 25m);
        unitsFromCups.Add("ls", 6m / 25m);
        unitsFromCups.Add("milliliters", 240m);
        unitsFromCups.Add("mls", 240m);
        unitsFromCups.Add("fluid ounces", 8m);
        unitsFromCups.Add("fl ozs", 8m);
    }
    private static decimal ConvertToCups(decimal unitValue, string unitName)
    {
        return (unitValue * unitsToCups[unitName]);
    }
    private static decimal ConvertFromCups(decimal valueAsCups, string unitName)
    {
        return (valueAsCups * unitsFromCups[unitName]);
    }
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        FillUnitsToCups();
        FillUnitsFromCups();

        int n = int.Parse(Console.ReadLine());

        Dictionary<string, string> originalRecipeProduct = new Dictionary<string, string>();
        Dictionary<string, decimal> productsQuantity = new Dictionary<string, decimal>();

        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(':');
            decimal value = decimal.Parse(line[0]);
            string unit = line[1];
            string product = line[2];

            if (productsQuantity.ContainsKey(product.ToLower()) == false)
            {
                originalRecipeProduct.Add(product, unit);
                productsQuantity.Add(product.ToLower(), ConvertToCups(value, unit));
            }
            else
            {
                productsQuantity[product.ToLower()] += ConvertToCups(value, unit);
            }
        }

        int m = int.Parse(Console.ReadLine());

        for (int i = 0; i < m; i++)
        {
            string[] line = Console.ReadLine().Split(':');

            decimal value = decimal.Parse(line[0]);
            string unit = line[1];
            string product = line[2];

            if (productsQuantity.ContainsKey(product.ToLower()))
            {
                productsQuantity[product.ToLower()] -= ConvertToCups(value, unit);
            }
        }

        foreach (var pair in originalRecipeProduct)
        {
            if (productsQuantity.ContainsKey(pair.Key.ToLower()))
            {
                if (productsQuantity[pair.Key.ToLower()] > 0)
                {
                    decimal originalQuantity = ConvertFromCups(productsQuantity[pair.Key.ToLower()], pair.Value);
                    Console.WriteLine("{0:F2}:{1}:{2}", originalQuantity, pair.Value, pair.Key);
                }
            }
        }
    }
}

