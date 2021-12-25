using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Text;
using YantraJS.Core;

namespace LowLevelBenchamarks.ListVsSequence
{

    public class ListVsSequenceBenchmark
    {

        public const int Max = 1000;

        // public const string i.ToString() = "A";

        [Benchmark]
        public object AllocateListReference()
        {
            var list = new List<string>();
            for (int i = 0; i < Max; i++)
            {
                list.Add(i.ToString());
            }
            return list;
        }

        [Benchmark]
        public object AllocateSequenceReference()
        {
            var list = new Sequence<string>();
            for (int i = 0; i < Max; i++)
            {
                list.Add(i.ToString());
            }
            return list;
        }

        [Benchmark]
        public object AllocateListValue()
        {
            var list = new List<(string, string)>();
            for (int i = 0; i < Max; i++)
            {
                var item = i.ToString();
                list.Add((item, item));
            }
            return list;
        }

        [Benchmark]
        public object AllocateSequenceValue()
        {
            var list = new Sequence<(string, string)>();
            for (int i = 0; i < Max; i++)
            {
                var item = i.ToString();
                list.Add((item,item));
            }
            return list;
        }
    }
}
