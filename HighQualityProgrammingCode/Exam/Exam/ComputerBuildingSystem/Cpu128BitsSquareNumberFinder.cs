namespace ComputerBuildingSystem
{
    public class Cpu128BitsSquareNumberFinder : BaseSquareNumberFinder
    {
        public const int MaximumNumberValue = 2000;

        public override string FormattedSquareNumberResult(int number)
        {
            if (number < BaseSquareNumberFinder.MinimumNumberValue)
            {
                return BaseSquareNumberFinder.NumberTooLowMessage;
            }
            else if (number > MaximumNumberValue)
            {
                return BaseSquareNumberFinder.NumberTooHighMessage;
            }
            else
            {
                // bottleneck refactored. Unnecessary loop for calculating the square number.
                int value = number * number;
                return string.Format(BaseSquareNumberFinder.PrintedMessageFormat, number, value);
            }
        }
    }
}
