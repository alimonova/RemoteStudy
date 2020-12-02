using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(o => o.Id);

            builder
                .HasOne(c => c.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(c => c.UserId).OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(c => c.Courses)
                .WithOne(p => p.Teacher)
                .HasForeignKey(c => c.TeacherId);

            builder
                .HasMany(c => c.Comments)
                .WithOne(p => p.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}
