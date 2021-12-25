using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using YantraJS.Core;

namespace LowLevelBenchamarks.ListVsSequence
{
    public class ListVsSequenceBenchmark
    {

        public const int Max = 257;

        public const string Data = "A";

        [Benchmark]
        public object AllocateListReference()
        {
            var list = new List<string>();
            for (int i = 0; i < Max; i++)
            {
                list.Add(Data);
            }
            return list;
        }

        [Benchmark]
        public object AllocateSequenceReference()
        {
            var list = new Sequence<string>(4);
            for (int i = 0; i < Max; i++)
            {
                list.Add(Data);
            }
            return list;
        }

        [Benchmark]
        public object AllocateListValue()
        {
            var list = new List<(string, string)>();
            var item = (Data, Data);
            for (int i = 0; i < Max; i++)
            {
                list.Add(item);
            }
            return list;
        }

        [Benchmark]
        public object AllocateSequenceValue()
        {
            var list = new Sequence<(string, string)>(4);
            var item = (Data, Data);
            for (int i = 0; i < Max; i++)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
