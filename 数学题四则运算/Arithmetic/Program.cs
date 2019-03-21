using System;
using System.Diagnostics;

namespace Arithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            Console.WriteLine("请输入出题量（1-100000）题");
            var number = Console.ReadLine();
            var N = Demand.IsNumber(number, 1);
            Console.WriteLine("请输入数据范围（1-100）");
            var Range = Console.ReadLine();
            var L = Demand.IsNumber(Range, 2);
            Console.WriteLine("请输入运算符数量（1-3）个");
            var rule = Console.ReadLine();
            var r = Demand.IsNumber(rule, 3);
            if (N == L == r == true)
            {
                Demand.OpNumber(number, Range, Convert.ToInt32(rule));
            }
            sp.Stop();
            Console.WriteLine(sp.Elapsed.ToString());
            Console.ReadKey();
        }
    }
}
