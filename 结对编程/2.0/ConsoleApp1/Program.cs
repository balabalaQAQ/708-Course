using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("你是多少年级？？？？？、");
            int s1 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("你想做多少道题？？？？？、");
            int s2 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("你希望题中数的范围是多少？？？？？、");
            int s3 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("你希望做多少个运算符以内的四则运算？？？？？、");
            int s4 = Convert.ToInt16(Console.ReadLine());
            // CM21.IsGrades(s1, s2, s3, s4);
            for (int i = 0; i <= s2; i++)
            {
                Console.WriteLine(CM22.DecimalAndInteger(s2));
            }
            Console.ReadKey();
        }

    }
}
