using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Course> Courses { get; set; } 

        public Subject()
        {
            Courses = new List<Course>(); 
        }
    }
}
