using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benchmarks.Types;
using Benchmarks.Utils;
using Xunit;
using Xunit.Extensions;

namespace Benchmarks
{
    public class ListsTest
    {
        private const int count = CollectionCommonItems.BenchmarkCount;
        private object _;

        public ListsTest()
        {
            Benchmark.Count = CollectionCommonItems.BenchmarkIterations;
            Trace.WriteLine("Count: " + count + " * " + Benchmark.Count);
        }

        [Fact]
        public void ListTest()
        {
            var c = new List<int>();

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c.Add(i);
                }
                _ = c;
            }, () => { c = new List<int>(); },
                "List - Add");

            var current = (List<int>) _;
            c = new List<int>(current);

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c.RemoveAt(c.Count - 1);
                }
            }, () => { c = new List<int>(current); },
                "List - Remove from end (through index)");

        }

        [Fact]
        public void SynchronizedListWithNoContentionTest()
        {
            var c = new SynchronizedList<int>();

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c.Add(i);
                }
                _ = c;
            }, () => { c = new SynchronizedList<int>(); },
                "SynchronizedList (No contention) - Add");

            var current = (SynchronizedList<int>)_;
            c = new SynchronizedList<int>(current);

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c.RemoveAt(c.Count - 1);
                }
            }, () => { c = new SynchronizedList<int>(current); },
                "SynchronizedList (No contention) - Remove from end (through index)");
        }

        [Fact]
        public void ConcurrentBagTest()
        {
            var c = new ConcurrentBag<int>();

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c.Add(i);
                }
                _ = c;
            }, () => { c = new ConcurrentBag<int>(); },
                "ConcurrentBag - Add");

            var current = (ConcurrentBag<int>)_;
            c = new ConcurrentBag<int>(current);

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c.TryTake(out res);
                    _ = res;
                }
            }, () => { c = new ConcurrentBag<int>(current); },
                "ConcurrentBag - Take (through element)");

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c.TryTake(out res);
                    _ = res;
                }
                GC.Collect();
            }, () => { c = new ConcurrentBag<int>(current); },
                "ConcurrentBag - Take (through element) and GC");
        }

        [Fact]
        public void ImmutableListTest()
        {
            var c = ImmutableList.Create<int>();

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c = c.Add(i);
                }
                _ = c;
            }, () => { c = ImmutableList.Create<int>(); },
                "ImmutableList - Add");

            var current = (ImmutableList<int>)_;
            c = current;

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c = c.RemoveAt(c.Count - 1);
                }
            }, () => { c = current; },
                "ImmutableList - Remove from end (through index)");

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c = c.RemoveAt(c.Count - 1);
                }
                GC.Collect();
            }, () => { c = current; },
                "ImmutableList - Remove from end (through index), and GC");
        }
    }
}