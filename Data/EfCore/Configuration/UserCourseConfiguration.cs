using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore.Configuration
{
    internal class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.HasOne(i=> i.User).WithMany(i=> i.UserCourses).HasForeignKey(i => i.UserId);
            builder.HasOne(i=> i.Course).WithMany(i=> i.UserCourses).HasForeignKey(i => i.CourseId);
        }
    }
}
