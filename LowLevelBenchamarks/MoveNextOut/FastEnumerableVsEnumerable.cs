using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using YantraJS.Core;

namespace MoveNextOut
{
    /**
     * 
        |            Method |     Mean |   Error |  StdDev |
        |------------------ |---------:|--------:|--------:|
        |    MoveNextOutInt | 219.2 ns | 1.42 ns | 1.32 ns |
        |      EnumerateInt | 383.8 ns | 3.66 ns | 3.42 ns |
        | MoveNextOutString | 318.5 ns | 1.25 ns | 1.04 ns |
        |   EnumerateString | 468.7 ns | 3.43 ns | 3.21 ns |
        | MoveNextOutStruct | 444.6 ns | 3.00 ns | 2.80 ns |
        |   EnumerateStruct | 639.5 ns | 2.93 ns | 2.74 ns |

        MoveNextOut is slightly faster due to single call.
     */
    public class FastEnumerableVsEnumerable
    {

        private static IFastEnumerable<int> sequence = new Sequence<int>() {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                14,
                15,
                16,
            };

        [Benchmark]
        public void MoveNextOutInt()
        {
            var en = sequence.GetFastEnumerator();
            while (en.MoveNext(out var c))
            {
                Read(c);
            }

        }

        [Benchmark]
        public void EnumerateInt()
        {
            var en = sequence.GetEnumerator();
            while (en.MoveNext())
            {
                Read(en.Current);
            }
        }

        private static IFastEnumerable<string> stringSequence = new Sequence<string>() {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15",
                "16"
            };

        [MethodImpl(MethodImplOptions.NoOptimization)]
        public void Read(string s)
        {
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        public void Read(int s)
        {
        }


        [Benchmark]
        public void MoveNextOutString()
        {
            var en = stringSequence.GetFastEnumerator();
            while (en.MoveNext(out var c))
            {
                Read(c);
            }

        }

        [Benchmark]
        public void EnumerateString()
        {
            var en = stringSequence.GetEnumerator();
            while (en.MoveNext())
            {
                Read(en.Current);
            }
        }

        private static IFastEnumerable<(string,string)> structSequence = new Sequence<(string,string)>() {
                ("1", "1"),
                ("2", "2"),
                ("3", "3"),
                ("4", "4"),
                ("5", "5"),
                ("6", "6"),
                ("7", "7"),
                ("8", "8"),
                ("9", "9"),
                ("10", "10"),
                ("11", "11"),
                ("12", "12"),
                ("13", "13"),
                ("14", "14"),
                ("15", "15"),
                ("16", "16")
            };

        [Benchmark]
        public void MoveNextOutStruct()
        {
            var en = structSequence.GetFastEnumerator();
            while (en.MoveNext(out var c))
            {
                Read(c.Item1);
            }

        }

        [Benchmark]
        public void EnumerateStruct()
        {
            var en = structSequence.GetEnumerator();
            while (en.MoveNext())
            {
                Read(en.Current.Item1);
            }
        }
    }
}
