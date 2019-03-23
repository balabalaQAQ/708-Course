using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;

namespace Arithmetic
{

    public class Demand
    {
        static string[] op = new string[] { "＋", "－", "×", "÷" };//显示符号
        static string[] ll = new string[] { "+", "-", "*", "/" };//运算符号
        static string result = "";//结果
        static string Formula = "";//显示的文本
        static string Formulanum = "";//用于运算的文本
        static Random number = new Random(); //实例化一个随机数  
        /// <summary>
        /// 判断输入的类型是否为整数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumber(string input)
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
        public static bool Problem(string input, int l)
        {
            if (IsNumber(input) == true)
            {
                var num = Convert.ToDouble(input);
                if (l == 1)
                {
                    if (num <= 0 || num > 100000)
                    {
                        Console.WriteLine("请输入正确的出题量范围");
                    }
                }
                if (l == 2)
                {
                    if (num < 1 || num > 100)
                    {
                        Console.WriteLine("请输入正确的数据范围");
                    }
                }
                if (l == 3)
                {
                    if (num < 1 || num > 3)
                    {
                        Console.WriteLine("请输入正确范围内的运算符数量");
                    }
                }
                if (l == 4)
                {
                    if (num < 1 || num > 6)
                    {
                        Console.WriteLine("请输入正确的年级段");
                    }
                }
                return true;
            }
            Console.WriteLine("请输入整数");
            return false;
        }
        /// <summary>
        /// 公式配置与运算
        /// </summary>
        /// <param name="Number">初始数</param>
        /// <param name="Range">数据范围</param>
        /// <param name="rule">运算符数量</param> 
        /// <param name="Grade">年级</param> 
        public static void OpNumber(int Number, int Range, int rule, int Grade)
        {

            Range = Range + 1;
            for (int i = 1; i <= Number; i++)
            {
                FormulaSetup(Range, rule, Grade);
                if (IsNumber(result) == false)
                {
                    result = Convert.ToDouble(result).ToString("#0.00");  //使小数结果保留两位小数
                    Console.WriteLine(Formula + "≈" + result);
                }
                Console.WriteLine(Formula + "=" + result);
                //生成题目
                string Exercise = "txt/Exercise.txt";//创建txt文件的具体路径
                StreamWriter exercise = new StreamWriter(Exercise, false, Encoding.Default);//实例化StreamWriter
                exercise.WriteLine("1."+Formula);
                exercise.Flush();
                exercise.Close();
                //生成答案
                string Answer = "txt/Answer.txt";
                StreamWriter answer = new StreamWriter(Answer, false, Encoding.Default);
                answer.WriteLine("1." + result);
                answer.Flush();
                answer.Close();
            }
        }
        /// <summary>
        /// 代码算式优化
        /// </summary>
        /// <param name="opnext"></param>
        /// <returns></returns>
        public static int FormulaOP(int opnext)
        {
            Random number = new Random();
            int i = 0, l = 0, NewOpnext = 0;
            if (opnext == 3)//避免太多的乘法
            {
                i++;
                if (i > 2)
                {
                    NewOpnext = number.Next(0, 4);
                    return NewOpnext;
                }
                return opnext;
            }
            if (opnext == 4)//避免太多的除法
            {
                l++;
                if (opnext > 1)
                {
                    NewOpnext = number.Next(0, 4);
                    return NewOpnext;
                }
                return opnext;
            }
            return opnext;
        }
        /// <summary>
        /// 生成分数
        /// </summary>
        /// <returns></returns>
        public static string Fraction()
        {
            return null;
        }
        /// <summary>
        /// 表达式打印和输出
        /// </summary>
        /// <param name="Formula"></param>
        /// <param name="Formulanum"></param>
        public static void FormulaSetup(int Range, int rule, int Grade)
        {
            DataTable dt = new DataTable();
            double number1 = number.Next(0, Range);//随机一个初始数
            int OP = number.Next(1, rule + 1);//随机运算符数量
            int opnext = 0; //符号
            int number2 = 0; //数
            Formulanum = Formula = "";
            Formulanum = Formula += number1;
            for (int j = 1; j <= OP; j++)
            {
                //使三年级前无乘除
                if (Grade <= 2)
                {
                    opnext = number.Next(0, 2);
                }
                else
                {
                    opnext = number.Next(0, 4);
                }
                //随机一个符号
                number2 = number.Next(0, Range);//随机一个数

                int newOP = FormulaOP(opnext);
                Formula += op[newOP] + number2;
                Formulanum += ll[newOP] + number2;

            }
            result = dt.Compute(Formulanum, "false").ToString();
            if (Convert.ToDouble(result) < 0 || (opnext == 4 && number2 == 0))//判断算式是否存在除0或小于0
            {
                FormulaSetup(Range, rule, Grade);
            }
            if (Grade < 4)
            {
                if (IsNumber(result) == false)//是4年级之前无法出现小数
                {
                    FormulaSetup(Range, rule, Grade);
                }
            }

        }

    }
}
