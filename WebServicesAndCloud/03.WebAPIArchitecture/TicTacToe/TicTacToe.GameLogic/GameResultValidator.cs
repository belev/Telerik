namespace TicTacToe.GameLogic
{
    using System;
    using System.Linq;

    public class GameResultValidator : IGameResultValidator
    {
        // O-X
        // O-X
        // --X
        public GameResult GetResult(string board)
        {
            return this.GetCurrentGameResult(board);
        }

        private GameResult GetCurrentGameResult(string board)
        {
            if (!this.IsBoardValid(board))
            {
                throw new ArgumentException("The board with the players moves is not valid.");
            }

            var boardAsMatrix = this.GetBoardAsCharMatrix(board);

            for (int i = 0; i < 3; i++)
            {
                var horizontalResult = CheckHorizontal(i, boardAsMatrix);
                var verticalResult = CheckVertical(i, boardAsMatrix);

                if (horizontalResult)
                {
                    if (boardAsMatrix[i, 0] == 'X')
                    {
                        return GameResult.WonByX;
                    }
                    else
                    {
                        return GameResult.WonByO;
                    }
                }

                if (verticalResult)
                {
                    if (boardAsMatrix[0, i] == 'X')
                    {
                        return GameResult.WonByX;
                    }
                    else
                    {
                        return GameResult.WonByO;
                    }
                }
            }

            if (CheckRightDiagonal(boardAsMatrix))
            {
                if (boardAsMatrix[0, 0] == 'X')
                {
                    return GameResult.WonByX;
                }
                else
                {
                    return GameResult.WonByO;
                }
            }

            if (CheckLeftDiagonal(boardAsMatrix))
            {
                if (boardAsMatrix[0, 2] == 'X')
                {
                    return GameResult.WonByX;
                }
                else
                {
                    return GameResult.WonByO;
                }
            }

            if (this.IsBoardFull(board))
            {
                return GameResult.Draw;
            }

            return GameResult.NotFinished;
        }

        private char[,] GetBoardAsCharMatrix(string board)
        {
            var boardAsCharMatrix = new char[3, 3];

            for (int i = 0; i < board.Length; i++)
            {
                int row = i / 3;
                int col = i % 3;

                boardAsCharMatrix[row, col] = board[i];
            }

            return boardAsCharMatrix;
        }

        private bool CheckHorizontal(int hor, char[,] board)
        {
            if (board[hor, 0] == board[hor, 1] && board[hor, 1] == board[hor, 2])
            {
                if (board[hor, 0] != '-')
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckVertical(int ver, char[,] board)
        {
            if (board[0, ver] == board[1, ver] && board[1, ver] == board[2, ver])
            {
                if (board[0, ver] != '-')
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckRightDiagonal(char[,] board)
        {
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[2, 2] != '-')
            {
                return true;
            }
            return false;
        }

        private bool CheckLeftDiagonal(char[,] board)
        {
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[2, 0] != '-')
            {
                return true;
            }
            return false;
        }

        private bool IsBoardFull(string board)
        {
            return board.Where(s => s == '-').Count() == 0;
        }

        private bool IsBoardValid(string board)
        {
            var xCount = 0;

            foreach (var symbol in board)
            {
                if (symbol == 'X')
                {
                    xCount++;
                }

                if (symbol == 'O')
                {
                    xCount--;
                }
            }

            if (xCount == 0 || xCount == 1)
            {
                return true;
            }

            return false;
        }
    }
}