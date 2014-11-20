using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benchmarks.Utils;
using Xunit;
using Xunit.Extensions;

namespace Benchmarks
{
    public class QueuesTest
    {
        private const int count = CollectionCommonItems.BenchmarkCount;
        private object _;

        [Fact]
        public void QueueTest()
        {
            var c = new Queue<int>();

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c.Enqueue(i);
                }
                _ = c;
            }, () => { c = new Queue<int>(); },
                "Queue - Enqueue");

            var current = (Queue<int>) _;
            c = new Queue<int>(current);

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    res = c.Dequeue();
                    _ = res;
                }
            }, () => { c = new Queue<int>(current); },
                "Queue - Dequeue");

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    res = c.Dequeue();
                    _ = res;
                }
                GC.Collect();
            }, () => { c = new Queue<int>(current); },
                "Queue - Dequeue and GC");
        }

        [Fact]
        public void ConcurrentQueueTest()
        {
            var c = new ConcurrentQueue<int>();

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c.Enqueue(i);
                }
                _ = c;
            }, () => { c = new ConcurrentQueue<int>(); },
                "ConcurrentQueue - Enqueue");

            var current = (ConcurrentQueue<int>) _;
            c = new ConcurrentQueue<int>(current);

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c.TryDequeue(out res);
                    _ = res;
                }
            }, () => { c = new ConcurrentQueue<int>(current); },
                "ConcurrentQueue - Dequeue");

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c.TryDequeue(out res);
                    _ = res;
                }
                GC.Collect();
            }, () => { c = new ConcurrentQueue<int>(current); },
                "ConcurrentQueue - Dequeue and GC");
        }

        [Fact]
        public void ImmutableQueueTest()
        {
            var c = ImmutableQueue.Create<int>();

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c = c.Enqueue(i);
                }
                _ = c;
            }, () => { c = ImmutableQueue.Create<int>(); },
                "ImmutableQueue - Enqueue");

            var current = (ImmutableQueue<int>) _;
            c = current;

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c = c.Dequeue(out res);
                    _ = res;
                }
            }, () => { c = current; },
                "ImmutableQueue - Dequeue");

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c = c.Dequeue(out res);
                    _ = res;
                }
                GC.Collect();
            }, () => { c = current; },
                "ImmutableQueue - Dequeue and GC");
        }
    }
}