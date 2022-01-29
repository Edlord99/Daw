using DAW.Models;
using DAW.Models._1_M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Services
{
    public interface IShopService
    {
        ShopDTO createShop(Shop shop);
        List<ShopDTO> getAll();
        ShopDTO deleteShop(Shop shop);
        void Save();
        ShopDTO updateShop(Guid id, Shop shop);
        Shop FindById(Guid id);
    }
}
