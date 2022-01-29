using DAW.Models._1_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Utilities.JWT
{
    public interface IJWT
    {
        string GenerateJWTToken(Client user);
        Guid ValidateJWTToken(string token);
    }
}
