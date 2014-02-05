using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _08_10MatrixProject
{
    //08.Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
    class Matrix<T>
    {
        private T[,] matrix;
        private int rowsCount;
        private int colsCount;

        public Matrix(int rows, int cols)
        {
            this.rowsCount = rows;
            this.colsCount = cols;

            matrix = new T[rows, cols];
        }
        public Matrix(T[,] matrix)
        {
            this.rowsCount = matrix.GetLength(0);
            this.colsCount = matrix.GetLength(1);

            this.matrix = new T[this.rowsCount, this.colsCount];

            for (int row = 0; row < this.rowsCount; row++)
            {
                for (int col = 0; col < this.colsCount; col++)
                {
                    this.matrix[row, col] = matrix[row, col];
                }
            }
        }
        public int RowsCount
        {
            get { return this.rowsCount; }
        }
        public int ColsCount
        {
            get { return this.colsCount; }
        }

        //09.Implement an indexer this[row, col] to access the inner matrix cells.

        public T this[int row, int col]
        {
            get
            {
                if (row >= 0 && col >= 0 && row < this.rowsCount && col < this.colsCount)
                {
                    return this.matrix[row, col];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (row >= 0 && col >= 0 && row < this.rowsCount && col < this.colsCount)
                {
                    matrix[row, col] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        //10.Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).

        public static Matrix<T> operator +(Matrix<T> x, Matrix<T> y)
        {
            if (x.RowsCount == y.RowsCount && x.ColsCount == y.ColsCount)
            {
                int rows = x.RowsCount;
                int cols = x.ColsCount;

                Matrix<T> result = new Matrix<T>(rows, cols);

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        result[row, col] = (dynamic) x[row, col] + (dynamic) y[row, col];
                    }
                }

                return result;
            }
            else
            {
                throw new ArithmeticException("Can't add two matrices of different types!");
            }
        }
        public static Matrix<T> operator -(Matrix<T> x, Matrix<T> y)
        {
            if (x.RowsCount == y.RowsCount && x.ColsCount == y.ColsCount)
            {
                int rows = x.RowsCount;
                int cols = x.ColsCount;

                Matrix<T> result = new Matrix<T>(rows, cols);

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        result[row, col] = (dynamic) x[row, col] - (dynamic) y[row, col];
                    }
                }

                return result;
            }
            else
            {
                throw new ArithmeticException("Can't subtract two matrices of different types!");
            }
        }
        public static Matrix<T> operator *(Matrix<T> x, Matrix<T> y)
        {
            if (x.rowsCount == y.colsCount && x.colsCount == y.rowsCount)
            {
                Matrix<T> result = new Matrix<T>(x.rowsCount, y.colsCount);

                for (int row = 0; row < x.rowsCount; row++)
                {
                    for (int col = 0; col < y.colsCount; col++)
                    {
                        for (int i = 0; i < y.colsCount; i++)
                        {
                            result[row, col] += ((dynamic) x[row, i]) * ((dynamic) y[i, col]);
                        }
                    }
                }

                return result;
            }
            else
            {
                throw new ArithmeticException("Can't multiply two matrices of different types!");
            }
        }
        public static bool operator true(Matrix<T> x)
        {
            for (int row = 0; row < x.rowsCount; row++)
            {
                for (int col = 0; col < x.colsCount; col++)
                {
                    if (((dynamic) x[row, col]) != default(T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> x)
        {
            if (x)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.rowsCount; row++)
            {
                for (int col = 0; col < this.colsCount; col++)
                {
                    result.Append(this.matrix[row, col]);

                    if (col < this.colsCount - 1)
                    {
                        result.Append(" ");
                    }
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
