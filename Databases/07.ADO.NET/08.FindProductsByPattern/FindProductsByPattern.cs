namespace _08.FindProductsByPattern
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class FindProductsByPattern
    {
        public static void Main(string[] args)
        {
            // test case - gr
            // Product name -> Grandma's Boysenberry Spread
            // Product name -> Gravad lax
            // Product name -> Original Frankfurter grune So?e

            Console.Write("Please enter search string: ");
            var searchString = Console.ReadLine();

            var connection = new SqlConnection(Settings.Default.DbConnection);
            connection.Open();

            var command = new SqlCommand("SELECT ProductName From Products WHERE CHARINDEX(@searchString, ProductName) > 0", connection);
            command.Parameters.AddWithValue("@searchString", searchString);

            using (connection)
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productName = reader["ProductName"];

                        Console.WriteLine("Product name -> {0}", productName);
                    }
                }
            }
        }
    }
}