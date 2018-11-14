using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Catagory
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Catagory()
        {
            ID = Guid.NewGuid();
        }
    }
}
