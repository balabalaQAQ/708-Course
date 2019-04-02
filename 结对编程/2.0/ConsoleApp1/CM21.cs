using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleApp1
{
    class CM21
    {

        public static void IsGrades(int grades, int exercises, int range, int Operators)
        {
            string[] Expression = new string[exercises];
            string[] Answer = new string[exercises];
            switch (grades)
            {
                case 1:
                    CM30.OpNumber(range, exercises, Operators, 2, false, ref Expression, ref Answer);
                    Injection(Expression, Answer);
                    break;
                case 2:
                    CM30.OpNumber(range, exercises, Operators, 4,false, ref Expression, ref Answer);
                    Injection(Expression, Answer);
                    break;
                case 3:
                    CM30.OpNumber(range, exercises, Operators, 4, false, ref Expression, ref Answer);
                    Injection(Expression, Answer);
                    break;
                case 4:
                    CM30.OpNumber(range, exercises, Operators, 4,true, ref Expression, ref Answer);
                    Injection(Expression, Answer);
                    break;
                case 5:
                    CM30.OpNumber(range, exercises, Operators, 4,true, ref Expression, ref Answer);
                    Injection(Expression, Answer);
                    break;
                case 6:
                    CM30.OpNumber(range, exercises, Operators, 4, true, ref Expression, ref Answer);
                    Injection(Expression, Answer);
                    break;
                default: break;
            }

        }

        private static void Injection(string[] Expression, string[] Answer)
        {
            Generate_Expression(Expression);
            Generate_Answer(Answer);
        }

        public static void Generate_Expression(string[] Expression)
        {
            using (StreamWriter sw = new StreamWriter("Exercise.txt"))
            {
                sw.Flush();
                foreach (string dir in Expression)
                {
                    sw.WriteLine(dir);
                }
                sw.Close();
            }
        }
        public static void Generate_Answer(string[] Answer)
        {
            using (StreamWriter sw = new StreamWriter("Answer.txt"))
            {
                sw.Flush();
                foreach (string dir in Answer)
                {
                    sw.WriteLine(dir);
                }
                sw.Close();
            }
        }

    }
}
