namespace GetCategoriesRowsCount
{
    using System;
    using System.Data.SqlClient;

    public class GetCategoriesRowsCount
    {
        public static void Main()
        {
            var connection = new SqlConnection(Settings.Default.DbConnection);
            connection.Open();

            using (connection)
            {
                var sqlCommand = new SqlCommand(@"SELECT COUNT(CategoryId)
                                                    FROM Categories", connection);
                int categoriesRowsCount = (int) sqlCommand.ExecuteScalar();

                Console.WriteLine("There are {0} rows in the table Categories.", categoriesRowsCount);
            }
        }
    }
}
