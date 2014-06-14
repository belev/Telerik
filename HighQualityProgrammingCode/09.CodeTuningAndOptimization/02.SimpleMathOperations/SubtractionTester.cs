namespace _02.SimpleMathOperations
{
    public static class SubtractionTester
    {
        public static int Subtract(int fromNumber, int toNumber, int step)
        {
            var subtraction = 0;

            for (int i = fromNumber; i < toNumber; i++)
            {
                subtraction -= step;
            }

            return subtraction;
        }

        public static long Subtract(long fromNumber, long toNumber, long step)
        {
            var subtraction = 0L;

            for (var i = fromNumber; i < toNumber; i++)
            {
                subtraction -= step;
            }

            return subtraction;
        }

        public static float Subtract(float fromNumber, float toNumber, float step)
        {
            var subtraction = 0F;

            for (var i = fromNumber; i < toNumber; i++)
            {
                subtraction -= step;
            }

            return subtraction;
        }

        public static double Subtract(double fromNumber, double toNumber, double step)
        {
            var subtraction = 0.0;

            for (var i = fromNumber; i < toNumber; i++)
            {
                subtraction -= step;
            }

            return subtraction;
        }

        public static decimal Subtract(decimal fromNumber, decimal toNumber, decimal step)
        {
            var subtraction = 0M;

            for (var i = fromNumber; i < toNumber; i++)
            {
                subtraction -= step;
            }

            return subtraction;
        }
    }
}
