using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services.Interfaces
{
    public interface IHomeAssignmentUserService
    {
        IEnumerable<HomeAssignmentUser> GetHomeAssignmentUsers();
        HomeAssignmentUser GetHomeAssignmentUserById(Guid id);
        HomeAssignmentUser CreateHomeAssignmentUser(HomeAssignmentUser homeAssignmentUser);
        void GradeHomeAssignment(Guid studentId, Guid homeAssignmentId, double mark, Guid currentUserId);
        void Delete(Guid id);
    }
}
