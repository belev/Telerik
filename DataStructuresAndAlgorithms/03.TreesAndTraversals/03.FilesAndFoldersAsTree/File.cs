namespace _03.FilesAndFoldersAsTree
{
    public class File
    {
        public File(string name, ulong size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; set; }

        public ulong Size { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0} -> size: {1}", this.Name, this.Size);
        }
    }
}
