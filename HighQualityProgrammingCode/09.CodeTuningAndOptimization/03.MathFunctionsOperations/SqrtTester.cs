namespace _03.MathFunctionsOperations
{
    using System;

    public static class SqrtTester
    {
        public static void Sqrt(float number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Sqrt(number);
            }
        }

        public static void Sqrt(double number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Sqrt(number);
            }
        }

        public static void Sqrt(decimal number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Sqrt((double) number);
            }
        }
    }
}
