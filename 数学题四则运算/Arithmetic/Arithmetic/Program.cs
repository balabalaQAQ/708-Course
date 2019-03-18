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
            Random number = new Random(); //实例化一个随机数  

            Console.WriteLine("请设置出题量(1-100000)");
            var Number = Console.ReadLine();
            if (IsNumber(Number) == true)
            {
                int num=Convert.ToInt32(Number);
                if (num > 0 && num <= 100000)
                {
                    string[] op = new string[] { "＋", "－", "×", "÷" };
                    string[] ll = new string[] { "+", "-", "*", "/" };
                    string Formula = "";
                    string[] myArray = new string[num];

                    for (int i = 1; i <= num; i++)
                    {
                        double number1 = number.Next(0, 10);//随机一个10以内的数
                        double number2 = number.Next(0, 10);//随机一个10以内的数
                        int opnext = number.Next(0, 4);//随机一个 符号

                        Formula = number1 + op[opnext] + number2 ;
                    
                        Formulanum = number1 + ll[opnext] + number2;
                        DataTable dt = new DataTable();
                        string result = dt.Compute(Formula, "false").ToString();



                        Console.WriteLine(Formula + "=");
                        Console.WriteLine(result);
                        

                    }
                }
                else
                {
                    Console.WriteLine("请输入10000以内的整数");
                }
            }
            
            else
            {
                Console.WriteLine("请输入10000以内的整数");
            }


            //if (Convert.ToInt32(Number)!= Number)
            //string[] op = new string[] { "＋", "－", "×", "÷" };//定义一个符号数组
            //string[] myArray = new string[10];
            //for (int i = 0; i < 10; i++)
            //{
            //    double number1 = number.Next(1, 10);//随机一个10以内的数
            //    double number2 = number.Next(1, 10);//随机一个10以内的数
            //    int opnext = number.Next(0, 4);//随机一个 符号
            //    double result = 0;
            //    switch (opnext)
            //    {
            //        case 0:
            //            result = number1 + number2;
            //            break;
            //        case 1:
            //            result = number1 - number2;
            //            break;
            //        case 2:
            //            result = number1 * number2;
            //            break;
            //        case 3:
            //            result = number1 / number2;
            //            do { number1 = number.Next(1, 10); result = number1 / number2; }
            //            while (result != Convert.ToInt32(result));//若有小数则重新随机一个数
            //            break;
            //    }
            //    Console.WriteLine(number1 + op[opnext] + number2 + "=" + result);//输出公式
            //}
           
            Console.ReadKey();
        }
        public static bool IsNumber(string input)
        {
            if (Regex.IsMatch(input, @"^[+-]?\d*[.]?$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
