using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lessons");
            builder.HasKey(o => o.Id);

            builder
                .HasMany(c => c.LessonElements)
                .WithOne(p => p.Lesson)
                .HasForeignKey(c => c.LessonId);

            builder
                .HasOne(c => c.Course)
                .WithMany(p => p.Lessons)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
