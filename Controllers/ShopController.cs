using DAW.Models._1_M;
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
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("getAll")]
        public IActionResult getAllShops()
        {
            var result = _shopService.getAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddWithFromBody(Shop shop)
        {
            var result = _shopService.createBucatarie(shop);
            return Ok(result);
        }

        [HttpPatch("{shopId}")]
        public IActionResult Patch([FromRoute] string bucId, [FromBody] JsonPatchDocument<Shop> shop)
        {
            Guid parsedId = new Guid(bucId);
            Shop shopToUpdate = _shopService.FindById(parsedId);

            if (shopToUpdate == null)
            {
                return NotFound();
            }

            shop.ApplyTo(shopToUpdate, ModelState);
            _shopService.Save();

            return Ok(shopToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShop([FromRoute] string id)
        {
            Guid guidId = new Guid(id);
            Shop shopToDelete = _shopService.FindById(guidId);
            if (shopToDelete == null)
            {
                return NotFound();
            }
            _shopService.deleteShop(shopToDelete);
            _shopService.Save();



            return Ok(shopToDelete);
        }
    }
}
