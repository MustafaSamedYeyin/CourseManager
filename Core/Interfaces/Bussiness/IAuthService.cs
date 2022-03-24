using DTOs.Auth;
using DTOs.Auth.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Bussiness
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto loginDto, string secret, string issuer, string audience);
        Task<bool> RegisterAsync(RegisterDto registerDto);
        Task<bool> ChechUserExixstAsync(LoginDto loginDto);
        //Task<GetUserDto> GetUserByEmailAsync(string Email);
    }
}
