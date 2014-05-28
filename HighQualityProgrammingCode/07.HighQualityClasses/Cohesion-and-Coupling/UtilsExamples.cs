using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            var fileNames = new string[] { "example", "example.pdf", "example.new.pdf" };
            foreach (var fileName in fileNames)
            {
                string fileExtension = FileUtils.GetFileExtension(fileName);
                string fileNameWithoutExtension = FileUtils.GetFileNameWithoutExtension(fileName);

                Console.WriteLine(fileExtension);
                Console.WriteLine(fileNameWithoutExtension);
            }

            Console.WriteLine("Distance in the 2D space = {0:f2}", GeometryUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Parallelepiped parallelepiped = new Parallelepiped(3, 4, 5);
            double paralVolume = parallelepiped.CalcVolume();
            double paralBodyDiagonal = parallelepiped.CalcBodyDiagonal();
            double paralDiagonalXY = parallelepiped.CalcDiagonalXY();
            double paralDiagonalXZ = parallelepiped.CalcDiagonalXZ();
            double paralDiagonalYZ = parallelepiped.CalcDiagonalYZ();

            Console.WriteLine("Volume = {0:f2}", paralVolume);
            Console.WriteLine("Diagonal XYZ = {0:f2}", paralBodyDiagonal);
            Console.WriteLine("Diagonal XY = {0:f2}", paralDiagonalXY);
            Console.WriteLine("Diagonal XZ = {0:f2}", paralDiagonalXZ);
            Console.WriteLine("Diagonal YZ = {0:f2}", paralDiagonalYZ);
        }
    }
}
