using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Models
{
    public class HomeAssignment
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime DueDateTime { get; set; }
        public Course Course { get; set; }
        public string Text { get; set; }
        public List<HomeAssignmentUser> HomeAssignmentUsers { get; set; }

        public HomeAssignment()
        {
            HomeAssignmentUsers = new List<HomeAssignmentUser>();
        }
    }
}
