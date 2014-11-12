using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APpKata_FolderLibrary
{
    /* TODO
     * - Use real Filesystem. 
     * - Remove mock from Prod code
     * - Recursive dirs and files
     * - Pause should pause
     * - Cover all states
     * - Approach: Nicer wrapper around testcode?
            Given 1 empty directory c:\temp
            When I Scan it
            I get 0

            Given 1 directory c:\temp with 1 file 
            When I Scan it
            I get 1 fileCount


            Given 1 directory c:\temp with 2 file 
            When I Scan it
            I get 2 fileCount
    
            Given 1 directory c:\temp with 1 sub and 1 file 
            When I Scan it
            I get 1 fileCount

     */
    [TestClass]
    public class Tests
    {
        private readonly Dictionary<string, DirectoryMock> fileSystem = new Dictionary<string, DirectoryMock>();

        private const string RootPath = null;

        [TestMethod]
        public void InitialStatusWaiting()
        {
            IFolderStats folderStats = new FolderStatsMock(fileSystem);
            Assert.AreEqual(Statuses.Waiting, folderStats.Status);
        }

        [TestMethod]
        public void StatusAfterConnectIsConnected()
        {
            IFolderStats folderStats = new FolderStatsMock(fileSystem);
            folderStats.Connect(RootPath);
            Assert.AreEqual(Statuses.Connected, folderStats.Status);
        }

        [TestMethod]
        public void EmptyDirectory_StartReturns1()
        {
            var root = GivenDirectory("c:\temp\test001");
            IFolderStats folderStats = new FolderStatsMock(fileSystem);

            StartAndWait(folderStats, root, 10);

            Assert.AreEqual(1, folderStats.Folders.Count());
        }

        private static void StartAndWait(IFolderStats folderStats, DirectoryMock root, int millisecondsTimeout)
        {
            folderStats.Connect(root.Name);
            folderStats.Start();
            Thread.Sleep(millisecondsTimeout);
        }

        [TestMethod]
        public void OneSubDirectory_StartReturns2()
        {
            var root = GivenDirectory("c:\temp\test001");
            root.SubDirectories.Add(new DirectoryMock("1"));

            IFolderStats folderStats = new FolderStatsMock(fileSystem);

            StartAndWait(folderStats, root, 10);

            Assert.AreEqual(2, folderStats.Folders.Count());
        }

        [TestMethod]
        public void OneFile_Returns1File()
        {
            var root = GivenDirectory("c:\temp\test001");
            root.Files.Add(new FileMock());

            IFolderStats folderStats = new FolderStatsMock(fileSystem);

            StartAndWait(folderStats, root, 10);

            Assert.AreEqual(1, folderStats.Folders.First().NumberOfFiles);
        }

        [TestMethod]
        public void EmptyDirectory_RaisesProgress()
        {
            var root = GivenDirectory("c:\temp\test001");

            IFolderStats folderStats = new FolderStatsMock(fileSystem);

            var counter = 0;
            var resetEvent = new AutoResetEvent(false);

            folderStats.Progress += folder =>
            {
                counter++;
                resetEvent.Set();
            };

            folderStats.Connect(root.Name);
            folderStats.Start();

            resetEvent.WaitOne(1000);

            Assert.AreEqual(1, counter);
        }

        [TestMethod]
        public void DirectoryWith2Subfolders_WhenPauseCalled_StatusPaused()
        {
            var root = GivenDirectory("c:\temp\test001");
            root.SubDirectories.Add(new DirectoryMock("1"));
            root.SubDirectories.Add(new DirectoryMock("2"));

            IFolderStats folderStats = new FolderStatsMock(fileSystem);

            folderStats.Progress += folder =>
            {
                Thread.Sleep(100);
            };

            folderStats.Connect(root.Name);
            folderStats.Start();
            folderStats.Pause();

            Assert.AreEqual(Statuses.Paused, folderStats.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void StatusCompleted_WhenPauseCalled_ExceptionThrown()
        {
            var root = GivenDirectory("c:\temp\test001");

            IFolderStats folderStats = new FolderStatsMock(fileSystem);

            StartAndWait(folderStats, root, 10);

            folderStats.Pause();
        }

        private DirectoryMock GivenDirectory(string directoryName)
        {
            var directoryMock = DirectoryMock.CreateDirectory(directoryName);

            fileSystem.Add(directoryName, directoryMock);

            return directoryMock;
        }
    }
}