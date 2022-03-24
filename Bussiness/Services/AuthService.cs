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
using System.Security.Claims;
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

        public async Task<bool> ChechUserExixstAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password); 
            return result;
        }

        //public async Task<GetUserDto> GetUserByEmailAsync(string Email)
        //{
        //    return Mapping.EfMap().Map<GetUserDto>(await _userManager.FindByEmailAsync(Email));
        //}

        public async Task<string> LoginAsync(LoginDto loginDto, string secret, string issuer, string audience)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return _jwtService.GenerateToken(secret, issuer, audience, (await _userManager.GetClaimsAsync(user)).ToList());
            }
            return null;
        }

        public async Task<bool> RegisterAsync(RegisterDto registerDto)
        {
            var isExixstUser =await _userManager.FindByEmailAsync(registerDto.Email);
            if (isExixstUser == null)
            {
                await _userManager.CreateAsync(Mapping.EfMap().Map<User>(registerDto),registerDto.Password);
                var user = await _userManager.FindByEmailAsync(registerDto.Email);
                await _userManager.AddToRoleAsync(user, RoleValues.View);
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.UserName));
                foreach (var item in await _userManager.GetRolesAsync(user))
                {
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, item));
                }
                return true;
            }
            return false;
            
        }
    }
}
