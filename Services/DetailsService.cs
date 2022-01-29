using DAW.Models;
using DAW.Models._1_1;
using DAW.Repository.DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Services
{
    public class DetailsService : IDetailsService
    {
        public IDetailsRepository _detailsRepository;

        public DetailsService(IDetailsRepository detailsRepository)
        {
            _detailsRepository = detailsRepository;
        }

        public DetailsClientDTO create(DetailsClient info)
        {
            _detailsRepository.Create(info);
            _detailsRepository.Save();
            DetailsClientDTO infoDTO = new DetailsClientDTO()
            {
                Email = info.Email,
                Country = info.Country,
                City = info.City
            };
            return infoDTO;
        }

        public DetailsClientDTO createDetails(string email, string country, string city)
        {
            DetailsClient info = new DetailsClient()
            {
                Email = email,
                Country = country,
                City = city
            };
            _detailsRepository.Create(info);
            DetailsClientDTO infoDTO = new DetailsClientDTO()
            {
                Email = email,
                Country = country,
                City = city
            };
            return infoDTO;
        }
    }
}
