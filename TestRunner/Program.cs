using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Benchmarks;
using Xunit;

namespace TestRunner
{
    internal class Program
    {
        private static StreamWriter _writer;

        private static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                Console.WriteLine("Exiting.");
                Cleanup();
            };

            InitializeOutputWriter();

            var logger = new Logger();
            var executor = new ExecutorWrapper(typeof (TestRunnerIdDummy).Assembly.Location, null, false);
            var testRunner = new Xunit.TestRunner(executor, logger);
            var result = testRunner.RunAssembly();

            Cleanup();
        }

        private static void Cleanup()
        {
            if (_writer != null)
            {
                _writer.Dispose();
            }
        }

        private static void InitializeOutputWriter()
        {
            try
            {
                var procName = Process.GetCurrentProcess().MainModule.FileName;
                var dir = Path.GetDirectoryName(procName);
                var filePath = Path.Combine(dir, "..\\..\\..\\README.md");
                var stream =
                    File.Open(
                        filePath, FileMode.Append, FileAccess.Write);
                _writer = new StreamWriter(stream);
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine(DateTimeOffset.Now.ToString() + ":" + Environment.NewLine);
                var version = Assembly
                    .GetExecutingAssembly()
                    .GetReferencedAssemblies()
                    .First(x => x.Name == "System.Core").Version.ToString();
                sb.AppendLine("CLR Version: " + Environment.Version);
                sb.AppendLine(".NET Framework Version: " + version);
                sb.AppendLine("OS: " + Environment.OSVersion.ToString());
                sb.AppendLine("Process architecture: " + (Environment.Is64BitProcess ? "64-bit" : "32-bit"));
                sb.AppendLine();
                _writer.Write(sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Readme.md file unavailable. Skipping output generation to file.");
            }
        }

        public static void AddLineToOutput(string text)
        {
            if (_writer != null)
                _writer.WriteLine(text);
        }
    }
}