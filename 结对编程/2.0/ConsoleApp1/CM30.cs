using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CM30
    {
        private static Random number = new Random(); //实例化一个随机数
        private static DataTable dt = new DataTable();
        /// <summary>
        /// 判断输入的类型是否为整数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool IsNumber(string input)
        {
            if (Regex.IsMatch(input, @"^[+-]?\d*[.]?$"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 问题验证
        /// </summary>
        /// <param name="input"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        private static bool IsNumber(string input, int l)
        {
            if (Regex.IsMatch(input, @"^[+-]?\d*[.]?$"))
            {
                var num = Convert.ToDouble(input);
                if (l == 1)
                {
                    if (num <= 0 || num >= 100000)
                    {
                        Console.WriteLine("请输入正确的出题量范围");
                    }
                }
                if (l == 2)
                {
                    if (num <= 0 || num > 100)
                    {
                        Console.WriteLine("请输入正确的数据范围");
                    }
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 公式配置与运算
        /// </summary>
        /// <param name="Number">初始数</param>
        /// <param name="Range">数据范围</param>
        public static void OpNumber(int Range, int exercises, int Operators, int OperatorsClass, bool Random_Decimal, ref string[] Expression, ref string[] Answer)
        {
            string[] calculation = new string[] { "＋", "－", "×", "÷" };
            string[] performance = new string[] { "+", "-", "*", "/" };
            for (int i = 0; i < exercises; i++)
            {
                string[] es = Exercises(Range, Operators, OperatorsClass, calculation, performance, Random_Decimal);
                Expression[i] = "(" + (i + 1) + ")、" + es[1] + "=";
                Answer[i] = "(" + (i + 1) + ")、" + es[2];
                Console.WriteLine(es[1] + "=" + es[2]);
            }

        }
        private static string[] Exercises(int Range, int Operators, int OperatorsClass, string[] calculation, string[] performance, bool Random_Decimal)
        {
            List<string> Result = new List<string>();
            string Formula = "", Formulanum = "";
            double number1 = Random_Number(Random_Decimal, Range);//随机一个初始数
            int OP = number.Next(0, Operators);//随机运算符数量         
            Formulanum = Formula += number1;
            for (int j = 0; j <= OP; j++)
            {
                int opnext = number.Next(0, OperatorsClass);//随机一个符号
                double number2 = Random_Number(Random_Decimal, Range);//随机一个数
                if (opnext == 3 && number2 == 0)//判断算式是否存在除0
                {
                    number2 = Random_Number(Random_Decimal, Range);//重新随机一个数
                }
                Formula += calculation[opnext] + number2;
                Formulanum += performance[opnext] + number2;
                if (Condition(Range, Operators, OperatorsClass, calculation, performance, ref Formula, ref Formulanum, Random_Decimal))
                    break;
            }
            Result.Add(Formulanum);
            Result.Add(Formula);
            Result.Add(CM10.Shunting(Formulanum).ToString());
            return Result.ToArray();
        }

        private static bool Condition(int Range, int Operators, int OperatorsClass, string[] calculation, string[] performance, ref string Formula, ref string Formulanum, bool Random_Decimal)
        {
            if (Convert.ToDouble(dt.Compute(Formulanum, "null").ToString()) < 0)
            {
                string[] es = Exercises(Range, Operators, OperatorsClass, calculation, performance, Random_Decimal);
                Formulanum = es[0];
                Formula = es[1];
                return true;
            }
            if (!IsNumber(dt.Compute(Formulanum, "null").ToString()) && !Random_Decimal)
            {
                string[] es = Exercises(Range, Operators, OperatorsClass, calculation, performance, Random_Decimal);
                Formulanum = es[0];
                Formula = es[1];
                return true;
            }
            return false;
        }


        private static string Brackets(string result)
        {
            string brack = "()";
            result.Insert(0, brack[0].ToString());
            for (int s = 0; s < result.Length; s++)
            {
                if (result[s] == '+' || result[s] == '-')
                {

                }
            }
            return "";
        }
        public static double Random_Number(bool Random_Decimal, int Range)
        {
            if (Random_Decimal)
            {
                Range = Range * 100;
                double s = number.Next(1, Range + 1);
                return s / 100;
            }
            return number.Next(1, Range);
        }
    }
}
