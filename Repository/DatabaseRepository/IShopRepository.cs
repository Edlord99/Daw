using DAW.Models._1_M;
using DAW.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repository.DatabaseRepository
{
    public interface IShopRepository : IGenericRepository<Shop>
    {
        void GroupBy();
        List<Shop> getAll();
        void updateShop(Shop shop);
    }
}
