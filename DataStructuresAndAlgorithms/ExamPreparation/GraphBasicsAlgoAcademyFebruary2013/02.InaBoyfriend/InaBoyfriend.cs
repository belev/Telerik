namespace _02.InaBoyfriend
{
    using System;
    using System.Linq;

    internal class InaBoyfriend
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int maxLikesCount = int.MinValue;
            string maxLikesPersonName = string.Empty;

            for (int i = 0; i < n; i++)
            {
                var nameAndLikes = Console.ReadLine().Split(' ');

                int currentPersonLikesCounts = nameAndLikes[1].Where(x => x == '1').Count();

                if (currentPersonLikesCounts > maxLikesCount)
                {
                    maxLikesCount = currentPersonLikesCounts;
                    maxLikesPersonName = nameAndLikes[0];
                }
            }

            Console.WriteLine(maxLikesPersonName);
        }
    }
}