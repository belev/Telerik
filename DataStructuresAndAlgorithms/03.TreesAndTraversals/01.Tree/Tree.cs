namespace _01.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree
    {
        private static void ReadInput()
        {
            int n = int.Parse(Console.ReadLine());

            // make an array from 0 to n - 1, so after that can add to this array the information from the input
            Nodes = new TreeNode<int>[n];

            for (int i = 0; i < n; i++)
            {
                Nodes[i] = new TreeNode<int>(i);
            }

            // read input
            for (int i = 0; i < n - 1; i++)
            {
                var parentAndChildSplitted = Console.ReadLine().Split(' ');

                int parentIndex = int.Parse(parentAndChildSplitted[0]);
                int childIndex = int.Parse(parentAndChildSplitted[1]);

                // add child to its parent and on the node with index == childIndex, set hasParent value to true
                // thats made for searching the root of the tree
                // the node which hasnt got a parent is the root
                Nodes[parentIndex].AddChild(Nodes[childIndex]);
                Nodes[childIndex].HasParent = true;
            }
        }

        private static int FindTreeRootValue()
        {
            var rootValue = Nodes.Where(n => !n.HasParent).Select(n => n.Value).ToArray();

            return rootValue[0];
        }

        private static List<int> FindTreeLeafNodes()
        {
            var treeLeafNodes = Nodes.Where(n => n.Children.Count == 0).Select(n => n.Value).ToList();

            return treeLeafNodes;
        }

        private static List<int> FindMiddleNodes()
        {
            var treeLeafNodes = Nodes.Where(n => n.HasParent && n.Children.Count != 0).Select(n => n.Value).ToList();

            return treeLeafNodes;
        }

        private static int FindLongestPathLength(TreeNode<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPathLength = 0;
            foreach (var node in root.Children)
            {
                maxPathLength = Math.Max(maxPathLength, FindLongestPathLength(node));
            }

            return maxPathLength + 1;
        }

        /// <summary>
        /// my interpretation of the requirement from task 1 e) is that the path have to be from some node downwards
        /// take some node and look all its children, if with some of them there is sum equal to searched sum</summary>
        /// add the current path to all paths<param name="givenSum"></param>
        /// <param name="curPath"></param>
        /// <param name="paths"></param>
        /// <param name="root"></param>
        private static void FindAllPathsWithGivenSum(int givenSum, List<int> curPath, List<List<int>> paths, TreeNode<int> root)
        {
            int curSum = curPath.Sum();

            if (curSum == givenSum)
            {
                paths.Add(curPath.GetRange(0, curPath.Count));
                return;
            }

            if (curSum > givenSum || root.Children.Count == 0)
            {
                return;
            }

            foreach (var child in root.Children)
            {
                curPath.Add(child.Value);
                FindAllPathsWithGivenSum(givenSum, curPath, paths, child);
                curPath.RemoveAt(curPath.Count - 1);
            }
        }

        public static TreeNode<int>[] Nodes;

        static void Main()
        {
            // test input
            // 7
            // 2 4
            // 3 2
            // 5 0
            // 3 5
            // 5 6
            // 5 1

            ReadInput();

            // 01a) Find tree root
            int rootValue = FindTreeRootValue();
            Console.WriteLine("01. a) Tree root: {0}", rootValue);
            Console.WriteLine();

            // 01b) Find all tree leaf nodes
            var treeLeafNodes = FindTreeLeafNodes();
            var treeLeafNodesAsString = string.Join(", ", treeLeafNodes);

            Console.WriteLine("01. b) Tree leaf nodes: {0}", treeLeafNodesAsString);
            Console.WriteLine();

            // 01c) Find all tree middle nodes
            var treeMiddleNodes = FindMiddleNodes();
            var treeMiddleNodesAsString = string.Join(", ", treeMiddleNodes);
            Console.WriteLine("01. c) Tree middle nodes: {0}", treeMiddleNodesAsString);
            Console.WriteLine();

            // 01d) Find the longest path in the tree
            int longestPathLength = FindLongestPathLength(Nodes[rootValue]);
            Console.WriteLine("01. d) Tree longest path length from root: {0}", longestPathLength);
            Console.WriteLine();

            // 01e) Find all paths with given sum of their nodes
            var paths = new List<List<int>>();
            var curPath = new List<int>();
            int givenSum = 6;

            foreach (var node in Nodes)
            {
                curPath.Add(node.Value);
                FindAllPathsWithGivenSum(givenSum, curPath, paths, node);
                curPath.Clear();
            }

            if (paths.Count == 0)
            {
                Console.WriteLine("01. e) There are no paths in the tree with sum: {0}", givenSum);
            }
            else
            {
                Console.WriteLine("01. e) All paths in the tree with sum: {0}", givenSum);
                foreach (var path in paths)
                {
                    Console.WriteLine(string.Join(" -> ", path));
                }
            }

            // 01f) Find all subtrees with given sum
        }
    }
}
