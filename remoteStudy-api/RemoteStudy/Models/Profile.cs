using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Pobatkovi { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Phone { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedinLink { get; set; }
    }
}
