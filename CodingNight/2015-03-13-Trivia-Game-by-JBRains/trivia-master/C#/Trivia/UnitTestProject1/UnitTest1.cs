using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    [TestClass]
    public class UnitTest1
    {
        private static string actualFilePath = baseDir + @"actual.txt";

        private static string baseDir = @"c:\temp\trivia\";

        [TestMethod]
        public void RunGameWithSeed()
        {
            RunGame("3");
            RunGame("100");
            RunGame("1000");
            RunGame("10000");
        }

        private static void RunGame(string seed)
        {
            string expected = string.Format(baseDir + @"expected-{0}.txt", seed);
            actualFilePath = string.Format(baseDir + @"actual-{0}.txt", seed);
            File.Delete(actualFilePath);

            Process x = new Process();

            x.StartInfo.FileName = GetExecFolder() + @"\Trivia.exe";
            x.StartInfo.Arguments = seed;

            x.StartInfo.UseShellExecute = false;
            x.StartInfo.RedirectStandardOutput = true;  

            x.OutputDataReceived += MyProcOutputHandler;
            x.Start();
            x.BeginOutputReadLine();

            x.WaitForExit();
            x.CancelOutputRead();

            Assert.AreEqual(File.ReadAllText(expected), File.ReadAllText(actualFilePath));
        }

        private static string GetExecFolder()
        {
            string codeBase = Assembly.GetExecutingAssembly().Location;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        private static void MyProcOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            // Collect the sort command output. 
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                File.AppendAllText(actualFilePath, outLine.Data);
                File.AppendAllText(actualFilePath, System.Environment.NewLine);
            }
        }
    }
}
