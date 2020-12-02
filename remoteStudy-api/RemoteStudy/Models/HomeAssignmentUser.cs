using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class HomeAssignmentUser
    {
        public Guid Id { get; set; }
        public Guid HomeAssignmentId { get; set; }
        public Guid UserId { get; set; }
        public HomeAssignment HomeAssignment { get; set; }
        public User User { get; set; }
    }
}
