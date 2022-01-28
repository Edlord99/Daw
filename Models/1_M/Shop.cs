using DAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models._1_M
{
    public class Shop: BaseEntity
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
