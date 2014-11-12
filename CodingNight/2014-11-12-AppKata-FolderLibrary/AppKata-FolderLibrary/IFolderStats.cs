using System;
using System.Collections.Generic;

namespace APpKata_FolderLibrary
{
    public interface IFolderStats
    {
        event Action<IFolder> Progress;

        IEnumerable<IFolder> Folders { get; }
        
        string RootPath { get; }
        
        Statuses Status { get; }

        void Connect(string rootpath);

        void Pause();

        void Resume();

        void Start();

        void Stop();

    }
}