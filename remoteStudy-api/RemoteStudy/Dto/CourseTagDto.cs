using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Dto
{
    public class CourseTagDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid TagId { get; set; }
    }
}
