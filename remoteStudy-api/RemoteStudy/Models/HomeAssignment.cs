using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class HomeAssignment
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime DueDateTime { get; set; }
    }
}
