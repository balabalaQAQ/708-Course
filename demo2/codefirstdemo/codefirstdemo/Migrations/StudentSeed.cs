using codefirstdemo.CodeFirstModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codefirstdemo.Migrations
{
    public class StudentSeed
    {
        public static void Seed(CourseContext context)
        {

            var f1 = new Student()
            {
                ID = Guid.NewGuid(),
                StudentCode = "20170310084",
                Name = "覃添钰",
                Sex = false,
                Address = "颐华城",
                Birthday = DateTime.Parse("2017-06-07"),
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子工程学院"),
                Phone = "15177750470"
            };
            var f2 = new Student()
            {
                ID = Guid.NewGuid(),
                StudentCode = "20170310090",
                Name = "少洺",
                Sex = false,
                Address = "高沙",
                Birthday = DateTime.Parse("2017-05-9"),
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院"),
                Phone = "666666666"
            };
            var f3 = new Student()
            {
                ID = Guid.NewGuid(),
                StudentCode = "20170310050",
                Name = "babalalaQAQ",
                Sex = false,
                Address = "hhh",
                Birthday = DateTime.Parse("2017-08-07"),
                Department = context.Departments.SingleOrDefault(x => x.Name == "财经与物流学院"),
                Phone = "123213213"
            };
            var f4 = new Student()
            {
                ID = Guid.NewGuid(),
                StudentCode = "165165165",
                Name = "啦啦啦",
                Sex = false,
                Address = "颐华城",
                Birthday = DateTime.Parse("2017-06-07"),
                Department = context.Departments.SingleOrDefault(x => x.Name == "汽车工程学院"),
                Phone = "15177750470"
            };
            var f5 = new Student()
            {
                ID = Guid.NewGuid(),
                StudentCode = "20170310000",
                Name = "软件老祖",
                Sex = false,
                Address = "颐华城",
                Birthday = DateTime.Parse("2000-06-07"),
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子工程学院"),
                Phone = "0000000000"
            };
            context.Student.Add(f1);
            context.Student.Add(f2);
            context.Student.Add(f3);
            context.Student.Add(f4);
            context.Student.Add(f5);
            context.SaveChanges();
        }
    }
}
