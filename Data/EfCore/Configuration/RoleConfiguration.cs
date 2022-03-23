using Core.Entities;
using Core.StringValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role()
            {
                Id = 1,
                Name = RoleValues.Admin,
            });
            builder.HasData(new Role()
            {
                Id = 2,
                Name = RoleValues.Mod
            });
            builder.HasData(new Role()
            {
                Id = 3,
                Name = RoleValues.View
            });

        }
    }
}
