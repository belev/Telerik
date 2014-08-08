namespace ComputerBuildingSystem
{
    using System;

    public abstract class BaseSquareNumberFinder
    {
        public const int MinimumNumberValue = 0;
        public const string NumberTooLowMessage = "Number too low.";
        public const string NumberTooHighMessage = "Number too high.";
        public const string PrintedMessageFormat = "Square of {0} is {1}.";

        public abstract string FormattedSquareNumberResult(int number);
    }
}
