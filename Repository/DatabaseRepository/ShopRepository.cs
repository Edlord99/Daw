using DAW.Data;
using DAW.Models._1_M;
using DAW.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repository.DatabaseRepository
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(DAWContext context) : base(context)
        {

        }

        //LINQ
        public List<Shop> getAll()
        {
            var shops = from s in _table
                            select s;
            return shops.ToList();
        }

        public void GroupBy()
        {
            var shopsGrouped = _table.GroupBy(s => s.Location);

            foreach (var shopsByCountry in shopsGrouped)
            {
                Console.WriteLine("Shop location: " + shopsByCountry.Key);
                foreach (Shop s in shopsByCountry)
                {
                    Console.WriteLine(s.Name);
                }
            }
        }
        public void updateShop(Shop shop)
        {
            _table.Update(shop);
        }
    }
}
