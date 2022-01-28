using DAW.Models.Base;
using DAW.Models.M_M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models._1_M
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public Shop Shop { get; set; }
        public Guid ShopId { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
