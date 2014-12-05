using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Benchmarks.Utils;
using Xunit;
using Xunit.Extensions;

namespace Benchmarks
{
    public class StacksTest
    {
        private const int count = CollectionCommonItems.BenchmarkCount;
        private object _;

        public StacksTest()
        {
            Benchmark.Count = CollectionCommonItems.BenchmarkAvgOf;
            Trace.WriteLine("Count: " + count + " * " + Benchmark.Count);
        }

        [Fact]
        public void StackTest()
        {
            var c = new Stack<int>();

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c.Push(i);
                }
                _ = c;
            }, () => { c = new Stack<int>(); },
                "Stack - Push");

            var current = (Stack<int>) _;
            c = new Stack<int>(current);

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    res = c.Pop();
                    _ = res;
                }
            }, () => { c = new Stack<int>(current); },
                "Stack - Pop");

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    res = c.Pop();
                    _ = res;
                }
                GC.Collect();
            }, () => { c = new Stack<int>(current); },
                "Stack - Pop and GC");
        }

        [Fact]
        public void ConcurrentStackTest()
        {
            var c = new ConcurrentStack<int>();

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c.Push(i);
                }
                _ = c;
            }, () => { c = new ConcurrentStack<int>(); }
                , "ConcurrentStack - Push");

            var current = (ConcurrentStack<int>) _;
            c = new ConcurrentStack<int>(current);

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c.TryPop(out res);
                    _ = res;
                }
            }, () => { c = new ConcurrentStack<int>(current); },
                "ConcurrentStack - Pop");

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c.TryPop(out res);
                    _ = res;
                }
                GC.Collect();
            }, () => { c = new ConcurrentStack<int>(current); },
                "ConcurrentStack - Pop and GC");
        }

        [Fact]
        public void MonoConcurrentStackTest()
        {
            var c = new Mono.ConcurrentStack<int>();

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c.Push(i);
                }
                _ = c;
            }, () => { c = new Mono.ConcurrentStack<int>(); }
                , "Mono - ConcurrentStack - Push");

            var current = (Mono.ConcurrentStack<int>)_;
            c = new Mono.ConcurrentStack<int>(current);

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c.TryPop(out res);
                    _ = res;
                }
            }, () => { c = new Mono.ConcurrentStack<int>(current); },
                "Mono - ConcurrentStack - Pop");

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c.TryPop(out res);
                    _ = res;
                }
                GC.Collect();
            }, () => { c = new Mono.ConcurrentStack<int>(current); },
                "Mono - ConcurrentStack - Pop and GC");
        }

        [Fact]
        public void ImmutableStackTest()
        {
            var c = ImmutableStack.Create<int>();

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    c = c.Push(i);
                }
                _ = c;
            }, () => { c = ImmutableStack.Create<int>(); },
                "ImmutableStack - Push");

            var current = (ImmutableStack<int>) _;
            c = current;

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c = c.Pop(out res);
                    _ = res;
                }
            }, () => { c = current; },
                "ImmutableStack - Pop");

            Benchmark.Run(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    int res;
                    c = c.Pop(out res);
                    _ = res;
                }
                GC.Collect();
            }, () => { c = current; },
                "ImmutableStack - Pop and GC");
        }
    }
}