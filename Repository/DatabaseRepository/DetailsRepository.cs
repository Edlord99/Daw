using DAW.Data;
using DAW.Models._1_1;
using DAW.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repository.DatabaseRepository
{
    public class DetailsRepository : GenericRepository<DetailsClient>, IDetailsRepository
    {
        public DetailsRepository(DAWContext context) : base(context)
        {

        }

        public DetailsClient CreateDetails(string country, string city, string email)
        {
            DetailsClient newInfo = new DetailsClient()
            {
                Email = email,
                Country = country,
                City = city
            };
            this.Create(newInfo);
            this.Save();
            return newInfo;
        }
    }
}
