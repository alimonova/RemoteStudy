using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class LessonElement
    {
        public Guid Id { get; set; }
        public string ElementLink { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
