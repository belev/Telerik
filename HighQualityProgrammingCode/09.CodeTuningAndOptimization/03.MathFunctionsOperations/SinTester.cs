namespace _03.MathFunctionsOperations
{
    using System;

    public static class SinTester
    {
        public static void Sin(float number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Sin(number);
            }
        }

        public static void Sin(double number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Sin(number);
            }
        }

        public static void Sin(decimal number, int repeatCount)
        {
            for (int i = 0; i < repeatCount; ++i)
            {
                Math.Sin((double) number);
            }
        }
    }
}
