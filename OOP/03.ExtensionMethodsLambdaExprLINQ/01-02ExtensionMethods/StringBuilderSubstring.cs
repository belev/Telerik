using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02ExtensionMethods
{
    //01.Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.

    public static class StringBuilderSubstring
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            if (index < 0 || index >= sb.Length || index + length > sb.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid index or length! Operation can't proceed!");
            }
            else
            {
                StringBuilder substringResult = new StringBuilder();

                for (int i = index; i < index + length; i++)
                {
                    substringResult.Append(sb[i]);
                }

                return substringResult;
            }
        }

        public static StringBuilder Substring(this StringBuilder sb, int index)
        {
            StringBuilder substringResult = new StringBuilder();

            for (int i = index; i < sb.Length; i++)
            {
                substringResult.Append(sb[i]);
            }

            return substringResult;
        }
    }
}
