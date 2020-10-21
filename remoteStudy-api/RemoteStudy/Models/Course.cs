using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TeacherId { get; set; }
        public string Image { get; set; }
        public double Rating { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ExamDateTime { get; set; }
        public User Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
