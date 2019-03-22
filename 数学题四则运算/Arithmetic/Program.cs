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
            var N = Demand.Problem(number, 1);
            Console.WriteLine("请输入数据范围（1-100）");
            var Range = Console.ReadLine();
            var L = Demand.Problem(Range, 2);
            Console.WriteLine("请输入运算符数量（1-3）个");
            var rule = Console.ReadLine();
            var r = Demand.Problem(rule, 3);
            Console.WriteLine("请输入年级，以配置难度(1-6)年级");
            var Grade = Console.ReadLine();
            var G = Demand.Problem(Grade, 4);
            if (N == L == r ==G== true)
            {
                Demand.OpNumber(Convert.ToInt32(number), Convert.ToInt32(Range), Convert.ToInt32(rule), Convert.ToInt32(Grade));
            }
            sp.Stop();
            Console.WriteLine(sp.Elapsed.ToString());
            Console.ReadKey();
        }
    }
}
