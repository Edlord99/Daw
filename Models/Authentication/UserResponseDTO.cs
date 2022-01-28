using DAW.Models._1_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Authentication
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }

        public UserResponseDTO(Client user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Name = user.Name;
            Token = token;

        }
    }
}
