﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CourseTag> CourseTags { get; set; }

        public Tag()
        {
            CourseTags = new List<CourseTag>();
        }
    }
}