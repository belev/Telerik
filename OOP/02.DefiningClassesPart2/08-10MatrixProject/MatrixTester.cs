using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_10MatrixProject
{
    class MatrixTester
    {
        static void Main(string[] args)
        {
            /* test with
             * 1
             * 2
             * 3
             * 4
             * 4
             * 3
             * 2
             * 1
             * */
            Console.Write("First matrix number of rows: ");
            int firstRowsCount = int.Parse(Console.ReadLine());
            Console.Write("First matrix number of cols: ");
            int firstColsCount = int.Parse(Console.ReadLine());

            int[,] firstMatrix = new int[firstRowsCount, firstColsCount];
            for (int i = 0; i < firstRowsCount; i++)
            {
                for (int j = 0; j < firstColsCount; j++)
                {
                    firstMatrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.Write("Second matrix number of rows: ");
            int secondRowsCount = int.Parse(Console.ReadLine());
            Console.Write("Second matrix number of cols: ");
            int secondColsCount = int.Parse(Console.ReadLine());

            int[,] secondMatrix = new int[secondRowsCount, secondColsCount];
            for (int i = 0; i < secondRowsCount; i++)
            {
                for (int j = 0; j < secondColsCount; j++)
                {
                    secondMatrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();

            Matrix<int> matrixA = new Matrix<int>(firstMatrix);
            Matrix<int> matrixB = new Matrix<int>(secondMatrix);

            //test sum of two matrix
            Matrix<int> sumResult = matrixA + matrixB;
            Matrix<int> subtractResult = matrixA - matrixB;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(sumResult.ToString());

            Console.WriteLine(subtractResult.ToString());
            //test multiplication of two matrix
            Matrix<int> multiplyResult = matrixA * matrixB;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(multiplyResult.ToString());

            Console.ResetColor();

            //test operator true
            //matrix x is not initialized so it is not true
            //and print as output FALSE
            Matrix<double> x = new Matrix<double>(5, 5);
            if (x)
            {
                Console.WriteLine("TRUE");
            }
            else
            {
                Console.WriteLine("FALSE");
            }
        }
    }
}
