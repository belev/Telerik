using System;
    class FromDecimalToBinary
    {
        private static string ConvertToBinary(ref int decimalNum)
        {
            string resultInBinary = "";
            while (decimalNum > 0)
            {
                resultInBinary = decimalNum % 2 + resultInBinary;
                decimalNum /= 2;
            }
            return resultInBinary;
        }

        static void Main()
        {
            string inputDecimalNum = Console.ReadLine();
            int decimalNum = int.Parse(inputDecimalNum);

            string binaryNum = Convert.ToString(decimalNum, 2);

            Console.WriteLine(binaryNum.PadLeft(32, '0'));

            //other solution

            string resultInBinary = ConvertToBinary(ref decimalNum);

            Console.WriteLine(resultInBinary);
        }
    }

