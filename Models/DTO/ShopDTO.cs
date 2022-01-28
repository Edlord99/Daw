using DAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models
{
    public class ShopDTO: BaseEntity
    {
        public string Name { get; set; }

        public string Location { get; set; }

    }
}
