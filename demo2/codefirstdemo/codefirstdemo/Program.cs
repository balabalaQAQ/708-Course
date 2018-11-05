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
            using (var context = new CourseContext())
            {
                Console.WriteLine("ef初始化");
            }
        }
    }
}
