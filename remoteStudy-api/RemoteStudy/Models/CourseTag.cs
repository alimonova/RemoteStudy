using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class CourseTag
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid TagId { get; set; }
        public Course Course { get; set; }
        public Tag Tag { get; set; }
    }
}
