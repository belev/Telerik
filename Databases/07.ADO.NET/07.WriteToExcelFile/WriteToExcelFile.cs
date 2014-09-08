namespace _07.WriteToExcelFile
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;

    public class WriteToExcelFile
    {
        public static void Main()
        {
            var connection = new OleDbConnection(Settings.Default.excelConnection);
            connection.Open();

            DataTable excelSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

            var fullName = "Pesho Kirkata";
            var score = 5;

            var command = new OleDbCommand("INSERT INTO [" + sheetName + "] VALUES (@fullName, @score)", connection);
            command.Parameters.AddWithValue("@fullName", fullName);
            command.Parameters.AddWithValue("@score", score);

            using (connection)
            {
                var result = command.ExecuteNonQuery();

               Console.WriteLine("({0} row(s) affected)", result); 
            }
        }
    }
}
