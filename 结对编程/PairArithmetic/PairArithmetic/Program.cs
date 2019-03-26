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
        DataTable dt = new DataTable();
        static void Main(string[] args)
        {

        }
        //表达式处理
        public string ExcHand(string number1, string op, string number2)
        {
            double num2 = Convert.ToDouble(number2);
            if (op == "/" && num2 == 0)//无除零
            {

            }
            string result = number2 + op + number2;
            result = dt.Compute(result, "flase").ToString();
            if (Convert.ToDouble(result) < 0)//无负数
            {

            }
        }
        //表达式运算
        public string Operation(string Expression)
        {
            string result = dt.Compute(Expression, "false").ToString();
            return result;
        }
    }
}
