namespace _02.TraversingCWindows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class TraversingCWindows
    {
        private static void TraverseCWindows(string path, List<string> allExeFiles, string matchingPattern)
        {
            try
            {
                var filesInPath = Directory.GetFiles(path, matchingPattern);

                allExeFiles.AddRange(filesInPath);

                foreach (var dir in Directory.GetDirectories(path))
                {
                    TraverseCWindows(dir, allExeFiles, matchingPattern);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main()
        {
            // there is a .txt file with the whole output in bin/debug directory
            const string StartPath = @"C:\Windows";
            const string MatchingPattern = "*.exe";

            // all file paths with .exe
            List<string> allExeFilesPaths = new List<string>();

            allExeFilesPaths.AddRange(Directory.GetFiles(StartPath, MatchingPattern));

            TraverseCWindows(StartPath, allExeFilesPaths, MatchingPattern);

            foreach (var file in allExeFilesPaths)
            {
                Console.WriteLine(file);
            }
        }
    }
}
