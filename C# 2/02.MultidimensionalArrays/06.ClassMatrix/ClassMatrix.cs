using System;
using System.Text;

class Matrix
{
    private int[,] matrix;
    private int rowsCount;
    private int colsCount;

    public Matrix(int numberOfRows, int numberOfCols)
    {
        rowsCount = numberOfRows;
        colsCount = numberOfCols;

        matrix = new int[rowsCount, colsCount];
    }

    public Matrix(int[,] matrixToInitialize)
    {
        rowsCount = matrixToInitialize.GetLength(0);
        colsCount = matrixToInitialize.GetLength(1);

        matrix = (int[,]) matrixToInitialize.Clone();
    }

    public int RowsCount
    {
        get
        {
            return rowsCount;
        }
    }
    public int ColsCount
    {
        get
        {
            return colsCount;
        }
    }

    public int this[int rowIndex, int colIndex]
    {
        get
        {
            if (rowIndex >= 0 && rowIndex < rowsCount && colIndex >= 0 && colIndex < colsCount)
            {
                return matrix[rowIndex, colIndex];
            }
            else
            {
                return 0;
            }
        }

        set
        {
            if (rowIndex >= 0 && rowIndex < rowsCount && colIndex >= 0 && colIndex < colsCount)
            {
                matrix[rowIndex, colIndex] = value;
            }
        }
    }

    public static Matrix operator +(Matrix first, Matrix second)
    {
        if (first.RowsCount == second.RowsCount && first.ColsCount == second.ColsCount)
        {
            Matrix result = new Matrix(first.RowsCount, first.ColsCount);

            for (int row = 0; row < first.RowsCount; row++)
            {
                for (int col = 0; col < first.ColsCount; col++)
                {
                    result[row, col] = first[row, col] + second[row, col];
                }
            }

            return result;
        }
        else
        {
            return new Matrix(0, 0);
        }
    }

    public static Matrix operator -(Matrix first, Matrix second)
    {
        if (first.RowsCount == second.RowsCount && first.ColsCount == second.ColsCount)
        {
            Matrix result = new Matrix(first.RowsCount, first.ColsCount);

            for (int row = 0; row < first.RowsCount; row++)
            {
                for (int col = 0; col < first.ColsCount; col++)
                {
                    result[row, col] = first[row, col] - second[row, col];
                }
            }

            return result;
        }
        else
        {
            return new Matrix(0, 0);
        }
    }

    public static Matrix operator *(Matrix first, Matrix second)
    {
        if (first.RowsCount == second.ColsCount && first.ColsCount == second.RowsCount)
        {
            Matrix result = new Matrix(first.RowsCount, second.ColsCount);

            for (int i = 0; i < first.RowsCount; i++)
            {
                for (int j = 0; j < second.ColsCount; j++)
                {
                    for (int k = 0; k < second.RowsCount; k++)
                    {
                        result[i, j] += first[i, k] * second[k, j];
                    }
                }
            }
            return result;
        }
        else
        {
            return new Matrix(0, 0);
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < colsCount; j++)
            {
                result.Append(matrix[i, j] + " ");
            }
            if (i != rowsCount - 1)
            {
                result.AppendLine();
            }
        }

        return result.ToString();
    }
}
class ClassMatrix
{
    static void Main()
    {
        int[,] first = { { 2, 3, 2 }, { 3, 2, 3 }, { 2, 3, 2 } };
        int[,] second = { { 1, 2, 1 }, { 2, 1, 2 }, { 1, 2, 1 } };

        Matrix one = new Matrix(first);
        Matrix two = new Matrix(second);

        Matrix multiplicationResult = one * two;
        Matrix addResult = one + two;
        Matrix subtractionResult = one - two;

        Console.WriteLine("Multiplication result");
        Console.WriteLine(multiplicationResult.ToString());
        Console.WriteLine(new string('-', 25));

        Console.WriteLine("Adding matrices result");
        Console.WriteLine(addResult.ToString());
        Console.WriteLine(new string('-', 25));

        Console.WriteLine("Subtracting matrices result");
        Console.WriteLine(subtractionResult.ToString());
        Console.WriteLine(new string('-', 25));

        //using the indexer
        Console.WriteLine(one[0, 0]);
    }
}

