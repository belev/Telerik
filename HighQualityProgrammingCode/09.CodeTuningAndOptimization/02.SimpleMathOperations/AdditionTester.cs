namespace _02.SimpleMathOperations
{
    public static class AdditionTester
    {
        public static int Add(int fromNumber, int toNumber, int step)
        {
            var sum = 0;

            for (int i = fromNumber; i < toNumber; i++)
            {
                sum += step;
            }

            return sum;
        }

        public static long Add(long fromNumber, long toNumber, long step)
        {
            var sum = 0L;

            for (var i = fromNumber; i < toNumber; i++)
            {
                sum += step;
            }

            return sum;
        }

        public static float Add(float fromNumber, float toNumber, float step)
        {
            var sum = 0F;

            for (var i = fromNumber; i < toNumber; i++)
            {
                sum += step;
            }

            return sum;
        }

        public static double Add(double fromNumber, double toNumber, double step)
        {
            var sum = 0.0;

            for (var i = fromNumber; i < toNumber; i++)
            {
                sum += step;
            }

            return sum;
        }

        public static decimal Add(decimal fromNumber, decimal toNumber, decimal step)
        {
            var sum = 0M;

            for (var i = fromNumber; i < toNumber; i++)
            {
                sum += step;
            }

            return sum;
        }
    }
}
