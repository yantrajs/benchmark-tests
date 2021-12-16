using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using YantraJS.Core;

namespace LowLevelBenchamarks.ListVsSequence
{
    public class ListVsSequenceBenchmark
    {

        public const int Max = 100;

        public List<string> listReference = new List<string>();
        public Sequence<string> sequenceReference = new Sequence<string>();
        public List<(string,string)> listValue = new List<(string, string)>();
        public Sequence<(string, string)> sequenceValue = new Sequence<(string, string)>();

        [Benchmark]
        public void AllocateListReference()
        {
            for (int i = 0; i < Max; i++)
            {
                listReference.Add(i.ToString());
            }
        }

        [Benchmark]
        public void AllocateSequenceReference()
        {
            for (int i = 0; i < Max; i++)
            {
                sequenceReference.Add(i.ToString());
            }
        }

        [Benchmark]
        public void AllocateListValue()
        {
            for (int i = 0; i < Max; i++)
            {
                var s = i.ToString();
                listValue.Add((s,s));
            }
        }

        [Benchmark]
        public void AllocateSequenceValue()
        {
            for (int i = 0; i < Max; i++)
            {
                var s = i.ToString();
                sequenceValue.Add((s, s));
            }
        }
    }
}
