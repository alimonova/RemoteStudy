using RemoteStudy.Models;
using RemoteStudy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services
{
    public class HomeAssignmentService : IHomeAssignmentService
    {
        private readonly RemoteStudyContext _homeAssignmentcontext;

        public HomeAssignmentService(RemoteStudyContext homeAssignmentcontext)
        {
            _homeAssignmentcontext = homeAssignmentcontext;
        }

        public IEnumerable<HomeAssignment> GetHomeAssignments()
        {
            return _homeAssignmentcontext.HomeAssignments.ToList();
        }

        public HomeAssignment GetHomeAssignmentById(Guid id)
        {
            var homeAssignment = _homeAssignmentcontext.HomeAssignments.Where(x => x.Id == id).First();
            return homeAssignment;
        }

        public HomeAssignment CreateHomeAssignment(HomeAssignment homeAssignment)
        {
            _homeAssignmentcontext.HomeAssignments.Add(homeAssignment);
            _homeAssignmentcontext.SaveChanges();

            return homeAssignment;
        }

        public HomeAssignment UpdateHomeAssignment(HomeAssignment homeAssignment)
        {
            _homeAssignmentcontext.HomeAssignments.Update(homeAssignment);
            _homeAssignmentcontext.SaveChanges();

            return homeAssignment;
        }

        public void Delete(Guid Id)
        {
            var homeAssignment = GetHomeAssignmentById(Id);
            if (homeAssignment != null)
            {
                _homeAssignmentcontext.HomeAssignments.Remove(homeAssignment);
                _homeAssignmentcontext.SaveChanges();
            }
        }

        public IEnumerable<HomeAssignment> GetHomeAssignmentsByLessonId(Guid lessonId)
        {
            return _homeAssignmentcontext.HomeAssignments.Where(x => x.LessonId == lessonId);
        }
    }
}
