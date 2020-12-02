using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Configurations
{
    public class LessonElementConfiguration : IEntityTypeConfiguration<LessonElement>
    {
        public void Configure(EntityTypeBuilder<LessonElement> builder)
        {
            builder.ToTable("LessonElements");
            builder.HasKey(o => o.Id);

            builder
              .HasOne(c => c.Lesson)
              .WithMany(p => p.LessonElements)
              .HasForeignKey(c => c.LessonId);
        }
    }
}
