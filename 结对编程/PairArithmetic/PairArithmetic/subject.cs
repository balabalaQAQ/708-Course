using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairArithmetic
{
    public class Subject
    {
        //年级
        public string Grades { get; set; }
        //题目数量
        public int Exercises { get; set; }
        //取值范围
        public int Range { get; set; }
        //运算符数量
        public int Operators { get; set; }
        //运算符总类
        public int OperatorClass { get; set; }
        //是否支持真分数
        public bool IsFraction { get; set; } = false;
        //是否支持小数
        public bool IsDecimal { get; set; } = false;
        //是否支持乘方
        public bool IsInvolution { get; set; } = false;

        public Subject()
        {
        }
        public Subject(string grades, int exercises, int range)//按年级设定题目
        {
            Grades = grades;
            Exercises = exercises;
            Range = range;
        }
        public Subject(int exercises, int range, int operators, int operatorClass, bool isFraction, bool isDecimal, bool isInvolution)
        {
            Exercises = exercises;
            Range = range;
            Operators = operators;
            OperatorClass = operatorClass;
            IsFraction = isFraction;
            IsDecimal = isDecimal;
            IsInvolution = isInvolution;
        }
    }
}
