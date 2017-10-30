using System;
using System.IO;
using Xunit;

namespace TestRunner
{
    public class Logger : IRunnerLogger
    {
        public void AssemblyFinished(string assemblyFilename, int total, int failed, int skipped, double time)
        {
            Console.WriteLine("Assembly finished.");
        }

        public void AssemblyStart(string assemblyFilename, string configFilename, string xUnitVersion)
        {
            Console.WriteLine("Testing assembly: " + Path.GetFileNameWithoutExtension(assemblyFilename) +
                              Environment.NewLine);
        }

        public bool ClassFailed(string className, string exceptionType, string message, string stackTrace)
        {
            return true;
        }

        public void ExceptionThrown(string assemblyFilename, Exception exception)
        {
            Console.WriteLine(Environment.NewLine + "Exception: " + exception.Message + Environment.NewLine);
        }

        public void TestFailed(string name, string type, string method, double duration, string output,
            string exceptionType,
            string message, string stackTrace)
        {
            Console.WriteLine("Failed. Time taken: " + duration + "s");
            if (!string.IsNullOrWhiteSpace(output))
            {
                Console.WriteLine(Environment.NewLine + output);
            }
        }

        public bool TestFinished(string name, string type, string method)
        {
            return true;
        }

        public void TestPassed(string name, string type, string method, double duration, string output)
        {
            Console.WriteLine("Passed. Time taken: " + duration + "s");
            if (!string.IsNullOrWhiteSpace(output))
            {
                Console.WriteLine(Environment.NewLine + output);
                Program.AddLineToOutput(output);
            }
        }

        public void TestSkipped(string name, string type, string method, string reason)
        {
            var output = name + " .. Skipped";
            if (!string.IsNullOrWhiteSpace(reason))
            {
                output += " => " + reason;
            }
            else
            {
                output += ".";
            }
            Console.WriteLine(output);
        }

        public bool TestStart(string name, string type, string method)
        {
            Console.Write("{0} .. ", name);
            return true;
        }
    }
}