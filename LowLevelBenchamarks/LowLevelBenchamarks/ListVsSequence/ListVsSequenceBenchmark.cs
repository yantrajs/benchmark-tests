using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Text;
using YantraJS.Core;

namespace LowLevelBenchamarks.ListVsSequence
{

    public class ListNode
    {
        public List<ListNode> Children;

        public ListNode()
        {
        
        }

        public void Fill(int n, int max)
        {
            if (n == 0)
                return;
            Children = new List<ListNode>();
            for (int i = 0; i < max; i++)
            {
                var node = new ListNode();
                Children.Add(node);
                node.Fill(n - 1, max);
            }
        }
    }

    public class SequenceNode
    {
        public Sequence<SequenceNode> Children;

        public SequenceNode()
        {

        }

        public void Fill(int n, int max)
        {
            if (n == 0)
                return;
            Children = new Sequence<SequenceNode>();
            for (int i = 0; i < max; i++)
            {
                var node = new SequenceNode();
                Children.Add(node);
                node.Fill(n - 1, max);
            }
        }
    }

    public class ListVsSequenceBenchmark
    {

        public const int Max = 65;

        public const string Data = "A";

        [Benchmark]
        public object AllocateList()
        {
            var node = new ListNode();
            node.Fill(4, Max);
            return node;
        }

        [Benchmark]
        public object AllocateSequence()
        {
            var node = new SequenceNode();
            node.Fill(4, Max);
            return node;
        }

    }
}
