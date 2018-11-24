using DataContext;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Migrations
{
    public class CatagorySeed
    {
        public static void Seed(ProductContext context)
        {
            var d1 = new Catagory()
            {
                ID = "001",
                Name="日常用品"
            };
            var d2 = new Catagory()
            {
                ID = "002",
                Name = "电竞设备"
            };
            var d3 = new Catagory()
            {
                ID = "003",
                Name = "动漫周边"
            };
            var d4 = new Catagory()
            {
                ID = "004",
                Name = "进口商品"
            };
            var d5 = new Catagory()
            {
                ID = "005",
                Name = "家用电器"
            };
            context.Catagory.Add(d1);
            context.Catagory.Add(d2);
            context.Catagory.Add(d3);
            context.Catagory.Add(d4);
            context.Catagory.Add(d5);
            context.SaveChanges();
        }
    }
}
