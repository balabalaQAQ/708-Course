using codefirstdemo.CodeFirstModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codefirstdemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var students = new CourseContext().Student.OrderBy(x => x.StudentCode).ToList();
            foreach (var s in students)
                Console.WriteLine("学号：{0} 姓名{1}",s.StudentCode , s.Name);
            Console.ReadKey();
        }
    }
}
