using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowLevelBenchamarks.RefVsField
{


    /// <summary>
    /// |    Method |     Mean |     Error |    StdDev |
    /// |---------- |---------:|----------:|----------:|
    /// |   TestRef | 3.286 us | 0.0207 us | 0.0184 us |
    /// | TestField | 3.153 us | 0.0120 us | 0.0112 us |
    /// 
    /// Field of class is faster than ref var, ref of field is only faster for Struct type, not the ref type
    /// </summary>
    public class RefVsFieldTest
    {
        private Variable RefVar;
        private Variable FieldVar;

        public class Variable
        {
            public string Data;
        }

        public RefVsFieldTest()
        {
            this.RefVar = new Variable { };
            this.FieldVar = new Variable { };
        }

        // [Benchmark]
        public void TestRef()
        {
            ref var d = ref RefVar.Data;
            for (int i = 0; i < 100; i++)
            {
                d = i.ToString();
            }
        }

        // [Benchmark]
        public void TestField()
        {
            var f = FieldVar;
            for (int i = 0; i < 100; i++)
            {
                f.Data = i.ToString();
            }
        }

    }
}
