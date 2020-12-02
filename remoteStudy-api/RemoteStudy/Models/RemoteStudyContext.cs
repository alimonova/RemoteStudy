using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class RemoteStudyContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<LessonElement> LessonElements { get; set; }
        public DbSet<HomeAssignment> HomeAssignments { get; set; }
        public DbSet<HomeAssignmentUser> HomeAssignmentUsers { get; set; }
        public DbSet<CourseTag> CourseTags { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public RemoteStudyContext()
        { }

        public RemoteStudyContext(DbContextOptions<RemoteStudyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
