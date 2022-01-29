using DAW.Models;
using DAW.Models._1_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Services
{
    public interface IDetailsService
    {
        DetailsClientDTO createDetails(string email, string country, string city);
        DetailsClientDTO create(DetailsClient info);

    }
}
