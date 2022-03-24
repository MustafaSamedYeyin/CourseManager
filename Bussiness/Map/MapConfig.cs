using AutoMapper;
using Core.Entities;
using DTOs.Auth;
using DTOs.Auth.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Map
{
    internal class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
        }
    }
}
