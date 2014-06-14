namespace _02.SimpleMathOperations
{
    public static class MultiplicationTester
    {
        public static int Multiply(int fromNumber, int toNumber, int step)
        {
            var multiplyResult = 1;

            for (int i = fromNumber; i < toNumber; i++)
            {
                multiplyResult *= step;
            }

            return multiplyResult;
        }

        public static long Multiply(long fromNumber, long toNumber, long step)
        {
            var multiplyResult = 1L;

            for (var i = fromNumber; i < toNumber; i++)
            {
                multiplyResult *= step;
            }

            return multiplyResult;
        }

        public static float Multiply(float fromNumber, float toNumber, float step)
        {
            var multiplyResult = 1F;

            for (var i = fromNumber; i < toNumber; i++)
            {
                multiplyResult *= step;
            }

            return multiplyResult;
        }

        public static double Multiply(double fromNumber, double toNumber, double step)
        {
            var multiplyResult = 1.0;

            for (var i = fromNumber; i < toNumber; i++)
            {
                multiplyResult *= step;
            }

            return multiplyResult;
        }

        public static decimal Multiply(decimal fromNumber, decimal toNumber, decimal step)
        {
            var multiplyResult = 1M;

            for (var i = fromNumber; i < toNumber; i++)
            {
                multiplyResult *= step;
            }

            return multiplyResult;
        }
    }
}
