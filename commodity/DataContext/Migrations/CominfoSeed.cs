using DataContext;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Migrations
{
    public class CominfoSeed
    {
        public static void Seed(ProductContext context)
        {
            for (var i = 0; i < 200; i++)
            {
                var d1 = new Cominfo()
                {
                    SN ="00"+i,
                    Name="商品"+i,
                    DSCN= "用了商品" + i + "都说好！！！",
                    Catagory=context.Catagory.Single(x=>x.ID=="001")
                };
                context.Cominfo.Add(d1);
             }
            for (var i = 0; i < 200; i++)
            {
                var d2 = new Cominfo()
                {
                    SN = "00" + i,
                    Name = "商品" + i,
                    DSCN = "用了商品" + i + "都说好！！！",
                    Catagory = context.Catagory.Single(x => x.ID == "002")
                };
                context.Cominfo.Add(d2);
            }
            for (var i = 0; i < 200; i++)
            {
                var d3 = new Cominfo()
                {
                    SN = "00" + i,
                    Name = "商品" + i,
                    DSCN = "用了商品" + i + "都说好！！！",
                    Catagory = context.Catagory.Single(x => x.ID == "003")
                };
                context.Cominfo.Add(d3);
            }
            for (var i = 0; i < 200; i++)
            {
                var d4 = new Cominfo()
                {
                    SN = "00" + i,
                    Name = "商品" + i,
                    DSCN = "用了商品" + i + "都说好！！！",
                    Catagory = context.Catagory.Single(x => x.ID == "004")
                };
                context.Cominfo.Add(d4);
            }
            for (var i = 0; i < 200; i++)
            {
                var d5 = new Cominfo()
                {
                    SN = "00" + i,
                    Name = "商品" + i,
                    DSCN = "用了商品" + i + "都说好！！！",
                    Catagory = context.Catagory.Single(x => x.ID == "005")
                };
                context.Cominfo.Add(d5);
            }
         

        }
    }
}
