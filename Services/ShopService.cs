using DAW.Models;
using DAW.Models._1_M;
using DAW.Repository.DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Services
{
    public class ShopService : IShopService
    {
        public IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public Shop FindById(Guid id)
        {
            return _shopRepository.FindById(id);
        }

        public ShopDTO createShop(Shop shop)
        {
            _shopRepository.Create(shop);
            _shopRepository.Save();
            ShopDTO shopDTO = new ShopDTO()
            {
                Name = shop.Name,
                Location = shop.Location,
            };
            return shopDTO;
        }

        public List<ShopDTO> getAll()
        {
            List<ShopDTO> shopsDTO = new List<ShopDTO>();
            List<Shop> shops = _shopRepository.getAll();
            shops.ForEach(shop =>
            {
                ShopDTO shopDTO = new ShopDTO()
                {
                    Name = shop.Name,
                    Location = shop.Location
                };
                shopsDTO.Add(shopDTO);
            });
            return shopsDTO;
        }

        public ShopDTO updateShop(Guid id, Shop shop)
        { 
            _shopRepository.updateShop(shop);
            _shopRepository.Save();
            ShopDTO shopDTO = new ShopDTO()
            {
                Name = shop.Name,
                Location = shop.Location
            };
            return shopDTO;
        }
        public void Save()
        {
            _shopRepository.Save();
        }

        public ShopDTO deleteShop(Shop shop)
        {
            _shopRepository.Delete(shop);
            ShopDTO shopDTO = new ShopDTO()
            {
                Name = shop.Name,
                Location = shop.Location
            };
            return shopDTO;
        }
    }
}
