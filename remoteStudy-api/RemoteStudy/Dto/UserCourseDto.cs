using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Dto
{
    public class UserCourseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public bool HasAccess { get; set; }
        public bool IsFavourite { get; set; }
    }
}
