namespace _03.FriendsInNeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class FriendsInNeed
    {
        private static HashSet<int> hospitalIds;
        private static List<Node>[] graph;

        private static void Main()
        {
            ReadInput();
            Console.WriteLine(FindMinimumDistance());
        }

        private static void ReadInput()
        {
            var nMH = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var inputHospitalIds = Console.ReadLine().Split(' ').Select(x => int.Parse(x) - 1).ToArray();

            hospitalIds = new HashSet<int>(inputHospitalIds);

            graph = Enumerable.Repeat(0, nMH[0]).Select(x => new List<Node>()).ToArray();

            for (int i = 0; i < nMH[1]; i++)
            {
                var curConnection = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                // add the connection in the two directions from first to second, and from second to first
                graph[curConnection[0] - 1].Add(new Node(curConnection[1] - 1, curConnection[2]));
                graph[curConnection[1] - 1].Add(new Node(curConnection[0] - 1, curConnection[2]));
            }
        }

        private static long FindMinimumDistance()
        {
            long minDistance = long.MaxValue;

            foreach (var id in hospitalIds)
            {
                // for each of the hospitals, find the minimum distance to all other places
                // and get the minimum distance of all places
                long minimumHospitalDistance = FindHospitalMinimumDistance(id);
                minDistance = Math.Min(minDistance, minimumHospitalDistance);
            }

            return minDistance;
        }

        private static long FindHospitalMinimumDistance(int hospitalId)
        {
            // give max value to all distances
            var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();

            // give value of 0 for the starting point
            distances[hospitalId] = 0;

            var nodes = new Queue<Node>();
            nodes.Enqueue(new Node(hospitalId, 0));

            while (nodes.Count != 0)
            {
                var currentNodeId = nodes.Dequeue().Id;

                foreach (var neighbour in graph[currentNodeId])
                {
                    // if the current node distance until the moment plus the distance to the neighbour is smaller than
                    // the neighbour distance until that moment, than we change the neighbour distance with the smaller distance value
                    var potentialDistance = neighbour.Distance + distances[currentNodeId];

                    if (potentialDistance < distances[neighbour.Id])
                    {
                        distances[neighbour.Id] = potentialDistance;
                        nodes.Enqueue(new Node(neighbour.Id, potentialDistance));
                    }
                }
            }

            // x is the minimum distance to the place, and y is the index of the place
            var distancesToSum = distances.Where((x, y) => !hospitalIds.Contains(y));
            return distancesToSum.Sum();
        }
    }

    internal struct Node
    {
        public Node(int id, int distance)
            : this()
        {
            this.Id = id;
            this.Distance = distance;
        }

        public int Id { get; set; }

        public int Distance { get; set; }

        public override string ToString()
        {
            return "Id " + this.Id + ": " + this.Distance;
        }
    }
}