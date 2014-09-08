namespace _02.DictionaryUsingRedisDb
{
    using System.Text;

    public static class StringExtensions
    {
        public static byte[] ConvertStringToByteArr(this string stringToConvert)
        {
            byte[] result = new byte[stringToConvert.Length];

            for (int i = 0; i < stringToConvert.Length; i++)
            {
                result[i] = (byte) (((int) stringToConvert[i]) % 256);
            }

            return result;
        }

        public static string ConvertByteArrToString(this byte[] arr)
        {
            StringBuilder result = new StringBuilder(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                result.Append((char) arr[i]);
            }

            return result.ToString();
        }
    }
}