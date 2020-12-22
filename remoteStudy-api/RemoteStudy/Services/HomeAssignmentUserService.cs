using RemoteStudy.Models;
using RemoteStudy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services
{
    public class HomeAssignmentUserService : IHomeAssignmentUserService
    {
        private readonly RemoteStudyContext _assignmentcontext;

        public HomeAssignmentUserService(RemoteStudyContext assignmentcontext)
        {
            _assignmentcontext = assignmentcontext;
        }

        public IEnumerable<HomeAssignmentUser> GetHomeAssignmentUsers()
        {
            return _assignmentcontext.HomeAssignmentUsers;
        }

        public HomeAssignmentUser GetHomeAssignmentUserById(Guid id)
        {
            return _assignmentcontext.HomeAssignmentUsers.Where(x => x.Id == id).First();
        }

        public HomeAssignmentUser CreateHomeAssignmentUser(HomeAssignmentUser homeAssignmentUser)
        {
            _assignmentcontext.HomeAssignmentUsers.Add(homeAssignmentUser);
            _assignmentcontext.SaveChanges();

            return homeAssignmentUser;
        }

        public void Delete(Guid id)
        {
            var coursetag = GetHomeAssignmentUserById(id);
            if (coursetag != null)
            {
                _assignmentcontext.HomeAssignmentUsers.Remove(coursetag);
                _assignmentcontext.SaveChanges();
            }
        }

        public void GradeHomeAssignment(Guid homeAssignmentUserId, double mark, Guid currentUserId)
        { 
            var homeAssignmentUser = _assignmentcontext.HomeAssignmentUsers.Where(x => x.Id == homeAssignmentUserId).First();
            var user = _assignmentcontext.Courses.Where(z=>z.Id == _assignmentcontext.Lessons
            .Where(y=>y.Id == _assignmentcontext.HomeAssignments.Where(x => x.Id == homeAssignmentUser.HomeAssignmentId).First().LessonId).First().CourseId).First().TeacherId;
            if (user == currentUserId)
            {
                _assignmentcontext.HomeAssignmentUsers.Where(x => x.HomeAssignmentId == homeAssignmentUser.HomeAssignmentId && x.UserId == homeAssignmentUser.UserId).First().Mark = mark;
                _assignmentcontext.SaveChanges();
            }
        }
    }
}
