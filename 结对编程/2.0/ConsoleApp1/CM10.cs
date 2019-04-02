using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CM10
    {
        public static double ToDig(string str)
        {
            double n = 0, mag = 0.1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.') break;
                mag *= 10;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.') continue;
                n += mag * (str[i] - '0');
                mag /= 10;
            }
            return n;
        }
        public static double GetAns(double a, double b, char c)
        {
            double s = 0;
            switch (c)
            {
                case '+': s = b + a; break;
                case '-': s = b - a; break;
                case '*': s = b * a; break;
                case '/': s = b / a; break;
            }
            return s;
        }
        public static int[] Priority = new int[55];
        public static double Shunting(string str)
        {
            Priority['+'] = Priority['-'] = 0;
            Priority['*'] = Priority['/'] = 1;
            Stack<double> iStk = new Stack<double>();
            Stack<char> strStk = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9') || (i == 0 && str[i] == '-') || (str[i] == '-' && str[i - 1] == '('))
                {
                    // 判断是否为数字或负号
                    string s1 = "";
                    int f = 1, t = i;
                    if (str[i] == '-')
                    {
                        f = -1;
                        i++;
                    }
                    while ((str[i] >= '0' && str[i] <= '9') || str[i] == '.')
                    {
                        if (t < str.Length)
                        {
                            if (str[t] == '+' || str[t] == '-' || str[t] == '*' || str[t] == '/' || t >= str.Length || str[t] == ')')
                            { i = t - 1; break; }
                            s1 += str[t];
                            t++;
                            if (t >= str.Length) { i = t - 1; break; }
                        }
                        else
                            break;
                    }
                    iStk.Push(f * ToDig(s1));
                }
                else
                {
                    Value_Sort(str, iStk, strStk, i);
                }
            }
            // 表达式处理完后，不断运算直到操作符空栈，此时数据栈剩下的一个数据就是最终结果
            while (strStk.Count != 0)
            {
                Value_ToDig(iStk, strStk);
            }
            return iStk.Peek();
        }

        private static void Value_Sort(string str, Stack<double> iStk, Stack<char> strStk, int i)
        {
            if (strStk.Count == 0 || str[i] == '(' || strStk.Peek() == '(' || (str[i] != ')' && Priority[str[i]] > Priority[strStk.Peek()]))
            {
                if (str[i] == ')' && strStk.Peek() == '(')
                    strStk.Pop();
                else
                    strStk.Push(str[i]);
            }
            else if (str[i] == ')')
            {
                char c = strStk.Peek();
                while (c != '(')
                {
                    double a = iStk.Pop();
                    double b = iStk.Pop();
                    strStk.Pop();
                    iStk.Push(GetAns(a, b, c));
                    c = strStk.Peek();
                }
                strStk.Pop();
            }
            else
            {
                Value_ToDig(iStk, strStk);
                strStk.Push(str[i]);
            }
        }

        private static void Value_ToDig(Stack<double> iStk, Stack<char> strStk)
        {
            double a = iStk.Pop();
            double b = iStk.Pop();
            char c = strStk.Pop();
            iStk.Push(GetAns(a, b, c));
        }
    }
}
