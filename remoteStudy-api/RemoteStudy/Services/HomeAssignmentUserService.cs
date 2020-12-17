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
    }
}
