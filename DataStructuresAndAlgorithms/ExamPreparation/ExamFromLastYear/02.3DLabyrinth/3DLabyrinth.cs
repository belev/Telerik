namespace _02._3DLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Labyrinth
    {
        private const int DirectionsCount = 4;
        private static int[] xDirections = new int[] { -1, 0, 0, 1 };
        private static int[] yDirections = new int[] { 0, 1, -1, 0 };

        private static Position startingPosition;
        private static int levelsCount;
        private static int rowsCount;
        private static int colsCount;
        private static Dictionary<int, char[,]> labyrinth;
        private static Dictionary<int, bool[,]> visited;

        private static void Main()
        {
            ReadInput();
            var minimumMovesCount = FindMinimumNumberOfMoves(startingPosition);

            Console.WriteLine(minimumMovesCount);
        }

        private static void ReadInput()
        {
            var xYZ = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var lRC = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            startingPosition = new Position()
            {
                Level = xYZ[0],
                Row = xYZ[1],
                Col = xYZ[2],
                MovesCount = 0
            };

            levelsCount = lRC[0];
            rowsCount = lRC[1];
            colsCount = lRC[2];

            labyrinth = new Dictionary<int, char[,]>();
            visited = new Dictionary<int, bool[,]>();

            for (int level = 0; level < levelsCount; level++)
            {
                labyrinth.Add(level, new char[rowsCount, colsCount]);
                visited.Add(level, new bool[rowsCount, colsCount]);

                for (int row = 0; row < rowsCount; row++)
                {
                    var line = Console.ReadLine();

                    for (int col = 0; col < colsCount; col++)
                    {
                        labyrinth[level][row, col] = line[col];

                        if (line[col] == '#')
                        {
                            visited[level][row, col] = true;
                        }
                    }
                }
            }
        }

        private static bool IsValidCell(int row, int col)
        {
            return rowsCount > row && colsCount > col && row >= 0 && col >= 0;
        }

        private static int FindMinimumNumberOfMoves(Position start)
        {
            Queue<Position> queue = new Queue<Position>();
            queue.Enqueue(start);

            visited[start.Level][start.Row, start.Col] = true;

            while (queue.Count != 0)
            {
                var currentPosition = queue.Dequeue();

                //Console.WriteLine("Level: {0}, Row: {1}, Col: {2}, Moves: {3}", currentPosition.Level, currentPosition.Row, currentPosition.Col, currentPosition.MovesCount);

                bool hasStepedOnLadder = false;

                if (labyrinth[currentPosition.Level][currentPosition.Row, currentPosition.Col] == 'D')
                {
                    if (currentPosition.Level - 1 < 0)
                    {
                        return currentPosition.MovesCount + 1;
                    }

                    currentPosition.Level--;
                    hasStepedOnLadder = true;
                }
                else if (labyrinth[currentPosition.Level][currentPosition.Row, currentPosition.Col] == 'U')
                {
                    if (currentPosition.Level + 1 >= levelsCount)
                    {
                        return currentPosition.MovesCount + 1;
                    }

                    currentPosition.Level++;
                    hasStepedOnLadder = true;
                }

                if (hasStepedOnLadder)
                {
                    if (!visited[currentPosition.Level][currentPosition.Row, currentPosition.Col])
                    {
                        currentPosition.MovesCount++;
                        queue.Enqueue(currentPosition);

                        visited[currentPosition.Level][currentPosition.Row, currentPosition.Col] = true;
                    }
                }
                else
                {
                    for (int i = 0; i < DirectionsCount; i++)
                    {
                        var nextRow = currentPosition.Row + xDirections[i];
                        var nextCol = currentPosition.Col + yDirections[i];

                        if (IsValidCell(nextRow, nextCol) && visited[currentPosition.Level][nextRow, nextCol] == false)
                        {
                            queue.Enqueue(new Position()
                            {
                                Level = currentPosition.Level,
                                Row = nextRow,
                                Col = nextCol,
                                MovesCount = currentPosition.MovesCount + 1
                            });

                            visited[currentPosition.Level][nextRow, nextCol] = true;
                        }
                    }
                }
            }

            return 0;
        }
    }

    internal struct Position
    {
        public int Level { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public int MovesCount { get; set; }
    }
}
