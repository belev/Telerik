namespace _02.SimpleMathOperations
{
    public static class DivisionTester
    {
        public static int Divide(int fromNumber, int toNumber, int step)
        {
            var divisionResult = int.MaxValue;

            for (int i = fromNumber; i < toNumber; i++)
            {
                divisionResult /= step;
            }

            return divisionResult;
        }

        public static long Divide(long fromNumber, long toNumber, long step)
        {
            var divisionResult = long.MaxValue;

            for (var i = fromNumber; i < toNumber; i++)
            {
                divisionResult /= step;
            }

            return divisionResult;
        }

        public static float Divide(float fromNumber, float toNumber, float step)
        {
            var divisionResult = float.MaxValue;

            for (var i = fromNumber; i < toNumber; i++)
            {
                divisionResult /= step;
            }

            return divisionResult;
        }

        public static double Divide(double fromNumber, double toNumber, double step)
        {
            var divisionResult = double.MaxValue;

            for (var i = fromNumber; i < toNumber; i++)
            {
                divisionResult /= step;
            }

            return divisionResult;
        }

        public static decimal Divide(decimal fromNumber, decimal toNumber, decimal step)
        {
            var divisionResult = decimal.MaxValue;

            for (var i = fromNumber; i < toNumber; i++)
            {
                divisionResult /= step;
            }

            return divisionResult;
        }
    }
}
