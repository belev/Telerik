namespace Exam.GameLogic
{
    using System;
    using System.Linq;

    public class GameResultValidator : IGameResultValidator
    {
        public PlayerGuessResult GetResult(string numberToGuess, string playersGuessNumber, PlayerOnTurn onTurn)
        {
            if (this.IsPlayerGuessNumberInputValid(playersGuessNumber))
            {
                var bullsAndCowsCount = this.FindBullsAndCows(numberToGuess, playersGuessNumber);
                int bullsCount = bullsAndCowsCount.Item1;
                int cowsCount = bullsAndCowsCount.Item2;

                var playerGuessResult = new PlayerGuessResult(bullsCount, cowsCount);

                if (bullsCount == 4)
                {
                    if (onTurn == PlayerOnTurn.Red)
                    {
                        playerGuessResult.GameResult = GameResult.WonByRed;
                    }
                    else
                    {
                        playerGuessResult.GameResult = GameResult.WonByBlue;
                    }
                }
                else
                {
                    playerGuessResult.GameResult = GameResult.NotFinished;
                }

                return playerGuessResult;
            }
            else
            {
                throw new ArgumentException("Invalid player guess number entered. Guess number should be with exactly 4 digits and they must be different.");
            }
        }

        public bool IsPlayerGuessNumberInputValid(string playersGuessNumber)
        {
            var guessNumberLength = playersGuessNumber.Length;
            if (guessNumberLength != 4)
            {
                return false;
            }

            for (int i = 0; i < guessNumberLength - 1; i++)
            {
                for (int j = i + 1; j < guessNumberLength; j++)
                {
                    if (playersGuessNumber[i] == playersGuessNumber[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private Tuple<int, int> FindBullsAndCows(string numberToGuess, string playersGuessNumber)
        {
            var usedDigits = new bool[4];

            int bullsCount = this.FindBullsCount(numberToGuess, playersGuessNumber, usedDigits);
            int cowsCount = this.FindCowsCount(numberToGuess, playersGuessNumber, usedDigits);

            return new Tuple<int, int>(bullsCount, cowsCount);
        }


        private int FindBullsCount(string numberToGuess, string playersGuessNumber, bool[] usedDigits)
        {
            int bullsCount = 0;

            for (int i = 0; i < playersGuessNumber.Length; i++)
            {
                if (playersGuessNumber[i] == numberToGuess[i])
                {
                    bullsCount++;
                    usedDigits[i] = true;
                }
            }

            return bullsCount;
        }

        private int FindCowsCount(string numberToGuess, string playersGuessNumber, bool[] usedDigits)
        {
            int cowsCount = 0;

            for (int i = 0; i < playersGuessNumber.Length; i++)
            {
                for (int j = 0; j < playersGuessNumber.Length; j++)
                {
                    if (usedDigits[j])
                    {
                        continue;
                    }

                    if (playersGuessNumber[i] == numberToGuess[j])
                    {
                        cowsCount++;
                        usedDigits[j] = true;
                    }
                }
            }

            return cowsCount;
        }
    }
}