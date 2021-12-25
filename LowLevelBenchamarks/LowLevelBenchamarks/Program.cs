using BenchmarkDotNet.Running;
using LowLevelBenchamarks.ListVsSequence;
using System;

namespace LowLevelBenchamarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = BenchmarkDotNet.Configs.ManualConfig.Create(BenchmarkDotNet.Configs.DefaultConfig.Instance)
                .WithOption(BenchmarkDotNet.Configs.ConfigOptions.DisableOptimizationsValidator, true);
            BenchmarkRunner.Run(typeof(Program).Assembly, config);
        }
    }
}
