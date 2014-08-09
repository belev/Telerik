namespace _03.FilesAndFoldersAsTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FilesAndFoldersAsTree
    {
        private static void TraverseAllFilesAndFolders(string curDirPath, Folder curFolder)
        {
            try
            {
                // add all files to curFolder
                foreach (var fileName in Directory.GetFiles(curDirPath))
                {
                    ulong fileSize = (ulong) (new FileInfo(fileName).Length);

                    File fileToAdd = new File(fileName, fileSize);
                    curFolder.AddFile(fileToAdd);
                }

                // add all folders to curFolder
                foreach (var dirName in Directory.GetDirectories(curDirPath))
                {
                    curFolder.AddFolder(new Folder(dirName));

                    // take the last folder in the current folder and go through the algorithm again
                    TraverseAllFilesAndFolders(dirName, curFolder.ChildFolders[curFolder.ChildFolders.Length - 1]);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main()
        {
            const string StartDirectory = @"C:\Windows";

            Folder root = new Folder(StartDirectory);

            TraverseAllFilesAndFolders(StartDirectory, root);

            ulong totalSize = root.CalculateSize();

            Console.WriteLine(totalSize);
        }
    }
}
