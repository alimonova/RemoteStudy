using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Configurations
{
    public class CourseTagConfiguration : IEntityTypeConfiguration<CourseTag>
    {
        public void Configure(EntityTypeBuilder<CourseTag> builder)
        {
            builder.ToTable("CourseTags");
            builder.HasKey(o => o.Id);

            builder
                .HasOne(c => c.Course)
                .WithMany(p => p.CourseTags)
                .HasForeignKey(c => c.CourseId);

            builder
                .HasOne(c => c.Tag)
                .WithMany(p => p.CourseTags)
                .HasForeignKey(c => c.TagId);
        }
    }
}
