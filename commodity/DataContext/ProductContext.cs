using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class ProductContex: DbContext
    {
        public DbSet<Catagory> Catagory { get; set; }
        public DbSet<Cominfo> Cominfo { get; set; }
    }
}
