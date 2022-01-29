using DAW.Models._1_1;
using DAW.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repository.DatabaseRepository
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Client GetByFullName(string name);
        List<Client> GetAllWithInclude();
        Client GetByFullNameIncludingDetails(string name);
        Client GetByIdIncludingDetails(Guid Id);
        Client GetByUsername(string username);
        void GroupBy();
    }
}
