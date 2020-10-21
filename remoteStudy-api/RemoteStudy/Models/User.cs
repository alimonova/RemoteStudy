using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Password { get; set; }
        public string Token { get; set; }
        public Profile Profile { get; set; }
        public string PictureUrl { get; set; }
        public UserRole UserRole { get; set; }
        public List<Course> Courses { get; set; }
        public User()
        {
            Courses = new List<Course>();
        }
    }
}
