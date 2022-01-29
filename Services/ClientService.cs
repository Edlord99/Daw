using DAW.Models;
using BC = BCrypt.Net.BCrypt;
using DAW.Models._1_1;
using DAW.Repository.DatabaseRepository;
using System;
using System.Collections.Generic;
using DAW.Models.Authentication;

namespace DAW.Services
{
    public class ClientService : IClientService
    {
        public IClientRepository _clientRepository;
        public IDetailsRepository _detailsRepository;
        public IJWTUtils _ijwtUtils;

        public ClientService(IClientRepository clientRepository, IDetailsRepository detailsRepository, IJWTUtils ijwtUtils)
        {
            _clientRepository = clientRepository;
            _detailsRepository = detailsRepository;
            _ijwtUtils = ijwtUtils;
        }


        public ClientDTO getClientByName(string name)
        {
            Client user = _clientRepository.GetByFullName(name);
            ClientDTO userDTO = new ClientDTO()
            {
                Name = user.Name,
                Email = ""
            };
            return userDTO;
        }

        public ClientDTO getClientByUsername(string username)
        {
            Client user = _clientRepository.GetByUsername(username);
            ClientDTO userDTO = new ClientDTO()
            {
                Name = user.Name,
                Email = ""
            };
            return userDTO;
        }


        public ClientDTO getClientByNameWithDetails(string name)
        {
            Client user = _clientRepository.GetByFullNameIncludingDetails(name);
            ClientDTO userDTO = new ClientDTO()
            {
                Name = user.Name,
                Email = user.DetailsClient.Email,
                City = user.DetailsClient.City,
                Country = user.DetailsClient.Country,
                Username = user.Username
            };
            return userDTO;
        }

        public ClientDTO createClient(Client user)
        {
            DetailsClient details = _detailsRepository.CreateDetails(user.DetailsClient.Email, user.DetailsClient.Country, user.DetailsClient.City);
            _clientRepository.Save();

            user.DetailsClientId = details.Id;
            user.PasswordHashed = BC.HashPassword(user.PasswordHashed);

            _clientRepository.Create(user);
            _clientRepository.Save();
            ClientDTO userDTO = new ClientDTO()
            {
                Name = user.Name,
                Email = user.DetailsClient.Email,
                Country = user.DetailsClient.Country,
                City = user.DetailsClient.City,
                Username = user.Username
            };
            return userDTO;
        }

        public List<ClientDTO> getAll()
        {
            List<ClientDTO> usersDTO = new List<ClientDTO>();
            List<Client> allUsers = _clientRepository.GetAllWithInclude();
            allUsers.ForEach(user =>
            {
                ClientDTO userDTO = new ClientDTO()
                {
                    Name = user.Name,
                    Email = user.DetailsClient.Email,
                    Country = user.DetailsClient.Country,
                    City = user.DetailsClient.City,
                    Username = user.Username
                };
                usersDTO.Add(userDTO);
            });
            return usersDTO;
        }

        public Client FindById(Guid id)
        {
            return _clientRepository.FindById(id);
        }

        public ClientDTO FindByIdWithDetails(Guid id)
        {
            Client user = _clientRepository.GetByIdIncludingDetails(id);

            ClientDTO userDTO = new ClientDTO()
            {
                Name = user.Name,
                Email = user.DetailsClient.Email,
                City = user.DetailsClient.City,
                Country = user.DetailsClient.Country,
                Username = user.Username
            };
            return userDTO;
        }

        public void Save()
        {
            _clientRepository.Save();
        }

        public UserResponseDTO Authenticate(UserRequestDTO request)
        {
            var user = _clientRepository.GetByUsername(request.Username);
            if (user == null || !BC.Verify(request.Password, user.PasswordHashed))
            {
                return null;
            }
            //generam un jwt token (jwt = json web token)
            var token = _ijwtUtils.GenerateJWTToken(user);
            return new UserResponseDTO(user, token);

        }

        public ClientDTO deleteUser(Client user)
        {
            _clientRepository.Delete(user);
            ClientDTO userDTO = new ClientDTO()
            {
                Name = user.Name,
                Email = user.DetailsClient.Email,
                City = user.DetailsClient.City,
                Country = user.DetailsClient.Country,
                Username = user.Username
            };
            return userDTO;
        }
    }
}
