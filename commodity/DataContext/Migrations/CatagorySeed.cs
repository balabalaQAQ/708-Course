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
                ID=Guid.NewGuid(),
                Name="商品01"
            };
            var d2 = new Catagory()
            {
                ID = Guid.NewGuid(),
                Name = "商品02"
            };
            var d3 = new Catagory()
            {
                ID = Guid.NewGuid(),
                Name = "商品03"
            };
            var d4 = new Catagory()
            {
                ID = Guid.NewGuid(),
                Name = "商品04"
            };
            var d5 = new Catagory()
            {
                ID = Guid.NewGuid(),
                Name = "商品05"
            };
            context.Catagory.Add(d1);
            context.Catagory.Add(d2);
            context.Catagory.Add(d3);
            context.Catagory.Add(d4);
            context.Catagory.Add(d5);
        }

    }
}
