namespace _01.FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class FriendsOfPesho
    {
        static List<Node>[] graph;
        static ISet<int> hospitalIds;

        static void Main()
        {
            ReadInput();

            Console.WriteLine(FindMinimumDistance());
        }

        private static void ReadInput()
        {
            var counters = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var hospIds = Console.ReadLine().Split(' ').Select(x => int.Parse(x) - 1).ToArray();

            hospitalIds = new HashSet<int>(hospIds);

            graph = Enumerable.Repeat(0, counters[0]).Select(x => new List<Node>()).ToArray();

            for (int i = 0; i < counters[1]; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                graph[line[0] - 1].Add(new Node(line[1] - 1, line[2]));
                graph[line[1] - 1].Add(new Node(line[0] - 1, line[2]));
            }
        }

        private static long FindMinimumDistance()
        {
            long minDistance = long.MaxValue;

            foreach (var hospId in hospitalIds)
            {
                long minimumHospitalDistance = FindHospitalMinimumDistance(hospId);
                minDistance = Math.Min(minDistance, minimumHospitalDistance);
            }

            return minDistance;
        }

        private static long FindHospitalMinimumDistance(int hospitalId)
        {
            var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
            distances[hospitalId] = 0;

            var queue = new Queue<Node>();
            queue.Enqueue(new Node(hospitalId, 0));

            while (queue.Count != 0)
            {
                var curNode = queue.Dequeue();

                foreach (var neighbour in graph[curNode.Id])
                {
                    var potentialDistance = neighbour.Distance + distances[curNode.Id];

                    if (potentialDistance < distances[neighbour.Id])
                    {
                        distances[neighbour.Id] = potentialDistance;
                        queue.Enqueue(new Node(neighbour.Id, potentialDistance));
                    }
                }
            }

            return distances.Where((x, y) => !hospitalIds.Contains(y)).Sum();
        }

        // for solution in bgcoder
        //public struct Node
        //{
        //    public Node(int id, int distance)
        //        : this()
        //    {
        //        this.Id = id;
        //        this.Distance = distance;
        //    }

        //    public int Id { get; set; }

        //    public int Distance { get; set; }
        //}
    }
}