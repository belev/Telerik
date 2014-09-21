namespace _08.APlusB_N
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class APlusB
    {
        private static char firstVariable;
        private static char secondVariable;
        private static int n;

        private static void Main()
        {
            ReadInput();
            var powers = GetPaskalTriangleRow(n);

            var result = GetAPlusBUpToN(n, powers, firstVariable, secondVariable);
            Console.WriteLine(result);
        }

        private static void ReadInput()
        {
            var variables = Console.ReadLine();

            firstVariable = variables[1];
            secondVariable = variables[3];

            Console.ReadLine();
            n = int.Parse(Console.ReadLine());
        }

        private static long[] GetPaskalTriangleRow(int rowNumber)
        {
            var currentRow = new List<long>() { 1, 1 };

            var nextRow = new List<long>();

            for (int i = 2; i <= rowNumber; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        nextRow.Add(1);
                    }
                    else
                    {
                        nextRow.Add(currentRow[j - 1] + currentRow[j]);
                    }
                }

                currentRow = new List<long>((long[]) nextRow.ToArray().Clone());
                nextRow.Clear();
            }

            return currentRow.ToArray();
        }

        private static string GetAPlusBUpToN(int n, long[] powers, char firstVariable, char secondVariable)
        {
            var format = "({0}^{1})";
            var result = new StringBuilder();

            var stringToAppend = string.Empty;
            for (int i = 0; i <= n; i++)
            {
                var firstVariablePower = n - i;
                var secondVariablePower = i;

                if (powers[i] != 1)
                {
                    result.Append(powers[i]);
                }

                if (firstVariablePower != 0)
                {
                    stringToAppend = string.Format(format, firstVariable, firstVariablePower);
                    result.Append(stringToAppend);
                }

                if (secondVariablePower != 0)
                {
                    stringToAppend = string.Format(format, secondVariable, secondVariablePower);
                    result.Append(stringToAppend);
                }

                result.Append("+");
            }

            result.Length--;
            return result.ToString();
        }
    }
}
