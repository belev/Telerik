namespace _06.Horse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Horse
    {
        private static Position[] availableHorseMoves = new Position[] 
        {
            new Position() {Row = 1, Col = -2},
            new Position() {Row = 2, Col = -1},
            new Position() {Row = 2, Col = 1},
            new Position() {Row = 1, Col = 2},
            new Position() {Row = -1, Col = -2},
            new Position() {Row = -2, Col = -1},
            new Position() {Row = -2, Col = 1},
            new Position() {Row = -1, Col = 2},
        };

        private static Position startPosition;
        private static Position endPosition;
        private static bool[,] available;

        private static void Main()
        {
            ReadInput();

            Console.WriteLine(Solve(startPosition));
        }

        private static void ReadInput()
        {
            int n = int.Parse(Console.ReadLine());

            available = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                var lineAsCharArray = Console.ReadLine().Split(' ');

                for (int j = 0; j < lineAsCharArray.Length; j++)
                {
                    if (lineAsCharArray[j] == "s")
                    {
                        startPosition = new Position() { Row = i, Col = j, NumberOfMoves = 0L };
                    }
                    else if (lineAsCharArray[j] == "e")
                    {
                        endPosition = new Position() { Row = i, Col = j };
                        available[i, j] = true;
                    }
                    else if (lineAsCharArray[j] == "-")
                    {
                        available[i, j] = true;
                    }
                }
            }
        }

        private static long Solve(Position startPosition)
        {
            var queue = new Queue<Position>();
            queue.Enqueue(startPosition);

            while (queue.Count != 0)
            {
                var currentPosition = queue.Dequeue();
                available[currentPosition.Row, currentPosition.Col] = false;

                foreach (var nextMovePosition in availableHorseMoves)
                {
                    var nextPosition = currentPosition + nextMovePosition;
                    nextPosition.NumberOfMoves = currentPosition.NumberOfMoves + 1;

                    if (IsPossiblePosition(nextPosition))
                    {
                        if (nextPosition.Row == endPosition.Row && nextPosition.Col == endPosition.Col)
                        {
                            return nextPosition.NumberOfMoves;
                        }

                        if (available[nextPosition.Row, nextPosition.Col])
                        {
                            queue.Enqueue(nextPosition);
                            available[nextPosition.Row, nextPosition.Col] = false;
                        }
                    }
                }
            }

            return -1;
        }

        private static bool IsPossiblePosition(Position position)
        {
            return position.Row >= 0 && position.Col >= 0 && position.Row < available.GetLength(0) && position.Col < available.GetLength(1);
        }
    }

    internal struct Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public long NumberOfMoves { get; set; }

        public static Position operator +(Position p1, Position p2)
        {
            return new Position() { Row = p1.Row + p2.Row, Col = p1.Col + p2.Col };
        }
    }
}
