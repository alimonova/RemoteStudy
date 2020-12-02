using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Dto
{
    public class HomeAssignmentUserDto
    {
        public Guid Id { get; set; }
        public Guid HomeAssignmentId { get; set; }
        public Guid UserId { get; set; }
    }
}
