using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services.Interfaces
{
    public interface IHomeAssignmentService
    {
        IEnumerable<HomeAssignment> GetHomeAssignments();
        HomeAssignment GetHomeAssignmentById(Guid id);
        HomeAssignment CreateHomeAssignment(HomeAssignment homeAssignment);
        HomeAssignment UpdateHomeAssignment(HomeAssignment homeAssignment);
        IEnumerable<HomeAssignment> GetHomeAssignmentsByLessonId(Guid lessonId);
        void Delete(Guid id);
    }
}
