namespace Exam.GameLogic
{
    public class PlayerGuessResult
    {
        public PlayerGuessResult(int bullsCount, int cowsCount)
        {
            this.BullsCount = bullsCount;
            this.CowsCount = cowsCount;
        }

        public PlayerGuessResult(int bullsCount, int cowsCount, GameResult gameResult)
            : this(bullsCount, cowsCount)
        {
            this.GameResult = gameResult;
        }

        public int BullsCount { get; set; }

        public int CowsCount { get; set; }

        public GameResult GameResult { get; set; }
    }
}