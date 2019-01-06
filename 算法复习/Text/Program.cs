using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program Text = new Program();

            int[] ll = { 123, 5, 1, 3, 2 };
            Text.InsertionSrot(ll); 
            Console.ReadKey(); 
        }

        //寻找完美数
        public int[] Pf(int Max)
        {
            List<int> text = new List<int>();
            for (int i = 0; i < Math.Sqrt(Max); i++)
            {
                int sum = 0;
                for (int j = i - 1; j > 0; j--)
                {
                    if (i % j == 0)
                    {
                        sum += j;
                    }

                    if (j == 1)
                    {
                        if (sum == i)
                        {
                            text.Add(i);
                        }
                    }                  
                }
               // Console.WriteLine(sum);
            }
            return text.ToArray();
        }
        //插入排序算法
        public int[] InsertionSrot(int[] s)
        {
             
            for (int i = 0; i < s.Length - 1; i++)
            {
                 
                int temp = s[i + 1];
                int j = i;
                while (j >= 0 && s[j] > temp)
                {
                    s[j + 1] = s[j];
                    j--;
                  
                }
                s[j + 1] = temp;
            }
            return s;
        }
    }
}
