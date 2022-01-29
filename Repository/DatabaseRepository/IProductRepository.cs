using DAW.Models._1_M;
using DAW.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repository.DatabaseRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> getAllFromShop(Guid shopId);
        void updateProduct(Product product);
    }
}
