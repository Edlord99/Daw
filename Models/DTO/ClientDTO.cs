using DAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models
{
    public class ClientDTO: BaseEntity
    {

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Email { get; set; }
    }
}
