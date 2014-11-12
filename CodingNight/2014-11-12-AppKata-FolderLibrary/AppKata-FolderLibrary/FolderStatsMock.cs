using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APpKata_FolderLibrary
{
    public class FolderStatsMock : IFolderStats
    {
        private readonly Dictionary<string, DirectoryMock> fileSystem;

        public FolderStatsMock(Dictionary<string, DirectoryMock> fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public event Action<IFolder> Progress;

        public IEnumerable<IFolder> Folders { get; private set; }

        public string RootPath { get; private set; }

        public Statuses Status { get; private set; }

        public void Connect(string rootpath)
        {
            Status = Statuses.Connected;
            RootPath = rootpath;
        }

        public void Pause()
        {
            if (Status == Statuses.Finished)
            {
                throw new Exception();
            }
            Status = Statuses.Paused;
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            Status = Statuses.Running;
            Task.Run(
                () =>
                {
                    var root = fileSystem[RootPath];

                    var enumerable = root.SubDirectories.Select(CreateFolder).ToList();
                    enumerable.Add(CreateFolder(root));

                    Folders = enumerable;
                    Status = Statuses.Finished;
                });
            
        }

        private Folder CreateFolder(DirectoryMock folderMock)
        {
            var folder = new Folder
                         {
                             NumberOfFiles = folderMock.Files.Count
                         };

            if (Progress != null)
            {
                Progress(folder);
            }

            return folder;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}