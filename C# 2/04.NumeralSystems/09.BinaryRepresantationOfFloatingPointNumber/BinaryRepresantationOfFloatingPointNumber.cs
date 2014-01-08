using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.BinaryRepresantationOfFloatingPointNumber
{
    class BinaryRepresantationOfFloatingPointNumber
    {
        static int GetLeftPart(byte x)
        {
            return (x >> 4);
        }

        static int GetRightPart(byte x)
        {
            return (x & 15);
        }

        static string PartToBinary(int x)
        {
            string result = "";
            for (int i = 3; i >= 0; --i)
            {
                result += (x >> i) & 1;
            }

            return result;
        }

        static string ConvertFloatToBinary(float floatNumber)
        {
            string result = "";
            byte[] floatBytes = BitConverter.GetBytes(floatNumber);
            for (int i = 3; i >= 0; --i)
            {
                result += PartToBinary(GetLeftPart(floatBytes[i]));
                result += PartToBinary(GetRightPart(floatBytes[i]));
            }

            return result;
        }

        static void Main(string[] args)
        {
            float floatNumber = float.Parse(Console.ReadLine());

            string binaryNumber = ConvertFloatToBinary(floatNumber);

            Console.WriteLine("Binary representation: " + binaryNumber);
            Console.WriteLine("Sign: " + binaryNumber[0]);
            Console.WriteLine("Exponent: " + binaryNumber.Substring(1, 8));
            Console.WriteLine("Mantissa: " + binaryNumber.Substring(9));
        }
    }
}
