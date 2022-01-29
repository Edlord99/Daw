using DAW.Models;
using DAW.Models._1_M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Services
{
    public interface IProductService
    {
        List<ProductDTO> getProductsFromShop(Guid shopId);
        ProductDTO createProduct(Product product, Guid shopId);
        Product FindById(Guid productId);
        ProductDTO deleteProduct(Product product);
        void Save();
    }
}
