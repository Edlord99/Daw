using DAW.Models.Authentication;
using DAW.Models.Base;
using DAW.Models.M_M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAW.Models._1_1
{
    public class Client: BaseEntity
    {
        public string Name { get; set; }

        public DetailsClient DetailsClient { get; set; }
        public Guid DetailsClientId { get; set; }

        public ICollection<Order> Orders { get; set; }

        [JsonIgnore]
        public string PasswordHashed { get; set; }

        public string Username { get; set; }

        public Role Role { get; set; }

    }
}
