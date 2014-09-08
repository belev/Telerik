namespace GetCategoriesNamesAndDescriptions
{
    using System;
    using System.Data.SqlClient;

    public class GetCategoriesNamesAndDescriptions
    {
        public static void Main()
        {
            var connection = new SqlConnection(Settings.Default.DbConnection);
            connection.Open();

            using (connection)
            {
                var sqlCommand = new SqlCommand(@"SELECT CategoryName, Description
                                                    FROM Categories", connection);

                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Category: {0} -> {1}", reader["CategoryName"], reader["Description"]);
                    }
                }
            }
        }
    }
}