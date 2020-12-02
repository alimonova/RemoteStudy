using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class Role : IdentityRole<Guid>
    {
        public const string Admin = "Admin";
        public const string User = "Student";
        public const string Teacher = "Teacher";
        public List<UserRole> UserRoles { get; set; }
        public Role()
        {
            UserRoles = new List<UserRole>();
        }
    }
}
