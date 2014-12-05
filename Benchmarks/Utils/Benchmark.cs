using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Benchmarks.Utils
{
    public class Benchmark
    {
        public static int Count = 3;
        public static void Run(Action action, string label = "")
        {
            var i = 0;
            var sw = new Stopwatch();

            // Let the JIT compiler warm up.
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

            // Let the JIT compiler warm up.
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

            // Let the JIT compiler warm up.
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
