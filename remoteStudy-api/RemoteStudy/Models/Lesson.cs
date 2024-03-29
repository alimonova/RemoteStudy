﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime DateTimeCreation { get; set; }
        public string Text { get; set; }
        public List<LessonElement> LessonElements { get; set; }
        public List<Comment> Comments { get; set; }
        public List<HomeAssignment> HomeAssignments { get; set; }

        public Lesson()
        {
            LessonElements = new List<LessonElement>();
            Comments = new List<Comment>();
            HomeAssignments = new List<HomeAssignment>();
        }
    }
}
