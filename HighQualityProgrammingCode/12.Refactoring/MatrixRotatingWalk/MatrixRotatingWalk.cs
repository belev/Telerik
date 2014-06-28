namespace Matrix
{
    using System;

    public class MatrixRotatingWalk
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(8);
            matrix.Traverse();

            Console.WriteLine(matrix.ToString());
        }
    }
}
