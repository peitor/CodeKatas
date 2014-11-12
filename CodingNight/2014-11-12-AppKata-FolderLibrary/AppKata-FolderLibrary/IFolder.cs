namespace APpKata_FolderLibrary
{
    public interface IFolder
    {
        int Depth { get; set; }

        long NumberOfFiles { get; set; }

        string Path { get; set; }

        long TotalBytes { get; set; }
    }
}