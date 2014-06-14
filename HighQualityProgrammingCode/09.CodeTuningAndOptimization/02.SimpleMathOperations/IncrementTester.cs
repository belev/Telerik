namespace _02.SimpleMathOperations
{
    public static class IncrementTester
    {
        public static void Increment(int fromNumber, int toNumber)
        {
            for (int i = fromNumber; i < toNumber; )
            {
                i++;
            }
        }

        public static void Increment(long fromNumber, long toNumber)
        {
            for (var i = fromNumber; i < toNumber; )
            {
                i++;
            }
        }

        public static void Increment(float fromNumber, float toNumber)
        {
            for (var i = fromNumber; i < toNumber; )
            {
                i++;
            }
        }

        public static void Increment(double fromNumber, double toNumber)
        {
            for (var i = fromNumber; i < toNumber; )
            {
                i++;
            }
        }

        public static void Increment(decimal fromNumber, decimal toNumber)
        {
            for (var i = fromNumber; i < toNumber; )
            {
                i++;
            }
        }
    }
}
