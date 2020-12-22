using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(o => o.Id);

            builder
                .HasMany(c => c.CourseTags)
                .WithOne(p => p.Course)
                .HasForeignKey(c => c.CourseId);

            builder
                .HasMany(c => c.Lessons)
                .WithOne(p => p.Course)
                .HasForeignKey(c => c.CourseId);
            
            builder
                .HasOne(c => c.Subject)
                .WithMany(p => p.Courses)
                .HasForeignKey(c => c.SubjectId);

            builder
                .HasOne(c => c.Teacher)
                .WithMany(p => p.Courses)
                .HasForeignKey(c => c.TeacherId);

        }
    }
}
