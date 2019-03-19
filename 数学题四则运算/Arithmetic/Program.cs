using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;

namespace Arithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            Demand demand = new Demand();
            

            Console.WriteLine("请设置出题量(1-100000)");
            var Number = Console.ReadLine();
            var D= Demand.IsNumber(Number,1);
            Console.WriteLine("请设置数据范围(1-100)");
            var Range = Console.ReadLine();
            var R = Demand.IsNumber(Range,2);
            if (D == R == true)
            {
                Demand.OpNumber(Number, Range);
            }
            Console.ReadKey();
          
        }
       
    }
}
