using DAW.Models._1_M;
using DAW.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("allFromShop/{id}")]
        public IActionResult getAllFromShop([FromRoute] string id)
        {
            var guidId = new Guid(id);
            var products = _productService.getProductsFromShop(guidId);
            return Ok(products);
        }

        [HttpPost("{shopId}")]
        public IActionResult AddProduct(Product product, Guid shopId)
        {
            var result = _productService.createProduct(product, shopId);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] string id)
        {
            Guid guidId = new Guid(id);
            Product productToDelete = _productService.FindById(guidId);
            if (productToDelete == null)
            {
                return NotFound();
            }
            _productService.deleteProduct(productToDelete);
            _productService.Save();

            return Ok(productToDelete);
        }

        [HttpPatch("{productId}")]
        public IActionResult Patch([FromRoute] string productId, [FromBody] JsonPatchDocument<Product> product)
        {
            Guid parsedId = new Guid(productId);
            Product productToUpdate = _productService.FindById(parsedId);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            product.ApplyTo(productToUpdate, ModelState);
            _productService.Save();

            return Ok(productToUpdate);
        }
    }
}
