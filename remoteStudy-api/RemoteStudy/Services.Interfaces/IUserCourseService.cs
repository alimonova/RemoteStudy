using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteStudy.Services.Interfaces
{
    public interface IUserCourseService
    {
        IEnumerable<UserCourse> GetUserCourses();
        UserCourse GetUserCourseById(Guid id);
        UserCourse GetRequests(Guid courseId);
        UserCourse CreateUserCourse(UserCourse userCourse);
        void AcceptRequest(Guid userCourseId);
        double RateCourse(Guid userId, Guid courseId, double rate);
        void Delete(Guid id);
        bool UserHasAccessToCourse(Guid userId, Guid courseId);
    }
}
