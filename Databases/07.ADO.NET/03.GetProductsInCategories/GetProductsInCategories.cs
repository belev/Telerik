namespace GetProductsInCategories
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class GetProductsInCategories
    {
        public static void Main()
        {
            var connection = new SqlConnection(Settings.Default.DbConnection);
            connection.Open();

            using (connection)
            {
                var sqlCommand = new SqlCommand(@"SELECT c.CategoryName, p.ProductName
                                                    FROM Categories c JOIN Products p
                                                    ON c.CategoryID = p.CategoryID
                                                    ORDER BY c.CategoryID", connection);

                var productsInCategories = new Dictionary<string, ISet<string>>();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var categoryName = (string) reader["CategoryName"];
                        var productName = (string) reader["ProductName"];

                        if (!productsInCategories.ContainsKey(categoryName))
                        {
                            productsInCategories[categoryName] = new HashSet<string>();
                        }

                        productsInCategories[categoryName].Add(productName);
                    }
                }

                PrintProductsInCategories(productsInCategories);
            }
        }

        private static void PrintProductsInCategories(IDictionary<string, ISet<string>> productsInCategories)
        {
            foreach (var category in productsInCategories)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Category name: {0}", category.Key);
                Console.ResetColor();

                foreach (var productName in category.Value)
                {
                    Console.WriteLine("    - {0}", productName);
                }

                Console.WriteLine();
            }
        }
    }
}
