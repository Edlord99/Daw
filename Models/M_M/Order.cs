using DAW.Models._1_1;
using DAW.Models._1_M;
using DAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.M_M
{
    public class Order: BaseEntity
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime Time { get; set; }
    }
}
