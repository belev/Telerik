namespace _01.MaximalPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MaximalPath
    {
        static Dictionary<int, List<int>> tree;
        static Dictionary<int, bool> visited;
        static int farthestNode = 0;
        static long maxSum = 0;

        static void Main(string[] args)
        {
            ParseUserInput();

            int someNode = tree.First(n => n.Key > 0).Key;

            // find the farthest node in the tree, let the farthest node be X
            Dfs(someNode, 0);

            // find the farthest node from X, the sum will be the sum of all nodes between the two farthest nodes
            Dfs(farthestNode, farthestNode);

            Console.WriteLine(maxSum);
        }

        private static void ParseUserInput()
        {
            int n = int.Parse(Console.ReadLine());
            tree = new Dictionary<int, List<int>>(n);
            visited = new Dictionary<int, bool>(n);

            for (int i = 0; i < n - 1; i++)
            {
                string line = Console.ReadLine();
                string[] vals = line.Trim('(', ')').Split(new string[1] { "<-" }, StringSplitOptions.RemoveEmptyEntries);
                int node = int.Parse(vals[1]);
                int parentOfNode = int.Parse(vals[0]);

                if (!tree.ContainsKey(parentOfNode))
                {
                    tree.Add(parentOfNode, new List<int>());
                }

                if (!tree.ContainsKey(node))
                {
                    tree.Add(node, new List<int>());
                }

                if (!visited.ContainsKey(node))
                {
                    visited.Add(node, false);
                }

                if (!visited.ContainsKey(parentOfNode))
                {
                    visited.Add(parentOfNode, false);
                }

                tree[parentOfNode].Add(node);
                tree[node].Add(parentOfNode);
            }
        }

        private static void Dfs(int node, long total)
        {
            visited[node] = true;

            foreach (var descendant in tree[node])
            {
                if (!visited[descendant])
                {
                    Dfs(descendant, total + descendant);
                }
            }

            visited[node] = false;

            if (total > maxSum)
            {
                maxSum = total;
                farthestNode = node;
            }
        }
    }
}