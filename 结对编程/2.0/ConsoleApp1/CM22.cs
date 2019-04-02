using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class CM22
    {
        public static void ProblemSet(int exercises, int range, int operators, int operatorClass, bool isFraction, bool isDecimal, bool isInvolution)
        {
            if (isDecimal)
            {
                for (int i = 0; i <= range; i++)
                {
                    DecimalAndInteger(range);
                }
            }
        }

        //随机产生小数和整数

        public static double DecimalAndInteger(int range)
        {
            double item = 0.0;
            Random l = new Random();
            var bo = l.Next(1, 3);
            if (bo == 1)
            {

                item = CM30.Random_Number(true, range);

            }
            else
            {
                item = CM30.Random_Number(false, range);
            }
            return item;
        }
    }
}