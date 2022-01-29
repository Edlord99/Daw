using DAW.Models;
using DAW.Models._1_1;
using DAW.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Services
{
    public interface IClientService
    {
        ClientDTO getClientByName(string name);
        ClientDTO getClientByUsername(string username);
        ClientDTO getClientByNameWithDetails(string name);
        ClientDTO createClient(Client user);
        List<ClientDTO> getAll();
        Client FindById(Guid Id);
        ClientDTO FindByIdWithDetails(Guid Id);
        ClientDTO deleteUser(Client user);
        void Save();
        UserResponseDTO Authenticate(UserRequestDTO request);
    }
}
