﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class UserCourse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public bool HasAccess { get; set; }
        public bool IsFavourite { get; set; }
        public double Rate { get; set; }
    }
}
