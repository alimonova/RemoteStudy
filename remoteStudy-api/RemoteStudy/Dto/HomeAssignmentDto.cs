using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Dto
{
    public class HomeAssignmentDto
    {
        public Guid Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime DueDateTime { get; set; }
        public string Text { get; set; }
    }
}
