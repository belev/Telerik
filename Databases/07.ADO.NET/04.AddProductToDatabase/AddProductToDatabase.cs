namespace AddProductToDatabase
{
    using System;
    using System.Data.SqlClient;

    public class AddProductToDatabase
    {
        public static void Main()
        {
            var connection = new SqlConnection(Settings.Default.DbConnection);
            connection.Open();

            var productName = "Jacobs Ice Coffee";
            var supplierId = 15;
            var categoryId = 1;
            var quantityPerUnit = "50 packages x 36 g";
            var unitPrice = 0.45d;
            var unitsInStock = 250;
            var unitsInOrder = 125;
            var reorderLevel = 45;
            var discontinued = 0;

            using (connection)
            {
                SqlCommand sqlCommand =
                new SqlCommand(@"INSERT INTO Products
                             VALUES (@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice, 
                                     @unitsInStock, @unitsInOrder, @reorderLevel, @discontinued)", connection);

                sqlCommand.Parameters.AddWithValue("@productName", productName);
                sqlCommand.Parameters.AddWithValue("@supplierId", supplierId);
                sqlCommand.Parameters.AddWithValue("@categoryId", categoryId);
                sqlCommand.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
                sqlCommand.Parameters.AddWithValue("@unitPrice", unitPrice);
                sqlCommand.Parameters.AddWithValue("@unitsInStock", unitsInStock);
                sqlCommand.Parameters.AddWithValue("@unitsInOrder", unitsInOrder);
                sqlCommand.Parameters.AddWithValue("@reorderLevel", reorderLevel);
                sqlCommand.Parameters.AddWithValue("@discontinued", discontinued);

                var queryResult = sqlCommand.ExecuteNonQuery();

                Console.WriteLine("({0} row(s) affected)", queryResult);
            }
        }
    }
}