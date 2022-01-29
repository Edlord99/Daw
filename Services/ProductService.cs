using DAW.Models;
using DAW.Models._1_M;
using DAW.Repository.DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Services
{
    public class ProductService : IProductService
    {
        public IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductDTO> getProductsFromShop(Guid shopId)
        {
            List<ProductDTO> productsDTO = new List<ProductDTO>();
            List<Product> allProducts = _productRepository.getAllFromShop(shopId);
            allProducts.ForEach(product =>
            {
                ProductDTO productDTO = new ProductDTO()
                {
                    Name = product.Name,
                    Price = product.Price,
                };
                productsDTO.Add(productDTO);
            });
            return productsDTO;
        }

        public ProductDTO createProduct(Product product, Guid shopId)
        {
            product.ShopId = shopId;
            _productRepository.Create(product);
            _productRepository.Save();

            ProductDTO productDTO = new ProductDTO()
            {
                Name = product.Name,
                Price = product.Price,
            };
            return productDTO;
        }

        public ProductDTO deleteProduct(Product product)
        {
            _productRepository.Delete(product);
            ProductDTO productDTO = new ProductDTO()
            {
                Name = product.Name,
                Price = product.Price,
            };
            return productDTO;
        }

        public Product FindById(Guid productId)
        {
            return _productRepository.FindById(productId);
        }

        public void Save()
        {
            _productRepository.Save();
        }
    }
}
