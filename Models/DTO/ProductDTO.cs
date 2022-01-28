using DAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models
{
    public class ProductDTO: BaseEntity
    {
        public string Name { get; set; }

        public float Price { get; set; }

    }
}
