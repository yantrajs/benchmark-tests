using BenchmarkDotNet.Running;
using System;

namespace LowLevelBenchamarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
