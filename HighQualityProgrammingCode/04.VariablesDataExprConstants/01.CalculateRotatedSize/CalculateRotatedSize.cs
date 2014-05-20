namespace _01.CalculateRotatedSize
{
    using System;

    public class CalculateRotatedSize
    {
        public static Size GetRotatedSize(Size size, double rotationAngle)
        {
            double rotatedCosWidthSize = Math.Abs(Math.Cos(rotationAngle)) * size.Width;
            double rotatedSinHeightSize = Math.Abs(Math.Sin(rotationAngle)) * size.Height;
            double rotatedWidthSize = rotatedCosWidthSize + rotatedSinHeightSize;

            double rotatedSinWidthSize = Math.Abs(Math.Sin(rotationAngle)) * size.Width;
            double rotatedCosHeightSize = Math.Abs(Math.Cos(rotationAngle)) * size.Height;
            double rotatedHeightSize = rotatedSinWidthSize + rotatedCosHeightSize;

            return new Size(rotatedWidthSize, rotatedHeightSize);
        }

        public static void Main(string[] args)
        {
        }
    }
}
