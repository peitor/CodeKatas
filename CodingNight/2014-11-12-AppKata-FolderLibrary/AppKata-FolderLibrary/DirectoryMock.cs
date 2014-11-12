using System.Collections.Generic;

namespace APpKata_FolderLibrary
{
    public class DirectoryMock
    {
        public DirectoryMock(string s)
        {
            this.Name = s;
            SubDirectories = new List<DirectoryMock>();
            Files = new List<FileMock>();
        }

        public List<DirectoryMock> SubDirectories { get; private set; }
        public List<FileMock> Files { get; private set; }

        public string Name { get; set; }

        public static DirectoryMock CreateDirectory(string directoryName)
        {
            return new DirectoryMock(directoryName);
        }
    }
}