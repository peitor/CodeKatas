using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    using System.Diagnostics;
    using System.IO;
    using System.Security.Policy;

    using UglyTrivia;

    [TestClass]
    public class UnitTest1
    {
        private static string actualFilePath = @"c:\temp\actual.txt";

        [TestMethod]
        public void TestMethod1()
        {
            string expected = @"c:\temp\expected.txt";

            File.Delete(actualFilePath);

            Process x = new Process();
            x.StartInfo.FileName = @"c:\Users\pgf\Desktop\trivia-master\C#\Trivia\Trivia\bin\Debug\Trivia.exe";
            x.StartInfo.Arguments = "3";

            x.StartInfo.UseShellExecute = false;
            x.StartInfo.RedirectStandardOutput = true;
            
            x.OutputDataReceived += MyProcOutputHandler;
            x.Start();
            x.BeginOutputReadLine();

            x.WaitForExit();
            x.CancelOutputRead();


            Assert.AreEqual(File.ReadAllText(expected), File.ReadAllText(actualFilePath) );
        }

        private static void MyProcOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
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
