namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contains extension methods for the <see cref="System.String"/> class
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the Md5 hash of a string
        /// </summary>
        /// <param name="input">The string whose hash will be calculated</param>
        /// <returns>The hexadecimal hash of the string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Check the input string if can be interpreted as <see cref="System.Boolean"/>
        /// </summary>
        /// <param name="input">The input string that will be checked</param>
        /// <returns>True if the input can be interpreted as <see cref="System.Boolean"/>, either returns false</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[]
            {
                "true",
                "ok",
                "yes",
                "1",
                "да"
            };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the input string to <see cref="System.Int16"/>.
        /// </summary>
        /// <param name="input">The input string that will be converted to <see cref="System.Int16"/>.</param>
        /// <returns>The input string value converted to <see cref="System.Int16"/>.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the input string to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="input">The input string that will be converted to <see cref="System.Int32"/>.</param>
        /// <returns>The string value converted to <see cref="System.Int32"/>.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the input string to <see cref="System.Int64"/>.
        /// </summary>
        /// <param name="input">The input string that will be converted to <see cref="System.Int64"/>.</param>
        /// <returns>The input string value converted to <see cref="System.Int64"/>.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the input string to <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="input">The input string that will be converted to <see cref="System.DateTime"/>.</param>
        /// <returns>The input string value converted to <see cref="System.DateTime"/>.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Convert first letter to upper case
        /// </summary>
        /// <param name="input">The string whose first letter will be converted to upper case</param>
        /// <returns>The input string with converted first letter to upper case</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns a substring which is between <paramref name="startString"/>
        /// and <paramref name="endString"/> and searching starts from <paramref name="startFrom"/> index.
        /// </summary>
        /// <param name="input">The input string in which the search will be done</param>
        /// <param name="startString">The string which is left bound of the result string</param>
        /// <param name="endString">The string which is rigth bound of the result string</param>
        /// <param name="startFrom">The start position of the search</param>
        /// <returns>A string equivalent to the substring which is between <paramref name="startString"/>
        /// and <paramref name="endString"/> searching from <paramref name="startFrom"/> or System.String.Empty 
        /// if <paramref name="startString"/> or <paramref name="endString"/> don't occur within this instance.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Convert all cyrillic letters to latin letters
        /// </summary>
        /// <param name="input">The input string in which the conversion from cyrillic letters to latin letters will be performed</param>
        /// <returns>A string in which all cyrillic letters are converted to their interpretation as latin letters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
            {
                "а",
                "б",
                "в",
                "г",
                "д",
                "е",
                "ж",
                "з",
                "и",
                "й",
                "к",
                "л",
                "м",
                "н",
                "о",
                "п",
                "р",
                "с",
                "т",
                "у",
                "ф",
                "х",
                "ц",
                "ч",
                "ш",
                "щ",
                "ъ",
                "ь",
                "ю",
                "я"
            };
            var latinRepresentationsOfBulgarianLetters = new[]
            {
                "a",
                "b",
                "v",
                "g",
                "d",
                "e",
                "j",
                "z",
                "i",
                "y",
                "k",
                "l",
                "m",
                "n",
                "o",
                "p",
                "r",
                "s",
                "t",
                "u",
                "f",
                "h",
                "c",
                "ch",
                "sh",
                "sht",
                "u",
                "i",
                "yu",
                "ya"
            };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Convert all latin letters to cyrillic letters
        /// </summary>
        /// <param name="input">The input string in which the conversion from latin letters to cyrillic letters will be performed</param>
        /// <returns>A string in which all latin letters are converted to their interpretation as cyrillic letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g",
                "h",
                "i",
                "j",
                "k",
                "l",
                "m",
                "n",
                "o",
                "p",
                "q",
                "r",
                "s",
                "t",
                "u",
                "v",
                "w",
                "x",
                "y",
                "z"
            };

            var bulgarianRepresentationOfLatinKeyboard = new[]
            {
                "а",
                "б",
                "ц",
                "д",
                "е",
                "ф",
                "г",
                "х",
                "и",
                "й",
                "к",
                "л",
                "м",
                "н",
                "о",
                "п",
                "я",
                "р",
                "с",
                "т",
                "у",
                "ж",
                "в",
                "ь",
                "ъ",
                "з"
            };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Returns a string in which the cyrillic letters are replaced with their Latin equivalents
        /// and all non-alphanumeric characters (excluding the period ".") are removed.
        /// </summary>
        /// <param name="input">The string which will be validated.</param>
        /// <returns>A copy of the provided string where all Cyrillic letters are replaced with their Latin. </returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Returns a string in which the cyrillic letters are replaced with their Latin equivalents,
        /// spaces are replaced with hyphens and all non-alphanumeric characters 
        /// (excluding the period "." and hyphen "-") are removed.</summary>
        /// <param name="input">The file name which will be validated</param>
        /// <returns>A copy of the provided file name where all Cyrillic letters are replaced with their Latin
        /// equivalents, spaces are replaced with hyphens and all non-alphanumeric characters
        /// (excluding the period "." and hyphen "-") are removed.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Get the first <paramref name="charsCount"/> symbols if <paramref name="charsCount"/> is smaller than <paramref name="input"/> length.
        /// Else get the whole <paramref name="input"/>
        /// </summary>
        /// <param name="input">The input string from which the first symbols will be taken</param>
        /// <param name="charsCount">Number of characters in the returned string</param>
        /// <returns>A substring from <paramref name="input"/> containing the first <paramref name="charsCount"/> symbols </returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the file extension of the string (interpreted as a file name).
        /// The period "." is omitted.
        /// </summary>
        /// <param name="fileName">The file name, which extension will be extracted.</param>
        /// <returns>Returns the last item in the array which is obtained by splitting
        /// the string by the period "." character.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the corresponding content type for the specified file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension (excluding the period ".").</param>
        /// <returns>The content type as a string.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
            {
                {
                    "jpg",
                    "image/jpeg"
                },
                {
                    "jpeg",
                    "image/jpeg"
                },
                {
                    "png",
                    "image/x-png"
                },
                {
                        "docx",
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                },
                {
                    "doc",
                    "application/msword"
                },
                {
                    "pdf",
                    "application/pdf"
                },
                {
                    "txt",
                    "text/plain"
                },
                {
                    "rtf",
                    "application/rtf"
                }
            };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a set of characters from the specified input string (which is converted to char array) into a sequence of bytes.
        /// </summary>
        /// <param name="input">The string, whose characters are going to be converted into a sequence of bytes.</param>
        /// <returns>A byte array containing the specified set of characters of the input string.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}