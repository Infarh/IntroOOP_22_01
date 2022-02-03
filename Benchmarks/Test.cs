using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class Test
    {
        private static int[] __Values = new int[10000];

        [Benchmark(Baseline = true)]
        public int For()
        {
            var sum = 0;
            for (var i = 0; i < __Values.Length; i++)
                sum += __Values[i];

            return sum;
        }

        [Benchmark]
        public int Foreach()
        {
            var sum = 0;
            foreach (var value in __Values)
                sum += value;

            return sum;
        }

        [Benchmark]
        public int While()
        {
            var sum = 0;
            var i = 0;
            while (i < __Values.Length)
                sum += __Values[i++];

            return sum;
        }
    }
}
