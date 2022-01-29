using DAW.Models._1_1;
using DAW.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repository.DatabaseRepository
{
    public interface IDetailsRepository : IGenericRepository<DetailsClient>
    {
        DetailsClient CreateDetails(string country, string city, string email);
    }
}
