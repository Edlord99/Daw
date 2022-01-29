using DAW.Data;
using DAW.Models._1_M;
using DAW.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repository.DatabaseRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DAWContext context) : base(context)
        {

        }

        //LINQ
        public List<Product> getAllFromShop(Guid shopId)
        {
            //var retete = from r in _table
            //             where r.ColectieId.ToString() == colId.ToString()
            //             select r;
            //return retete.ToList();
            return _table.ToList();
        }

        public void updateProduct(Product product)
        {
            _table.Update(product);
        }
    }
}
