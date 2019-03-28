using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairArithmetic
{
    class Program
    {

        static void Main(string[] args)
        {
            Expression expression = new Expression();

            //expression.ProblemSet("1年级", 1000, 100);
            //expression.ProblemSet("2年级", 10000, 100);
            expression.ProblemSet(2000, 1000, 100,2,true,true,true);
            expression.ProblemSet(200, 100, 200, 2, false, false, true);
            Console.ReadKey();

        }    
    }
}
