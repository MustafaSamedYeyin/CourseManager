using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Map
{
    internal static class Mapping
    {
        internal static IMapper EfMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapConfig());
            });
            return config.CreateMapper();
        }
    }
}
