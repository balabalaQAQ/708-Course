using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new CourseDBEntities().Courses.ToList();
            Console.Write(0);
        }
    }
}