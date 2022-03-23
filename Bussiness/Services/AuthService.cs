using Bussiness.Map;
using Core.Entities;
using Core.Interfaces.Bussiness;
using Core.Interfaces.Bussiness.Jwt;
using Core.StringValues;
using Data.EfCore.Context;
using DTOs.Auth;
using DTOs.Auth.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IJwtService _jwtService;

        public AuthService(UserManager<User> userManager, RoleManager<Role> roleManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }

        public async Task<bool> ChechUserExixstAsync(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<GetUserDto> GetUserByEmailAsync(string Email)
        {
            return Mapping.EfMap().Map<GetUserDto>(await _userManager.FindByEmailAsync(Email));
        }

        public async Task<string> LoginAsync(LoginDto loginDto, string secret, string issuer, string audience)
        {
            if (await _userManager.CheckPasswordAsync(Mapping.EfMap().Map<User>(loginDto), loginDto.Password))
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);

                return _jwtService.GenerateToken(secret, issuer, audience, (await _userManager.GetClaimsAsync(user)).ToList());
            }
            return null;
        }

        public async Task<bool> RegisterAsync(RegisterDto registerDto)
        {
            var user = Mapping.EfMap().Map<User>(await GetUserByEmailAsync(registerDto.Email));
            if (user != null)
            {
                await _userManager.CreateAsync(Mapping.EfMap().Map<User>(registerDto));
                await _userManager.AddToRoleAsync(user, RoleValues.View);
                return true;
            }
            return false;
            
        }
    }
}
