namespace Exam.GameLogic
{
    public interface IGameResultValidator
    {
        PlayerGuessResult GetResult(string guessNumber, string playersNumber, PlayerOnTurn onTurn);

        bool IsPlayerGuessNumberInputValid(string playerGuessNumber);
    }
}
