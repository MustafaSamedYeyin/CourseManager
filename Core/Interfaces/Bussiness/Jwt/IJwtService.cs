using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Bussiness.Jwt
{
    public interface IJwtService
    {
        string GenerateToken(string secret, string issuer, string audience, List<Claim> claims); 
        
    }
}
