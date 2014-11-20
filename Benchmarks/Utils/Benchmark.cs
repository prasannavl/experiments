using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedScooby.Common.Tests.Utils
{
    public class Benchmark
    {
        public static int Count = 10;
        public static void Run(Action action, string label = "")
        {
            var i = 0;
            var sw = new Stopwatch();
            for (i = 0; i < 2; i++)
            {
                sw.Start();
                action();
                sw.Stop();
            }
            sw.Reset();
            for (i = 0; i < Count; i++)
            {
                sw.Start();
                action();
                sw.Stop();
            }
            Trace.WriteLine(label + " => Time taken: " + sw.Elapsed.ToString());
        }

        public static void Run(Action action, Action cleanupAction, string label = "")
        {
            var i = 0;
            var sw = new Stopwatch();
            for (i = 0; i < 2; i++)
            {
                sw.Start();
                action();
                sw.Stop();
                cleanupAction();
            }
            sw.Reset();
            for (i = 0; i < Count; i++)
            {
                sw.Start();
                action();
                sw.Stop();
                cleanupAction();
            }
            Trace.WriteLine(label + " => Time taken: " + sw.Elapsed.ToString());
        }

        public static async Task RunAsync(Func<Task> action, string label = "")
        {
            var i = 0;
            var sw = new Stopwatch();
            for (i = 0; i < 2; i++)
            {
                sw.Start();
                await action();
                sw.Stop();
            }
            sw.Reset();
            for (i = 0; i < Count; i++)
            {
                sw.Start();
                await action();
                sw.Stop();
            }
            Trace.WriteLine(label + " => Time taken: " + sw.Elapsed.ToString());
        }
    }
}
