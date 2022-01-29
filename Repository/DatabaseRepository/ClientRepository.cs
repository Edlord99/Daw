using DAW.Data;
using DAW.Models._1_1;
using DAW.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repository.DatabaseRepository
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DAWContext context) : base(context)
        {

        }

        public List<Client> GetAllWithInclude()
        {
            return _table.Include(x => x.DetailsClient).ToList();
        }

        public Client GetByFullName(string name)
        {
            return _table.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));

        }

        public Client GetByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.Username.ToLower().Equals(username.ToLower()));
        }

        public Client GetByFullNameIncludingDetails(string name)
        {
            return _table.Include(x => x.DetailsClient).FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        public Client GetByIdIncludingDetails(Guid Id)
        {
            return _table.Include(x => x.DetailsClient).FirstOrDefault(x => x.Id.ToString().Equals(Id.ToString()));
        }

        public void GroupBy()
        {
            var groupedUsers = _table.GroupBy(u => u.DetailsClient.Country);

            foreach (var userGroupByCountry in groupedUsers)
            {
                Console.WriteLine("User Country: " + userGroupByCountry.Key);
                foreach (Client c in userGroupByCountry)
                {
                    Console.WriteLine(c.Name);
                }
            }
        }
    }
}
