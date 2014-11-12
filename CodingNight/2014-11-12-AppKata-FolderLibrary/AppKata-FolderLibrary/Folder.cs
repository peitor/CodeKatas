namespace APpKata_FolderLibrary
{
    public class Folder : IFolder
    {
        public int Depth { get; set; }

        public long NumberOfFiles { get; set; }

        public string Path { get; set; }

        public long TotalBytes { get; set; }
    }
}