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
            //使用数据上下文进行数据操作，using表示上下文代码的范围，执行完后内存会自动释放
            using (var text = new CourseDBEntities())
            {
                //.where .orderby .tolist()注意调用顺序


                //添加一条记录
                //var newDepartments = new Departments
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "环境与食品学院",
                //    Dscn = "环境与食品检测",
                //    SortCode = "007",
                //};
                //把新的对象添加到上下文中
                //text.Departments.Add(newDepartments);
                ////更新上下文，把新的实体保存到数据库中
                //text.SaveChanges();


                //修改
                //var eidtDepartment = text.Departments.SingleOrDefault(x => x.Name == "环境与食品学院");
                //if (eidtDepartment != null)
                //{
                //    eidtDepartment.Name = "环境与食品检测学院";
                //    eidtDepartment.SortCode = "008";
                //    text.SaveChanges();
                //}
                //else
                //    Console.WriteLine("未找到该记录,不能修改。");

                //删除
                //find--用主键查询
                //var delDapt = text.Departments.Find(Guid.Parse("274bf492-71e3-483b-b38d-03975e740d27"));
                //text.Departments.Remove(delDapt);
                //text.SaveChanges();

                var newDept = new Departments
                {
                    ID = Guid.NewGuid(),
                    Name = "测试学院",
                    Dscn = "不可描述",
                    SortCode = "999",
                };
                text.Departments.Add(newDept);
                text.SaveChanges();

                //显示新的记录
                var departments = text.Departments.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号:{0},部门名称:{1}，说明:{2}", d.SortCode, d.Name, d.Dscn);
                Console.ReadKey();

            }
        }
    }
}