using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(o => o.Id);

            builder
                .HasOne(c => c.Lesson)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.LessonId);

            builder
                .HasOne(c => c.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.UserId);

        }
    }
}
