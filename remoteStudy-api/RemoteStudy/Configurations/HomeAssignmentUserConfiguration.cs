using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Configurations
{
    public class HomeAssignmentUserConfiguration : IEntityTypeConfiguration<HomeAssignmentUser>
    {
        public void Configure(EntityTypeBuilder<HomeAssignmentUser> builder)
        {
            builder.ToTable("HomeAssignmentUsers");
            builder.HasKey(o => o.Id);

            builder
                .HasOne(c => c.HomeAssignment)
                .WithMany(p => p.HomeAssignmentUsers)
                .HasForeignKey(c => c.HomeAssignmentId);

            builder
                .HasOne(c => c.User)
                .WithMany(p => p.HomeAssignmentUsers)
                .HasForeignKey(c => c.UserId);
        }
    }
}
