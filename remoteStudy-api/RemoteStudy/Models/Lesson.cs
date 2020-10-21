using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public DateTime DateTimeCreation { get; set; }
        public string Text { get; set; }
        public List<LessonElement> LessonElements { get; set; }

        public Lesson()
        {
            LessonElements = new List<LessonElement>();
        }
    }
}
