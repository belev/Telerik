namespace _03.FilesAndFoldersAsTree
{
    using System.Collections.Generic;
    public class Folder
    {
        private List<File> files;
        private List<Folder> childFolders;

        public Folder(string name)
        {
            this.Name = name;
            this.files = new List<File>();
            this.childFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public File[] Files
        {
            get
            {
                return this.files.ToArray();
            }
        }

        public Folder[] ChildFolders
        {
            get
            {
                return this.childFolders.ToArray();
            }
        }

        public void AddFile(File file)
        {
            this.files.Add(file);
        }

        public void AddFolder(Folder folder)
        {
            this.childFolders.Add(folder);
        }

        public override string ToString()
        {
            return string.Format("Folder name: {0} -> subfolders count: {1}", this.Name, this.childFolders.Count);
        }

        public ulong CalculateSize()
        {
            ulong size = 0ul;

            foreach (var file in this.Files)
            {
                size += file.Size;
            }

            foreach (var childFolder in this.ChildFolders)
            {
                size += childFolder.CalculateSize();
            }

            return size;
        }
    }
}
