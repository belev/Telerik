namespace SaveCategoriesImagesToHardDrive
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;

    public class SaveCategoriesImagesToHardDrive
    {
        private const int StreamStartIndex = 78;
        public static void Main()
        {
            var connection = new SqlConnection(Settings.Default.DbConnection);
            connection.Open();

            using (connection)
            {
                var sqlCommand = new SqlCommand("SELECT Picture FROM Categories", connection);

                using (var reader = sqlCommand.ExecuteReader())
                {
                    int imageId = 1;

                    while (reader.Read())
                    {
                        var imageAsByteArray = (byte[]) reader["Picture"];
                        SaveImageToHardDrive(imageId.ToString(), ".jpg", imageAsByteArray);
                        imageId++;
                    }
                }
            }
        }

        private static void SaveImageToHardDrive(string imageName, string format, byte[] imageAsByteArray)
        {
            var stream = new MemoryStream(imageAsByteArray, StreamStartIndex, imageAsByteArray.Length - StreamStartIndex);

            using (var convertedImage = new Bitmap(stream))
            {
                var fileName = imageName + format;

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                convertedImage.Save(fileName);
            }
        }
    }
}