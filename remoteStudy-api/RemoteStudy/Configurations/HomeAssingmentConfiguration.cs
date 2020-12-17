using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Configurations
{
    public class HomeAssingmentConfiguration : IEntityTypeConfiguration<HomeAssignment>
    {
        public void Configure(EntityTypeBuilder<HomeAssignment> builder)
        {
            builder.ToTable("HomeAssignments");
            builder.HasKey(o => o.Id);

            builder
                .HasMany(c => c.HomeAssignmentUsers)
                .WithOne(p => p.HomeAssignment)
                .HasForeignKey(c => c.HomeAssignmentId);

            builder
                .HasOne(c => c.Lesson)
                .WithMany(p => p.HomeAssignments)
                .HasForeignKey(c => c.LessonId);
        }
    }
}
