using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PairArithmetic.Subject;
using System.Web.Script.Serialization;
using System.IO;

namespace PairArithmetic
{
  public  class Expression
    {
        DataTable dt = new DataTable();
        JsonPaserWeb jsonPaserWeb = new JsonPaserWeb();
        Random number = new Random();
        //表达式运算
        public string Operation(string Expression)
        {
            string result = dt.Compute(Expression, "false").ToString();
            return result;
        }
        //按年级设定题目
        public void ProblemSet(string grades, int exercises, int range)
        {
            Subject subject = new Subject(grades, exercises, range);
            string json = jsonPaserWeb.Serialize(subject);//保存成JSON文件
            WriteProblem(json);
        }
        //用户自定义
        public void ProblemSet(int exercises, int range, int operators, int operatorClass, bool isFraction, bool isDecimal, bool isInvolution)
        {
            Subject subject = new Subject(exercises, range, operators, operatorClass, isFraction, isDecimal, isInvolution);
            string json = jsonPaserWeb.Serialize(subject);//保存成JSON文件
            WriteProblem(json);
        }
        public void WriteProblem(string json)
        {
            int i = 0;
            i++;
            for (int l = 0; l < i; l++)
            {
                Console.WriteLine(jsonPaserWeb.Deserialize(json).Exercises);
                // Console.WriteLine(jsonPaserWeb.Deserialize(json).Grades);
                Console.WriteLine(jsonPaserWeb.Deserialize(json).Operators);
                Console.WriteLine(jsonPaserWeb.Deserialize(json).OperatorClass);
                Console.WriteLine(jsonPaserWeb.Deserialize(json).Range);
                Console.WriteLine(jsonPaserWeb.Deserialize(json).IsDecimal);
                Console.WriteLine(jsonPaserWeb.Deserialize(json).IsFraction);
                Console.WriteLine(jsonPaserWeb.Deserialize(json).IsInvolution);
            }
        }
        //打印
        public void WriteTxt(string Expression,string result)
        {

            string Exercise = "txt/Exercise.txt";//创建txt文件的具体路径
            StreamWriter exercise = new StreamWriter(Exercise, false, Encoding.Default);//实例化StreamWriter
            exercise.WriteLine("1." + Expression);
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
}


