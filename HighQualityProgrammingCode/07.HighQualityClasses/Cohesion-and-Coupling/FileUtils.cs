namespace CohesionAndCoupling
{
    using System;

    public static class FileUtils
    {
        public static string GetFileExtension(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("Path can not be null.");
            }

            int lastDotIndex = path.LastIndexOf(".");
            if (lastDotIndex == -1)
            {
                return string.Empty;
            }

            string extension = path.Substring(lastDotIndex + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("Path is null.");
            }

            int lastDotIndex = path.LastIndexOf(".");
            if (lastDotIndex == -1)
            {
                return path;
            }

            string fileNameWithoutExtension = path.Substring(0, lastDotIndex);
            return fileNameWithoutExtension;
        }
    }
}